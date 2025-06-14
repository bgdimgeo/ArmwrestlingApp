using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmwrestlingApp.ViewModels.Competition
{
    public class CompetitionListViewModel
    {
        public IList<CompetitionViewModel> PastCompetitions { get; set; } = new List<CompetitionViewModel>();
        public IList<CompetitionViewModel> FutureCompetitions { get; set; } = new List<CompetitionViewModel>();
    }
}
