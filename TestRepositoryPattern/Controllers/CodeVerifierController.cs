using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestRepositoryPattern.Domain;
using TestRepositoryPattern.Models;

namespace TestRepositoryPattern.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     public class CodeVerifierController : ControllerBase
     {
          private readonly IRepositoryWrapper _repository;

          public CodeVerifierController(IRepositoryWrapper repository)
          {
               _repository = repository;
          }

          // GET: api/CodeVerifier
          [HttpGet]
          public async Task<ActionResult<IEnumerable<CodeVerifier>>> GetCodeVerifiers()
          {
               return (await _repository.codeVerifierRepository.GetAll()).ToList();
          }

          // GET: api/CodeVerifier/5
          [HttpGet("{id}")]
          public async Task<ActionResult<CodeVerifier>> GetCodeVerifier(string id)
          {
               var codeVerifier = await _repository.codeVerifierRepository.Get(id);

               if (codeVerifier == null)
               {
                    return NotFound();
               }

               return codeVerifier;
          }

          // PUT: api/CodeVerifier/5
          // To protect from overposting attacks, enable the specific properties you want to bind to, for
          // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
          [HttpPut("{id}")]
          public async Task<IActionResult> PutCodeVerifier(string id, CodeVerifier codeVerifier)
          {
               if (id != codeVerifier.RequestId)
               {
                    return BadRequest();
               }

               try
               {
                    await _repository.codeVerifierRepository.Update(codeVerifier);
               }
               catch (DbUpdateConcurrencyException)
               {
                    if (!await CodeVerifierExists(id))
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

          // POST: api/CodeVerifier
          // To protect from overposting attacks, enable the specific properties you want to bind to, for
          // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
          [HttpPost]
          public async Task<ActionResult<CodeVerifier>> PostCodeVerifier(CodeVerifier codeVerifier)
          {
               try
               {
                    await _repository.codeVerifierRepository.Add(codeVerifier);
               }
               catch (DbUpdateException)
               {
                    if (await CodeVerifierExists(codeVerifier.RequestId))
                    {
                         return Conflict();
                    }
                    else
                    {
                         throw;
                    }
               }

               return CreatedAtAction("GetCodeVerifier", new { id = codeVerifier.RequestId }, codeVerifier);
          }

          // DELETE: api/CodeVerifier/5
          [HttpDelete("{id}")]
          public async Task<ActionResult<CodeVerifier>> DeleteCodeVerifier(string id)
          {
               var codeVerifier = await _repository.codeVerifierRepository.Get(id);
               if (codeVerifier == null)
               {
                    return NotFound();
               }

               await _repository.codeVerifierRepository.Delete(codeVerifier.RequestId);

               return codeVerifier;
          }

          private async Task<bool> CodeVerifierExists(string id)
          {
               return (await _repository.codeVerifierRepository.GetAll()).Any(e => e.RequestId == id);
          }
     }
}
