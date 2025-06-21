using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmwrestlingApp.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace ArmwrestlingApp.ViewModels.Categorie
{
    public class CategoryCreateViewModel
    {

        [Required]
        public Division Division { get; set; }

        [Required]

        public Gender Gender { get; set; }

        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = null!;



    }
}
