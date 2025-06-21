using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.ViewModels.Categorie;

namespace ArmwrestlingApp.ViewModels.Competition
{
    public class CompetitionAddCategoryViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public IList<AddCategoryViewModel> AddCategoryViewModel { get; set; } = new List<AddCategoryViewModel>();
    }
}
