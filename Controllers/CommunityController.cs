using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Reddit.Dtos;
using Reddit.Mapper;
using Reddit.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {


        private readonly ApplcationDBContext _context;
        private readonly IMapper _mapper;

        public CommunityController(ApplcationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/<CommunityController>
        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Community>>> GetPosts()
        {
            return await _context.Communities.ToListAsync();
        }





        // GET api/<CommunityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Community>> GetPost(int id)
        {
            var comminity = await _context.Communities.FindAsync(id);

            if (comminity == null)
            {
                return NotFound();
            }

            return comminity;
        }


        // POST api/<CommunityController>
        [HttpPost]
        public async Task<ActionResult<Community>> PostPost(CreateCommunityDTO CreateCommunityDTO)
        {
            var community = _mapper.Tocommunity(CreateCommunityDTO);

            _context.Communities.Add(community);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = community.CommunityId }, community);
        }



        // PUT api/<CommunityController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommunity(int id,  Community community)
        {
            if (id != community.CommunityId)
            {
                return BadRequest();
            }

            _context.Entry(community).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommunityExists(id))
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

        //------------------aqedan



        // DELETE api/<CommunityController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunity(int id)
        {
            var Community = await _context.Communities.FindAsync(id);
            if (Community == null)
            {
                return NotFound();
            }

            _context.Communities.Remove(Community);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool CommunityExists(int id)
        {
            return _context.Communities.Any(e => e.CommunityId == id);
        }
    }
}
