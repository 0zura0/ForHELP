using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reddit.Dtos;
using Reddit.Mapper;
using Reddit.Models;

namespace Reddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplcationDBContext _context;

        public UserController(ApplcationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateUserDto createAuthorDto)
        {
            var author = new User
            {
                Name = createAuthorDto.Name
            };

            await _context.Users.AddAsync(author);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAuthors()
        {
            return await _context.Users.ToListAsync();
        }



        [HttpPost("JoinCommunity/{UserId}/{Comunityid}")]
        public async Task<ActionResult<User>> JoinCommunity(int UserId, int Comunityid)
        {
            var user = await _context.Users.FindAsync(UserId);
            var community = await _context.Communities.FindAsync(Comunityid);
            await Console.Out.WriteLineAsync("hiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
            await Console.Out.WriteLineAsync(user.Name);
            await Console.Out.WriteLineAsync(community.CommunityId.ToString());
            if (community == null || user == null)
            {
                return NotFound();
            }
            if (UserId == community.OwnerId)
            {
                return BadRequest();
            }

            community.UserSubscribers.Add(user);
            _context.SaveChanges();

            return user;
        }

    }
}