using Edublock.Models;
using Edublock.Repositories.IRepositories;
using Edublock.Services.Interfaces;
using Edublock.ViewModels.University;

namespace Edublock.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository _repository;
        public UniversityService(IUniversityRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateFromViewModel(UniversityCreateViewModel createViewModel)
        {
            var university = new University()
            {
                Name = createViewModel.Name,
                Description = createViewModel.Description 
            };

            _repository.Add(university);
            await _repository.Save();
        }
        public async Task<List<UniversityListViewModel>> ListAllViewModels()
        {
            var univeristyListViewModels = (await _repository.GetAll()).Select(u => new UniversityListViewModel()
            {
                Name = u.Name,
                Description = u.Description,
            }).ToList();
            return univeristyListViewModels;

        }
        public async Task<UniversityDetailsViewModel> GetDetailsViewModel(int id)
        {
            var university = await _repository.GetById(id);
            
            if (university == null)
            {
                return null;
            }

            var universityDetailsViewModel = new UniversityDetailsViewModel()
            {
                Name=university.Name,
                Description=university.Description,
                NumberOfDepartments = university.Departments?.Count ?? 0,
                Id = university.Id
            };
            return universityDetailsViewModel;
        }
        public async Task<UniversityEditViewModel> GetEditViewModel(int id)
        {
            var university = await _repository.GetById(id);
            
            if (university == null)
            {
                return null;
            }
            var universityEditViewModel = new UniversityEditViewModel()
            {
                Name = university.Name,
                Description = university.Description,
                Id = university.Id
            };
            return universityEditViewModel;
        }

        public async Task<UniversityEditViewModel> UpdateFromEditViewModel(UniversityEditViewModel editViewModel)
        {
            try
            {
                var university = await _repository.GetById(editViewModel.Id);

                if (university == null)
                {
                    return null;
                }

                university.Description = editViewModel.Description;
                university.Name = editViewModel.Name;

                _repository.Update(university);
                await _repository.Save();
                return editViewModel;
            }
            catch
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


        public async Task<UniversityEditViewModel> DeleteFromEditViewModel(UniversityEditViewModel editViewModel)
        {
            var university = await _repository.GetById(editViewModel.Id);

            if (university != null)
            {
                _repository.Delete(university);
            }
            await _repository.Save();
            return editViewModel;
        }




    }
}
