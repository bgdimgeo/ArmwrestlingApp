using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Common.Enums;
using ArmwrestlingApp.ViewModels.Categorie;

namespace ArmwrestlingApp.ViewModels.Competition
{
    public class CompetitionDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Type { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<CategoriesDetailsViewModel> Categories { get; set; } = 
            new List<CategoriesDetailsViewModel>();



    }
}
