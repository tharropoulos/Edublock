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

namespace Edublock.Controllers
{
    public class CertificatesController : Controller
    {
        private readonly ApplicationDbContext _context;


        public CertificatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Certificates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Certificates.Include(c => c.Department).Include(c => c.TypeOfCertificate).Include(c => c.Wallet);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Certificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Certificates == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates
                .Include(c => c.Department)
                .Include(c => c.TypeOfCertificate)
                .Include(c => c.Wallet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // GET: Certificates/Create
        public IActionResult Create()
       
        {
            ViewData["UserId"] = new SelectList(_context.Users, nameof(ApplicationUser.Id), nameof(ApplicationUser.Email));
            ViewData["DepartmentId"] = new SelectList(_context.Departments, nameof(Department.Id), nameof(Department.Name));
            ViewData["TypeOfCertificateId"] = new SelectList(_context.TypeOfCertificates, nameof(TypeOfCertificate.Id), nameof(TypeOfCertificate.Name));
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfCertificateId,UserId,DepartmentId,CertificateDate,Grade")] CreateCertificateViewModel certificate)
        {
            if (ModelState.IsValid)
            {
                // Find the wallet through the owner, because I don't save in owner/users but wallets.
                var user = await _context.Users.FindAsync(certificate.UserId);
                var walletId = user.WalletId;
                var dbCertificate = new Certificate
                {
                    DepartmentId = certificate.DepartmentId,
                    TypeOfCertificateId = certificate.TypeOfCertificateId,
                    WalletId = walletId ?? 0,
                    Grade = certificate.Grade,
                    CertificateDate = certificate.CertificateDate.ToDateTime(TimeOnly.MinValue),
                };
                _context.Add(certificate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, nameof(Department.Id), nameof(Department.Name), certificate.DepartmentId);
            ViewData["TypeOfCertificateId"] = new SelectList(_context.TypeOfCertificates, nameof(TypeOfCertificate.Id), nameof(TypeOfCertificate.Name), certificate.TypeOfCertificateId);
            //ViewData["WalletId"] = new SelectList(_context.Wallets, "WalletId", nameof(Wallet.ApplicationUser.LastName), certificate.WalletId);
            return View(certificate);
        }

        // GET: Certificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Certificates == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", certificate.DepartmentId);
            ViewData["TypeOfCertificateId"] = new SelectList(_context.TypeOfCertificates, "TypeOfCertificateId", "TypeOfCertificateId", certificate.TypeOfCertificateId);
            ViewData["WalletId"] = new SelectList(_context.Wallets, "WalletId", "WalletId", certificate.WalletId);
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificateId,TypeOfCertificateId,WalletId,DepartmentId,CertificateDate,Grade")] Certificate certificate)
        {
            if (id != certificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateExists(certificate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", certificate.DepartmentId);
            ViewData["TypeOfCertificateId"] = new SelectList(_context.TypeOfCertificates, "TypeOfCertificateId", "TypeOfCertificateId", certificate.TypeOfCertificateId);
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

            var certificate = await _context.Certificates
                .Include(c => c.Department)
                .Include(c => c.TypeOfCertificate)
                .Include(c => c.Wallet)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Certificates == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Certificates'  is null.");
            }
            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate != null)
            {
                _context.Certificates.Remove(certificate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateExists(int id)
        {
          return (_context.Certificates?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
