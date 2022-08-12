using Edublock.ViewModels.CertificateType;

namespace Edublock.Services.Interfaces
{
    public interface ICertificateTypeService
    {
        Task CreateFromViewModel(CertificateTypeCreateViewModel createViewModel);
        Task<List<CertificateTypeListViewModel>> ListAllViewModels();
        Task<CertificateTypeDetailsViewModel> GetDetailsViewModel(int id);
        Task<CertificateTypeEditViewModel> GetEditViewModel(int id);
        Task<CertificateTypeEditViewModel> UpdateFromEditViewModel(CertificateTypeEditViewModel certificateTypeEditViewModel);
        Task<CertificateTypeEditViewModel> DeleteFromEditViewModel(CertificateTypeEditViewModel certificateTypeEditViewModel);

    }
}
