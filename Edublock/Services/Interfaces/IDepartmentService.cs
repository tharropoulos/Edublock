using Edublock.ViewModels.Department;

namespace Edublock.Services.Interfaces
{
    public interface IDepartmentService
    {
        
        Task CreateFromViewModel(DepartmentCreateViewModel createViewModel);
        Task<List<DepartmentListViewModel>> ListAllViewModels();
        Task<DepartmentDetailsViewModel> GetDetailsViewModel(int id);
        Task<DepartmentEditViewModel> GetEditViewModel(int id);
        Task<DepartmentEditViewModel> DeleteFromEditViewModel(DepartmentEditViewModel editViewModel);
        Task<DepartmentEditViewModel> UpdateFromEditVieModel(DepartmentEditViewModel editViewModel);    
    }
}
