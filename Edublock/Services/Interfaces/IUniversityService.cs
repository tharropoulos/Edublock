using Edublock.ViewModels.University;

namespace Edublock.Services.Interfaces
{
    public interface IUniversityService
    {
        Task CreateFromViewModel(UniversityCreateViewModel createViewModel);
        Task<List<UniversityListViewModel>> ListAllViewModels();
        Task<UniversityDetailsViewModel> GetDetailsViewModel(int id);
        Task<UniversityEditViewModel> GetEditViewModel(int id);
        Task<UniversityEditViewModel> UpdateFromEditViewModel(UniversityEditViewModel editViewModel);
        Task<UniversityEditViewModel> DeleteFromEditViewModel(UniversityEditViewModel editViewModel);
    }
}
