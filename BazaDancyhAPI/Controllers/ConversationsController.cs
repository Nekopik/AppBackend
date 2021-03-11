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
    public class ConversationsController : Controller
    {
        private readonly praktykiv2Context _context;

        public ConversationsController(praktykiv2Context context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            var praktykiv2Context = _context.Conversations.Include(c => c.Creator);
            return View(await praktykiv2Context.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversation = await _context.Conversations
                .Include(c => c.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conversation == null)
            {
                return NotFound();
            }

            return View(conversation);
        }

      
        public IActionResult Create()
        {
            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "EMail");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,CreatorId,ChannelId,CreateDate")] Conversation conversation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conversation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "EMail", conversation.CreatorId);
            return View(conversation);
        }

   
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversation = await _context.Conversations.FindAsync(id);
            if (conversation == null)
            {
                return NotFound();
            }
            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "EMail", conversation.CreatorId);
            return View(conversation);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,CreatorId,ChannelId,CreateDate")] Conversation conversation)
        {
            if (id != conversation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conversation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConversationExists(conversation.Id))
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
            ViewData["CreatorId"] = new SelectList(_context.Users, "Id", "EMail", conversation.CreatorId);
            return View(conversation);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conversation = await _context.Conversations
                .Include(c => c.Creator)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (conversation == null)
            {
                return NotFound();
            }

            return View(conversation);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conversation = await _context.Conversations.FindAsync(id);
            _context.Conversations.Remove(conversation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConversationExists(int id)
        {
            return _context.Conversations.Any(e => e.Id == id);
        }
    }
}
