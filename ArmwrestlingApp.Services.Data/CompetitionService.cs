using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ArmwrestlingApp.Data.Repository.Interfaces;
using ArmwrestlingApp.Models;
using ArmwrestlingApp.Services.Data.Interfaces;
using ArmwrestlingApp.ViewModels.Categorie;
using ArmwrestlingApp.ViewModels.Competition;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.Services.Data
{
    internal class CompetitionService : BaseService, ICompetitionService
    {
        private readonly IRepository<Competition, Guid> competitionRepository;
        private readonly IRepository<Category, Guid> categoryRepository;
        private readonly IRepository<CompetitionCategorie, Guid> competitionCategorieRepository;


        public CompetitionService(IRepository<Competition, Guid> _competitionRepository, IRepository<Category, Guid> _categoryRepository,
            IRepository<CompetitionCategorie, Guid> _competitionCategorieRepository,
            UserManager<ApplicationUser> _userManager, IHttpContextAccessor _httpContextAccessor) :
            base(_httpContextAccessor, _userManager)
        {
            this.competitionRepository = _competitionRepository;
            this.categoryRepository = _categoryRepository;
            this.competitionCategorieRepository = _competitionCategorieRepository;
        }

        public async Task<bool> AddCompetitionAsync(CompetitionCreateViewModel model)
        {
            // Get user id 
            Guid userId = await GetCurrentUserIdAsync();

            if (userId == Guid.Empty)
            {
                return false;
            }



            Competition competition = new Competition()
            {
                Name = model.Name,
                Location = model.Location,
                Description = model.Description,
                Type = model.Type,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ImageUrl = model.ImageUrl,
                Creator_id = userId,
                Changer_id = userId,
                CreationDate = DateTime.UtcNow,
                LastChangeDate = DateTime.UtcNow,
                Finished = false
            };

            await this.competitionRepository.AddAsync(competition);

            return true;

        }

        public async Task<CompetitionDetailsViewModel> GetCompetitionDetailsByIdAsync(string id)
        {
            Guid parsedGuid = Guid.Empty;

            if (!this.IsGuidValid(id, ref parsedGuid))
            {
                return null;
            }


            Competition? competition = await this.competitionRepository.GetAllAttachedNoTracking()
                .Include(c => c.CompetitionCategoriesCompetitors).ThenInclude(c => c.Competitor)
                .Include(c => c.CompetitionCategoriesCompetitors).ThenInclude(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == parsedGuid);

            CompetitionDetailsViewModel competitionViewModel = null;

            if (competition != null)
            {
                competitionViewModel = new CompetitionDetailsViewModel()
                {
                    Id = competition.Id.ToString(),
                    Name = competition.Name,
                    Type = competition.Type.ToString(),
                    Location = competition.Location,
                    StartDate = competition.StartDate,
                    EndDate = competition.EndDate,
                    ImageUrl = competition.ImageUrl,
                    Categories = competition.CompetitionCategoriesCompetitors.GroupBy(cc => cc.Category).Select(cc => new CategoriesDetailsViewModel()
                    {
                        Id = cc.Key.Id.ToString(),
                        Name = cc.Key.Name,
                        ParticipantsCount = cc.Select(x => x.CompetitorId).Distinct().Count()

                    })

                };
            }

            return competitionViewModel;
        }

        public async Task<CompetitionListViewModel> GetAllCompetitionsOrderedByTypeAsync()
        {
            List<CompetitionViewModel> competitions = await this.competitionRepository.GetAllAttachedNoTracking().Select(c => new CompetitionViewModel()
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                EndDate = c.EndDate,
                ImageUrl = c.ImageUrl,
                Location = c.Location,
                StartDate = c.StartDate
            }).OrderByDescending(c => c.StartDate).ToListAsync();

            if (competitions.Count > 0)
            {
                CompetitionListViewModel model = new CompetitionListViewModel()
                {
                    PastCompetitions = competitions.Where(c => c.EndDate < DateTime.Today).ToList(),
                    OnGoingCompetitions = competitions.Where(c => c.StartDate <= DateTime.Today && c.EndDate >= DateTime.Today).ToList(),
                    FutureCompetitions = competitions.Where(c => c.StartDate > DateTime.Today).ToList()
                };
                return model;
            }
            return null;

        }

        public async Task<IEnumerable<CompetitionViewModel>> GetAllCompetitionsOrderedByDateAsync()
        {
            IEnumerable<CompetitionViewModel> competitions = await this.competitionRepository.GetAllAttachedNoTracking().Select(c => new CompetitionViewModel()
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                EndDate = c.EndDate,
                ImageUrl = c.ImageUrl,
                Type = c.Type.ToString(),
                Location = c.Location,
                StartDate = c.StartDate
            }).OrderByDescending(c => c.StartDate).ToListAsync();

            return competitions;
        }

        public async Task<CompetitionAddCategoryViewModel?> GetCategoriesAsync(string id)
        {
            //chveck if competion exist 3

            Guid parsedGuid = Guid.Empty;

            if (!this.IsGuidValid(id, ref parsedGuid))
            {
                return null;
            }


            var competition = this.competitionRepository.GetAllAttachedNoTracking()
                .Include(c => c.CompetitionsCategories)  // Include the related CompetitionsCategories
                .ThenInclude(cc => cc.Category)          // Then include the Category within CompetitionsCategories
                .FirstOrDefault(c => c.Id == parsedGuid);       // Get the competition by Id

            if (competition == null)
            {
                return null;
            }

            IEnumerable<Category> categories = await this.categoryRepository.GetAllAttachedNoTracking().ToListAsync();

            // Get list of all assigned categories
            IEnumerable<Category>? assignedCategories = competition?.CompetitionsCategories.Select(cc => cc.Category).ToList();



            CompetitionAddCategoryViewModel model = new CompetitionAddCategoryViewModel()
            {
                Id = competition.Id.ToString(),
                Name = competition.Name,
                AddCategoryViewModel = categories.Select(cc => new AddCategoryViewModel()
                {
                    Id = cc.Id.ToString(),
                    Name = cc.Name,
                    Division = cc.Division,
                    Gender = cc.Gender,
                    Assigned = assignedCategories != null && assignedCategories.Any(c => c.Id == cc.Id)
                }).ToList()
            };

            return model;
        }

        public async Task<bool> AddCategoriesToCompetionAsync(CompetitionAddCategoryViewModel model)
        {

            Guid competitionGuid = Guid.Empty;

            if (!this.IsGuidValid(model.Id, ref competitionGuid))
            {
                return false;
            }

            Competition? competition = await this.competitionRepository.GetByIdAsync(competitionGuid);
            if (competition == null)
            {
                return false;
            }


            ICollection<CompetitionCategorie> entitiesToAdd = new List<CompetitionCategorie>();

            foreach (AddCategoryViewModel categoryInputModel in model.AddCategoryViewModel)
            {

                Guid categoryGuid = Guid.Empty;
                bool isCategoryGuidValid = this.IsGuidValid(categoryInputModel.Id, ref categoryGuid);
                if (!isCategoryGuidValid)
                {
                    return false;
                }

                Category? category = await this.categoryRepository.GetByIdAsync(categoryGuid);

                if (category == null)
                {
                    return false;
                }

                CompetitionCategorie? competitionCategorie = await this.competitionCategorieRepository
                    .FirstOrDefaultAsync(cc => cc.CompetitionId == competitionGuid && cc.CategoryId == categoryGuid);

                if (categoryInputModel.Assigned)
                {
                    if (competitionCategorie == null)
                    {
                        entitiesToAdd.Add(new CompetitionCategorie()
                        {
                            Competition = competition,
                            Category = category
                        });
                    }
                    else
                    {
                        competitionCategorie.IsDeleted = false;
                    }
                }
                else
                {
                    if (competitionCategorie != null)
                    {
                        competitionCategorie.IsDeleted = true;
                    }
                }
            }


            await this.competitionCategorieRepository.AddRangeAsync(entitiesToAdd.ToArray());

            return true;
        }
    }
}
