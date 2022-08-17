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
                    CertificateDate = createViewModel.CertificateDate,
                    DepartmentId = createViewModel.DepartmentId,
                    Grade = createViewModel.Grade,
                    WalletId = createViewModel.WalletId,
                    CertificateTypeId = createViewModel.CertificateTypeId
            };
            _repository.Add(certificate);
            await _repository.Save();
        }
        public async Task<List<CertificateListViewModel>> ListAllViewModels()
        {
           var certificateViewModel = await _repository.GetQuery().Include(c => c.Department).Include(c => c.Department.University).Include(c => c.Wallet.ApplicationUser).Select(c => new CertificateListViewModel
            {
                CertificateDate = c.CertificateDate,
                DepartmentName = c.Department.Name,
                UniversityName = c.Department.University.Name,
                User = c.Wallet.ApplicationUser.Email,
                Id = c.Id
            }).ToListAsync();
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
                Department  = certificate.Department.Name,
                University = certificate.Department.University.Name,
                CertificateDate = certificate.CertificateDate,
                Id = certificate.Id,
                CertificateType = certificate.CertificateType.Name,
                Owner = certificate.Wallet.ApplicationUser.Email,
                Grade = certificate.Grade
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
                CertificateTypeId = certificate.CertificateTypeId,
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

                certificate.Grade = editViewModel.Grade;
                certificate.CertificateDate = editViewModel.CertificateDate;
                certificate.CertificateTypeId = editViewModel.CertificateTypeId;
                certificate.DepartmentId = editViewModel.DepartmentId;
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
