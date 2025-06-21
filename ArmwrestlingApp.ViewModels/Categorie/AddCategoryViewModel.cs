using ArmwrestlingApp.Common.Enums;

namespace ArmwrestlingApp.ViewModels.Categorie
{
    public class AddCategoryViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Division Division { get; set; }

        public bool Assigned { get; set; }
    }
}