using Edublock.ViewModels.Certificate;

namespace Edublock.Services.Interfaces
{
    public interface ICertificateService 
    {
        Task CreateFromViewModel(CertificateCreateViewModel createViewModel);
        Task<List<CertificateListViewModel>> ListAllViewModels();
        Task<CertificateDetailsViewModel> GetDetailsViewModel(int id);
        Task<CertificateEditViewModel> GetEditViewModel(int id);
        Task<CertificateEditViewModel> UpdateFromEditViewModel(CertificateEditViewModel editViewModel);
        Task<CertificateEditViewModel> DeleteFromEditViewModel(CertificateEditViewModel editViewModel);
    }
}
