using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.ViewModels.Categorie;

namespace ArmwrestlingApp.ViewModels.Competition
{
    public class CompetitionDetailsViewModel
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public DateOnly Date { get; set; }

        public string Type { get; set; }

        public IEnumerable<CategoriesDetailsViewModel> Categories { get; set; } = 
            new List<CategoriesDetailsViewModel>();



    }
}
