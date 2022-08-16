using System.ComponentModel;

namespace Edublock.ViewModels.University
{
    public class UniversityCreateViewModel : UniversityBaseViewModel
    {
        [DisplayName("University Picture")]
        public string ThumbnailUrl { get; set; }
    }
}
