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
    public class ParticipantsController : Controller
    {
        private readonly praktykiv2Context _context;

        public ParticipantsController(praktykiv2Context context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var praktykiv2Context = _context.Participants.Include(p => p.Conversation).Include(p => p.Users);
            return View(await praktykiv2Context.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .Include(p => p.Conversation)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }


        public IActionResult Create()
        {
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "Id", "ChannelId");
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ConversationId,UsersId,Type")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "Id", "ChannelId", participant.ConversationId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail", participant.UsersId);
            return View(participant);
        }

 
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "Id", "ChannelId", participant.ConversationId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail", participant.UsersId);
            return View(participant);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ConversationId,UsersId,Type")] Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.Id))
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
            ViewData["ConversationId"] = new SelectList(_context.Conversations, "Id", "ChannelId", participant.ConversationId);
            ViewData["UsersId"] = new SelectList(_context.Users, "Id", "EMail", participant.UsersId);
            return View(participant);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants
                .Include(p => p.Conversation)
                .Include(p => p.Users)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            _context.Participants.Remove(participant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participants.Any(e => e.Id == id);
        }
    }
}
