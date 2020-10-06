using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRepositoryPattern.Domain;
using TestRepositoryPattern.Models;

namespace TestRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferralStatesController : ControllerBase
    {
        private readonly PatientDataContext _context;

        public ReferralStatesController(PatientDataContext context)
        {
            _context = context;
        }

        // GET: api/ReferralStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReferralState>>> GetReferralStates()
        {
            return await _context.ReferralStates.ToListAsync();
        }

        // GET: api/ReferralStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReferralState>> GetReferralState(string id)
        {
            var referralState = await _context.ReferralStates.FindAsync(id);

            if (referralState == null)
            {
                return NotFound();
            }

            return referralState;
        }

        // PUT: api/ReferralStates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReferralState(string id, ReferralState referralState)
        {
            if (id != referralState.ReferralId)
            {
                return BadRequest();
            }

            _context.Entry(referralState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferralStateExists(id))
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

        // POST: api/ReferralStates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ReferralState>> PostReferralState(ReferralState referralState)
        {
            _context.ReferralStates.Add(referralState);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReferralStateExists(referralState.ReferralId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReferralState", new { id = referralState.ReferralId }, referralState);
        }

        // DELETE: api/ReferralStates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReferralState>> DeleteReferralState(string id)
        {
            var referralState = await _context.ReferralStates.FindAsync(id);
            if (referralState == null)
            {
                return NotFound();
            }

            _context.ReferralStates.Remove(referralState);
            await _context.SaveChangesAsync();

            return referralState;
        }

        private bool ReferralStateExists(string id)
        {
            return _context.ReferralStates.Any(e => e.ReferralId == id);
        }
    }
}
