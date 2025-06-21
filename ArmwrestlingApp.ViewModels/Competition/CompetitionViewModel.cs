using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Common.Enums;

namespace ArmwrestlingApp.ViewModels.Competition
{
    public class CompetitionViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Type { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
    }
}
