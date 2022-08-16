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
using Edublock.Repositories.Interfaces;
using Edublock.ViewModels.Department;
using Edublock.Services.Interfaces;

namespace Edublock.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ApplicationDbContext _context;

        public DepartmentsController(IDepartmentService departmentService, ApplicationDbContext context)
        {
            _departmentService = departmentService;
            _context = context;
        }



        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var departmentListViewModel = await _departmentService.ListAllViewModels();
            return View(departmentListViewModel);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentDetailsViewModel = await _departmentService.GetDetailsViewModel(id.Value);
            if (departmentDetailsViewModel == null)
            {
                return NotFound();
            }

            return View(departmentDetailsViewModel);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(_context.Universities, nameof(University.Id), nameof(University.Name));
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,UniversityId")] DepartmentCreateViewModel department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.CreateFromViewModel(department);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, nameof(University.Id), nameof(University.Name), department.UniversityId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetEditViewModel(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, nameof(University.Id), nameof(University.Name), department.UniversityId);
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,UniversityId")] DepartmentEditViewModel department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _departmentService.UpdateFromEditVieModel(department);
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, nameof(University.Id), nameof(University.Name), department.UniversityId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetEditViewModel(id.Value);
            

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, DepartmentEditViewModel editviewModel)
        { 
            if (id != editviewModel.Id)
            {
                return NotFound();
            }
            await _departmentService.DeleteFromEditViewModel(editviewModel);
            return RedirectToAction(nameof(Index));
        }


    }
}
