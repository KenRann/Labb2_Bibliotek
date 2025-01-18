using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Labb2_Bibliotek.Classes;
using Labb2_Bibliotek.Models;
using Labb2_Bibliotek.DTOs;

namespace Labb2_Bibliotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MembersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDTO>>> GetMember()
        {
            var member = await _context.Member.ToListAsync();

            var memberDto = member.Select(m => m.ToMemberDto()).ToList();
            return memberDto;
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDTO>> GetMember(int id)
        {
            var member = await _context.Member.FindAsync(id);
            
            if (member == null)
            {
                return NotFound();
            }

            var memberDto = member.ToMemberDto();

            return memberDto;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(int id, Member member)
        {
            if (id != member.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(CreateMemberDTO createMemberDto)
        {
            var member = createMemberDto.ToMember();
            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMember", new { id = member.MemberId }, member.ToMemberDto());
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Member.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.MemberId == id);
        }
    }
}
