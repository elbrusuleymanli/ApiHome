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
    }
}
