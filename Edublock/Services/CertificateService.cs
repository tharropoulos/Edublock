using Edublock.Models;
using Edublock.Repositories.Interfaces;
using Edublock.Services.Interfaces;
using Edublock.ViewModels.Certificate;
using Microsoft.EntityFrameworkCore;

namespace Edublock.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _repository;

        public CertificateService(ICertificateRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateFromViewModel(CertificateCreateViewModel createViewModel)
        {
            var certificate = new Certificate
            {
                DepartmentId = createViewModel.DepartmentId,
                CertificateDate = createViewModel.CertificateDate,
                CertificateTypeId = createViewModel.CertificateTypeId,
                Grade = createViewModel.Grade,
                WalletId = createViewModel.WalletId
            };
            _repository.Add(certificate);
            await _repository.Save();
        }
        public async Task<List<CertificateListViewModel>> ListAllViewModels()
        {
            var certificateViewModel = (await _repository.GetAll()).Select(c => new CertificateListViewModel
            {
                CertificateDate = c.CertificateDate,
                DepartmentId = c.DepartmentId,
                //UniversityName = c.Department.University.Name,

            }).ToList();
            return certificateViewModel;
        }
        public async Task<CertificateDetailsViewModel> GetDetailsViewModel(int id)
        {
            var certificate = await _repository.GetById(id);
            if (certificate == null)
            {
                return null;
            }
            var certificateDetailsViewModel = new CertificateDetailsViewModel
            {
                CertificateDate = certificate.CertificateDate,
                //CertificateType = certificate.CertificateType.Name,
                //DepartmentName = certificate.Department.Name,
                Owner = certificate.Wallet.ApplicationUser.Email,
                Grade = certificate.Grade,
                //UniversityName = certificate.Department.University.Name,
                UniversityUrl = certificate.Department.University.ThumbnailUrl,
                Id = certificate.Id

            };
            return certificateDetailsViewModel;
        }



        public async Task<CertificateEditViewModel> GetEditViewModel(int id)
        {
            var certificate = await _repository.GetById(id);
            
            if (certificate == null)
            {
                return null;
            }

            var certificateEditViewModel = new CertificateEditViewModel()
            {
                Grade = certificate.Grade,
                CertificateDate = certificate.CertificateDate,
                Id = certificate.Id,
                //CertificateType = certificate.CertificateType.Name,
                DepartmentId = certificate.DepartmentId
                
                
            };
            return certificateEditViewModel;
        }


        public async Task<CertificateEditViewModel> UpdateFromEditViewModel(CertificateEditViewModel editViewModel)
        {
            try
            {
                var certificate = await _repository.GetById(editViewModel.Id);
                
                if (certificate == null)
                {
                    return null;
                }

                editViewModel.CertificateDate = certificate.CertificateDate;
                editViewModel.Id = certificate.Id;
                editViewModel.CertificateTypeId = certificate.CertificateTypeId;
                editViewModel.Grade = certificate.Grade;
                    

                _repository.Update(certificate);
                await _repository.Save();
                return editViewModel;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _repository.Exists(editViewModel.Id)))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<CertificateEditViewModel> DeleteFromEditViewModel(CertificateEditViewModel editViewModel)
        {
            var department = await _repository.GetById(editViewModel.Id);
            if (department != null)
            {
                _repository.Delete(department);
            }
            await _repository.Save();
            return editViewModel;
        }
    }
}
