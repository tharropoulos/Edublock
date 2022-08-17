using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Edublock.Data;
using Edublock.Models;
using Edublock.ViewModels.Certificate;
using Edublock.Services.Interfaces;

namespace Edublock.Controllers
{
    public class CertificatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICertificateService _certificateService;


        public CertificatesController(ICertificateService certificateService, ApplicationDbContext context)
        {
            _certificateService = certificateService;
            _context = context;
        }

        // GET: Certificates
        public async Task<IActionResult> Index()
        {
            var certificateListViewModel = await _certificateService.ListAllViewModels();
            return View(certificateListViewModel);
        }

        // GET: Certificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _certificateService.GetDetailsViewModel(id.Value);
            ;
            
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // GET: Certificates/Create
        public IActionResult Create()

        {
            ViewData["WalletId"] = new SelectList(_context.Wallets, nameof(Wallet.Id), nameof(Wallet.ApplicationUser.Email));
            ViewData["DepartmentId"] = new SelectList(_context.Departments, nameof(Department.Id), nameof(Department.Name));
            ViewData["CertificateTypeId"] = new SelectList(_context.CertificateTypes, nameof(CertificateType.Id), nameof(CertificateType.Name));
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificateTypeId,DepartmentId,Grade,WalletId,Grade, CertificateDate")] CertificateCreateViewModel certificate)
        {
            if (ModelState.IsValid)
            {
               await _certificateService.CreateFromViewModel(certificate);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, nameof(Department.Id), nameof(Department.Name), certificate.DepartmentId);
            ViewData["CertificateTypeId"] = new SelectList(_context.CertificateTypes, nameof(CertificateType.Id), nameof(CertificateType.Name), certificate.CertificateTypeId);
            //ViewData["WalletId"] = new SelectList(_context.Wallets, "WalletId", nameof(Wallet.ApplicationUser.LastName), certificate.WalletId);
            return View(certificate);
        }

        // GET: Certificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _certificateService.GetEditViewModel(id.Value);
            if (certificate == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, nameof(Department.Id), nameof(Department.Name), certificate.DepartmentId);
            ViewData["TypeOfCertificateId"] = new SelectList(_context.CertificateTypes, nameof(CertificateType.Id), nameof(CertificateType.Name), certificate.CertificateTypeId);
            ViewData["WalletId"] = new SelectList(_context.Wallets, "WalletId", "WalletId", certificate.WalletId);
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grade,DepartmentId,CertificateTypeId,Grade")] CertificateEditViewModel certificate)
        {
            if (id != certificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _certificateService.UpdateFromEditViewModel(certificate);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", certificate.DepartmentId);
            ViewData["TypeOfCertificateId"] = new SelectList(_context.CertificateTypes, "TypeOfCertificateId", "TypeOfCertificateId", certificate.CertificateTypeId);
            ViewData["WalletId"] = new SelectList(_context.Wallets, "WalletId", "WalletId", certificate.WalletId);
            return View(certificate);
        }

        // GET: Certificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Certificates == null)
            {
                return NotFound();
            }

            var certificate = await _certificateService.GetEditViewModel(id.Value);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CertificateEditViewModel certificate)
        {
            if (_context.Certificates == null)
            {
                return NotFound();
            }
            await _certificateService.DeleteFromEditViewModel(certificate);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
