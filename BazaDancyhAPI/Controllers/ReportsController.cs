using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BazaDancyhAPI.Models;

namespace BazaDancyhAPI.Controllers
{
    public class ReportsController : Controller
    {
        private readonly praktykiv2Context _context;

        public ReportsController(praktykiv2Context context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var praktykiv2Context = _context.Reports.Include(r => r.Participants).Include(r => r.Users);
            return View(await praktykiv2Context.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .Include(r => r.Participants)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }


        public IActionResult Create()
        {
            ViewData["ParticipantsId"] = new SelectList(_context.Participants, "Id", "Type");
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsersId,ParticipantsId,ReportType,Notes,CreateDate")] Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParticipantsId"] = new SelectList(_context.Participants, "Id", "Type", report.ParticipantsId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail", report.UsersId);
            return View(report);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            ViewData["ParticipantsId"] = new SelectList(_context.Participants, "Id", "Type", report.ParticipantsId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail", report.UsersId);
            return View(report);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsersId,ParticipantsId,ReportType,Notes,CreateDate")] Report report)
        {
            if (id != report.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(report);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportExists(report.Id))
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
            ViewData["ParticipantsId"] = new SelectList(_context.Participants, "Id", "Type", report.ParticipantsId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail", report.UsersId);
            return View(report);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Reports
                .Include(r => r.Participants)
                .Include(r => r.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }

            return View(report);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportExists(int id)
        {
            return _context.Reports.Any(e => e.Id == id);
        }
    }
}
