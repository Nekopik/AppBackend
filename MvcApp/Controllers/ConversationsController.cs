﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace MvcApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly praktykiv2Context _context;

        public ConversationsController(praktykiv2Context context)
        {
            _context = context;
        }

        // GET: api/Conversations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conversation>>> GetConversations()
        {
            return await _context.Conversations.ToListAsync();
        }

        // GET: api/Conversations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conversation>> GetConversation(int id)
        {
            var conversation = await _context.Conversations.FindAsync(id);

            if (conversation == null)
            {
                return NotFound();
            }

            return conversation;
        }

        // PUT: api/Conversations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConversation(int id, Conversation conversation)
        {
            if (id != conversation.Id)
            {
                return BadRequest();
            }

            _context.Entry(conversation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConversationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Conversations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Conversation>> PostConversation(Conversation conversation)
        {
            _context.Conversations.Add(conversation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ConversationExists(conversation.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetConversation", new { id = conversation.Id }, conversation);
        }

        // DELETE: api/Conversations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Conversation>> DeleteConversation(int id)
        {
            var conversation = await _context.Conversations.FindAsync(id);
            if (conversation == null)
            {
                return NotFound();
            }

            _context.Conversations.Remove(conversation);
            await _context.SaveChangesAsync();

            return conversation;
        }

        private bool ConversationExists(int id)
        {
            return _context.Conversations.Any(e => e.Id == id);
        }
    }
}
