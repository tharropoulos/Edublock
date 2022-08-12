using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edublock.Data;
using Edublock.Models;
using Edublock.Repositories.IRepositories;
using Edublock.ViewModels.CertificateType;
using Edublock.Services;
using Edublock.Services.Interfaces;

namespace Edublock.Controllers
{
    public class CertificateTypesController : Controller
    {
        private readonly ICertificateTypeRepository _repository;
        private readonly ICertificateTypeService _certificateTypeService;
        

        public CertificateTypesController(ICertificateTypeRepository repository, ICertificateTypeService certificateTypeService)
        {
            _repository = repository;
            _certificateTypeService = certificateTypeService;
        }

        // GET: CertificateTypes
        public async Task<IActionResult> Index()
        {
              return View(await _certificateTypeService.ListAllViewModels());
        }

        // GET: CertificateTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateType = await _certificateTypeService.GetDetailsViewModel(id.Value);

            if (certificateType == null)
            {
                return NotFound();
            }

            return View(certificateType);
        }

        // GET: CertificateTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CertificateTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id")] CertificateTypeCreateViewModel certificateType)
        {
            if (ModelState.IsValid)
            {
                await _certificateTypeService.CreateFromViewModel(certificateType);
                return RedirectToAction(nameof(Index));
            }
            return View(certificateType);
        }

        // GET: CertificateTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateType = await _certificateTypeService.GetEditViewModel(id.Value);

            if (certificateType == null)
            {
                return NotFound();
            }
            return View(certificateType);
        }

        // POST: CertificateTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Id")] CertificateTypeEditViewModel certificateTypeEditViewModel)
        {
            if (id != certificateTypeEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _certificateTypeService.UpdateFromEditViewModel(certificateTypeEditViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(certificateTypeEditViewModel);
        }

        // GET: CertificateTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateType = await _certificateTypeService.GetEditViewModel(id.Value);
            if (certificateType == null)
            {
                return NotFound();
            }

            return View(certificateType);
        }

        // POST: CertificateTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CertificateTypeEditViewModel certificateTypeEditViewModel)
        {
            if (id != certificateTypeEditViewModel.Id)
            {
                return NotFound();
            }
            await _certificateTypeService.DeleteFromEditViewModel(certificateTypeEditViewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
