using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edublock.Data;
using Edublock.Models;
using Edublock.ViewModels.University;
using Edublock.Services.Interfaces;

namespace Edublock.Controllers
{
    public class UniversitiesController : Controller
    {
        private readonly IUniversityService _universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        // GET: Universities
        public async Task<IActionResult> Index()
        {
              return View(await _universityService.ListAllViewModels());
        }

        // GET: Universities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _universityService.GetDetailsViewModel(id.Value);

            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // GET: Universities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ThumbnailUrl")] UniversityCreateViewModel university)
        {
            if (ModelState.IsValid)
            {
                await _universityService.CreateFromViewModel(university);
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }

        // GET: Universities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if ((id ?? 0) == 0)
            {
                return NotFound();
            }

            var university = await _universityService.GetEditViewModel(id.Value);
            if (university == null)
            {
                return NotFound();
            }
            return View(university);
        }

        // POST: Universities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ThumbnailUrl")] UniversityEditViewModel university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _universityService.UpdateFromEditViewModel(university);
                return RedirectToAction(nameof(Index));
            }
            return View(university);
        }

        // GET: Universities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _universityService.GetEditViewModel(id.Value);

            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: Universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, UniversityEditViewModel university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }
            await _universityService.DeleteFromEditViewModel(university);
            return RedirectToAction(nameof(Index));
        }
    }
}
