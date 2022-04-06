using AutoMapper;
using Data;
using Domain.Dtos;
using Domain.Models;
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


    public class StudentsController : ControllerBase

    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _context.Set<Student>().Include(s=>s.Group).ToListAsync();

           List<StudentDto> studentDtos = _mapper.Map<List<StudentDto>>(students);

            return Ok(studentDtos);
        }

        [HttpGet ("{id}")]

        public async Task<IActionResult> Detail ([FromRoute]int id)
        {
            var detailStudent =await _context.Students.FindAsync(id);
            if (detailStudent == null) return NotFound();

            return Ok(_mapper.Map<StudentDto>(detailStudent));
        }
       
    }
}

