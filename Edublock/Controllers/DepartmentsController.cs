using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edublock.Data;
using Edublock.Models;
using Edublock.ViewModels;
using Edublock.Repositories.IRepositories;
using Edublock.ViewModels.Department;

namespace Edublock.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(ApplicationDbContext context, IDepartmentRepository departmentRepository)
        {
            _context = context;
            _departmentRepository = departmentRepository;
        }


        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var departmentListViewModel = _departmentRepository.GetAllDepartments();
            return View(await departmentListViewModel);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var departmentDetailsViewModel = _departmentRepository.GetDepartmentById(id);
            if (departmentDetailsViewModel == null)
            {
                return NotFound();
            }

            return View(await departmentDetailsViewModel);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(_context.Universities, nameof(University.Id), nameof(University.Name));
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName,DepartmentDescription,UniversityId")] CreateDepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var dbDepartment = new Department
                {
                    Name = department.DepartmentName,
                    Description = department.DepartmentDescription,
                    UniversityId = department.UniversityId,
                };

                _context.Add(dbDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "UniversityId", "UniversityId", department.UniversityId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, nameof(University.Id), nameof(University.Name), department.UniversityId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepartmentId,DepartmentName,DepartmentDescription,UniversityId")] EditDepartmentViewModel department)
        {
            if (id != department.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dbDepartment = _context.Departments.Find(id);
                dbDepartment.Name = department.DepartmentName;
                dbDepartment.Description = department.DepartmentDescription;
                dbDepartment.UniversityId = department.UniversityId;
                _context.Entry(dbDepartment).State = EntityState.Modified;
                _context.SaveChanges();
                //try
                //{
                //    _context.Update(department);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!DepartmentExists(department.DepartmentId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, nameof(University.Id), nameof(University.Name), department.UniversityId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Departments == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.University)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Departments'  is null.");
            }
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(int id)
        {
          return (_context.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
