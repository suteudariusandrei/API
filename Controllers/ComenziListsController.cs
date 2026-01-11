using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Restaurant.Data;
using API_Restaurant.Models;

namespace API_Restaurant.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComenziListsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ComenziListsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/ComenziLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComenziList>>> GetComenziList()
        {
            return await _context.ComenziList.ToListAsync();
        }

        // GET: api/ComenziLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComenziList>> GetComenziList(int id)
        {
            var comenziList = await _context.ComenziList.FindAsync(id);

            if (comenziList == null)
            {
                return NotFound();
            }

            return comenziList;
        }

        // PUT: api/ComenziLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComenziList(int id, ComenziList comenziList)
        {
            if (id != comenziList.ID)
            {
                return BadRequest();
            }

            _context.Entry(comenziList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComenziListExists(id))
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

        // POST: api/ComenziLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComenziList>> PostComenziList(ComenziList comenziList)
        {
            _context.ComenziList.Add(comenziList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComenziList", new { id = comenziList.ID }, comenziList);
        }

        // DELETE: api/ComenziLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComenziList(int id)
        {
            var comenziList = await _context.ComenziList.FindAsync(id);
            if (comenziList == null)
            {
                return NotFound();
            }

            _context.ComenziList.Remove(comenziList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComenziListExists(int id)
        {
            return _context.ComenziList.Any(e => e.ID == id);
        }
    }
}
