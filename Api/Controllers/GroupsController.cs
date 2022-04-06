using AutoMapper;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _context;
        

        public GroupsController(AppDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<IActionResult>  GetGroups()
        {
            var groups =await _context.Groups.ToListAsync();

            return Ok(groups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetail(int id)
        {
            var groups = await _context.Groups.FindAsync(id);

            if (groups == null) return NotFound();

            return Ok(groups);
        }
    }
}
