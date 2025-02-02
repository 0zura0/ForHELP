﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Reddit.Dtos;
using Reddit.Mapper;
using Reddit.Models;
using Reddit.Repositories;
using Reddit.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reddit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {


        private readonly ApplcationDBContext _context;
        private readonly IMapper _mapper;
        private readonly ICommunityRepository _communityRepository;


        public CommunityController(ApplcationDBContext context, IMapper mapper, ICommunityRepository communityRepository)
        {
            _context = context;
            _mapper = mapper;
            _communityRepository = communityRepository;

        }


        // GET: api/<CommunityController>
        [HttpGet]
        public async Task<IEnumerable<string>> GetCommunity(GetPostsRequest getPostsRequest)
        {
            //await Console.Out.WriteLineAsync(_communityRepository.ToString());
            var pL = await _communityRepository.GetAll(getPostsRequest);
            
            return pL.Items.Select(p => p.Name);
        }


        // GET api/<CommunityController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Community>> GetCommunity(int id)
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
        public async Task<ActionResult<Community>> PostCommunity(CreateCommunityDTO CreateCommunityDTO)
        {
            var community = _mapper.Tocommunity(CreateCommunityDTO);

            await _context.Communities.AddAsync(community);
            await _context.SaveChangesAsync();

            Console.Out.WriteLineAsync("here is psot Community brooooooooooooooooooooooooo ");

            return CreatedAtAction("PostCommunity", new { id = community.CommunityId }, community);
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
