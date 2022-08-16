using Edublock.Models;
using Edublock.Repositories.IRepositories;
using Edublock.Services.Interfaces;
using Edublock.ViewModels.Department;
using Microsoft.EntityFrameworkCore;
namespace Edublock.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateFromViewModel(DepartmentCreateViewModel createViewModel)
        {
            var department = new Department
            {
                Name = createViewModel.Name,
                Description = createViewModel.Description,
                UniversityId = createViewModel.UniversityId,
            };
            _repository.Add(department);
            await _repository.Save();
        }

        public async Task<DepartmentDetailsViewModel> GetDetailsViewModel(int id)
        {
            var department = await _repository.GetById(id);
            if (department == null)
            {
                return null;
            }

            var departmentDetailsViewModel = new DepartmentDetailsViewModel
            {
                Name = department.Name,
                Description = department.Description,
                Id = department.Id,
                UniversityName = department.University.Name
            };
            return departmentDetailsViewModel;
        }
        public async Task<List<DepartmentListViewModel>> ListAllViewModels()
        {
            var departmentList =  await _repository.GetQuery().Include(d => d.University).Select(d => new DepartmentListViewModel
            {
                Name = d.Name,
                Description = d.Description,
                Id = d.Id,
                UniversityName = d.University.Name
            }).ToListAsync();
            return departmentList;
        }

        public async Task<DepartmentEditViewModel> GetEditViewModel(int id)
        {
            var department = await _repository.GetById(id);

            if (department == null)
            {
                return null;
            }

            var departmentEditViewModel = new DepartmentEditViewModel()
            {
                Name= department.Name,
                Id = department.Id,
                Description = department.Description,
                UniversityId= department.UniversityId
            };
            return departmentEditViewModel;
        }


        public async Task<DepartmentEditViewModel> UpdateFromEditVieModel(DepartmentEditViewModel editViewModel)
        {
            try
            {
                var department = await _repository.GetById(editViewModel.Id);

                if (department == null)
                {
                    return null;
                }
                department.Name = editViewModel.Name;
                department.Description = editViewModel.Description;

                _repository.Update(department);
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

        public async Task<DepartmentEditViewModel> DeleteFromEditViewModel(DepartmentEditViewModel editViewModel)
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
