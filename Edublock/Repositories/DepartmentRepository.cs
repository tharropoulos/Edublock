using Edublock.Data;
using Edublock.ViewModels;
using Edublock.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Edublock.Models;
using Edublock.ViewModels.Department;
using System.Linq.Expressions;

namespace Edublock.Repositories
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
           
        }

        //public async Task<IEnumerable<DepartmentListViewModel>> GetAllDepartments()
        //{
        //    var dep = await _context.Departments.Include(d => d.University).Include(d => d.Certificates)
        //        .Select(d => new DepartmentListViewModel
        //        {
        //            DepartmentId = d.Id,
        //            DepartmentName = d.Name,
        //            Description = d.Description,
        //            UniversityId = d.UniversityId,
        //            UniversityName = d.University.Name,
        //            NumberOfCertificates = d.Certificates == null ? 0 : d.Certificates.Count
        //        }).ToListAsync();
        //    return dep;
        //}

        //public async Task<DepartmentDetailsViewModel> GetDepartmentById(int? id)
        //{
        //    var dep = await _context.Departments
        //        .Include(d => d.Certificates)
        //        .Where(w => w.Id == id)
        //        .Select(d => new DepartmentDetailsViewModel
        //        {
        //            DepartmentId = d.Id,
        //            DepartmentName = d.Name,
        //            DepartmentDescription = d.Description,
        //            UniversityId = d.UniversityId,
        //            UniversityName = d.University.Name,
        //            Certificates = d.Certificates == null ? new List<CertificateListViewModel>() : d.Certificates
        //                            .Select(c => new CertificateListViewModel
        //                            {
        //                                CertificateId = c.Id,
        //                                CertificateDate = c.CertificateDate,
        //                                CertificateType = c.CertificateType.Name,
        //                                DepartmentName = c.Department.Name
        //                            }).ToList()
        //        }).FirstOrDefaultAsync();
        //    return dep;
        //}

        //public Department CreateDepartment(DepartmentListViewModel departmentListViewModel)
        //{
        //    var department = new Department()
        //    {
        //        Id = departmentListViewModel.DepartmentId,
        //        Name = departmentListViewModel.DepartmentName,
        //        Description = departmentListViewModel.Description,
        //        UniversityId = departmentListViewModel.UniversityId,
        //        //University.Univ = departmentListViewModel.UniversityName

        //    };
        //    return department;

        //}

        //public Task<Department> GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Department>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(Department entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Department entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(Department entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<Department> GetQuery()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task Save()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> Exists(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public IQueryable<Department> GetQueryWithPredicate(Expression<Func<Department, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        ////public Department EditDepartment(int id, EditDepartmentViewModel editDepartmentViewModel)
        ////{
        ////    var department = UpdateModel
        ////}


    }
}
