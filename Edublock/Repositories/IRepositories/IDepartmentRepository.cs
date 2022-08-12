using Edublock.Models;
using Edublock.ViewModels;

namespace Edublock.Repositories.IRepositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<DepartmentListViewModel>> GetAllDepartments();
        Task<DepartmentDetailsViewModel>? GetDepartmentById(int? id);
        Department CreateDepartment(DepartmentListViewModel departmentListViewModel);
    }
}
