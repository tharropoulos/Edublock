using Edublock.Data;
using Edublock.ViewModels;
using Edublock.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Edublock.Models;
using Edublock.ViewModels.Department;

namespace Edublock.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentListViewModel>> GetAllDepartments()
        {
            var dep = await _context.Departments.Include(d => d.University).Include(d => d.Certificates)
                .Select(d => new DepartmentListViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                    Description = d.DepartmentDescription,
                    UniversityId = d.UniversityId,
                    UniversityName = d.University.UniversityName,
                    NumberOfCertificates = d.Certificates == null ? 0 : d.Certificates.Count
                }).ToListAsync();
            return dep;
        }

        public async Task<DepartmentDetailsViewModel> GetDepartmentById(int? id)
        {
            var dep = await _context.Departments
                .Include(d => d.Certificates)
                .Where(w => w.DepartmentId == id)
                .Select(d => new DepartmentDetailsViewModel
                {
                    DepartmentId = d.DepartmentId,
                    DepartmentName = d.DepartmentName,
                    DepartmentDescription = d.DepartmentDescription,
                    UniversityId = d.UniversityId,
                    UniversityName = d.University.UniversityName,
                    Certificates = d.Certificates == null ? new List<CertificateListViewModel>() : d.Certificates
                                    .Select(c => new CertificateListViewModel
                                    {
                                        CertificateId = c.CertificateId,
                                        CertificateDate = c.CertificateDate,
                                        CertificateType = c.TypeOfCertificate.TypeOfCertificateName,
                                        DepartmentName = c.Department.DepartmentName
                                    }).ToList()
                }).FirstOrDefaultAsync();
            return dep;
        }

        public Department CreateDepartment(DepartmentListViewModel departmentListViewModel)
        {
            var department = new Department()
            {
                DepartmentId = departmentListViewModel.DepartmentId,
                DepartmentName = departmentListViewModel.DepartmentName,
                DepartmentDescription = departmentListViewModel.Description,
                UniversityId = departmentListViewModel.UniversityId,
                //University.Univ = departmentListViewModel.UniversityName

            };
            return department;

        }

        //public Department EditDepartment(int id, EditDepartmentViewModel editDepartmentViewModel)
        //{
        //    var department = UpdateModel
        //}


    }
}
