using Edublock.Models;
using Edublock.Repositories.Interfaces;
using Edublock.Services.Interfaces;
using Edublock.ViewModels.CertificateType;
using Microsoft.EntityFrameworkCore;

namespace Edublock.Services
{
    public class CertificateTypeService : ICertificateTypeService
    {
        private readonly ICertificateTypeRepository _repository;
        public CertificateTypeService(ICertificateTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateFromViewModel(CertificateTypeCreateViewModel createViewModel)
        {
            var CertificateType = new CertificateType
            {
                Name = createViewModel.Name,
                Description = createViewModel.Description
            };

            _repository.Add(CertificateType);
            await _repository.Save();
        }

        public async Task<List<CertificateTypeListViewModel>> ListAllViewModels()
        {

            var certificateTypeListViewModels = (await _repository.GetAll()).Select(ct => new CertificateTypeListViewModel
            {
                Name = ct.Name,
                Description = ct.Description,
                Id = ct.Id
            }).ToList();
            return certificateTypeListViewModels;
        }

        public async Task<CertificateTypeDetailsViewModel> GetDetailsViewModel(int id)
        {
            var certificateType = await _repository.GetById(id);

            if (certificateType == null)
            {
                return null;
            }

            var certificateTypeDetailsViewModel = new CertificateTypeDetailsViewModel
            {
                Name = certificateType.Name,
                Description = certificateType.Description,
                NumberOfCertificates = certificateType.Certificates?.Count ?? 0,
                Id = certificateType.Id
            };
            return certificateTypeDetailsViewModel;
        }

        public async Task<CertificateTypeEditViewModel> GetEditViewModel(int id)
        {
            var certificateType = await _repository.GetById(id);

            if (certificateType == null)
            {
                return null;
            }

            var certificateTypeEditViewModel = new CertificateTypeEditViewModel
            {
                Name = certificateType.Name,
                Description = certificateType.Description,
                Id = certificateType.Id
            };
            return certificateTypeEditViewModel;
        }

        public async Task<CertificateTypeEditViewModel> UpdateFromEditViewModel(CertificateTypeEditViewModel certificateTypeEditViewModel)
        {
            try
            {
                var certificateType = await _repository.GetById(certificateTypeEditViewModel.Id);
                
                if (certificateType == null)
                {
                    return null;
                }

                certificateType.Description = certificateTypeEditViewModel.Description;
                certificateType.Name = certificateTypeEditViewModel.Name;

                _repository.Update(certificateType);
                await _repository.Save();
                return certificateTypeEditViewModel;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _repository.Exists(certificateTypeEditViewModel.Id)))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<CertificateTypeEditViewModel> DeleteFromEditViewModel(CertificateTypeEditViewModel certificateTypeEditViewModel)
        {
            var certificateType = await _repository.GetById(certificateTypeEditViewModel.Id);
            if (certificateType != null)
            {
                _repository.Delete(certificateType);
            }
            await _repository.Save();
            return certificateTypeEditViewModel;
        }

    }
}
