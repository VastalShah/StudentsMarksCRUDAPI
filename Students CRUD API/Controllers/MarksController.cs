using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly MyContext _context;

        public MarksController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Marks.ToListAsync());
        }

        [HttpGet("GetMarks/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            List<MarksModel> studentMark = await _context.Marks.ToListAsync();
            studentMark = studentMark.Where(s => s.Student_ID == id).ToList();
            return Ok(studentMark);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MarksModel marksModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marksModel);
                await _context.SaveChangesAsync();
                return Ok("Added Student Marks Succesfully");
            }
            return BadRequest("Can't Perform operation");
        }

        [HttpPut]
        public async Task<IActionResult> Update(MarksModel marksModel)
        {
            List<MarksModel> marks = await _context.Marks.ToListAsync();
            marks = marks.Where(m => m.Student_ID == marksModel.Student_ID && m.Subject_ID == marksModel.Subject_ID).ToList();
            if(marks.Count != 0)
            {
                marks[0].Student_Marks = marksModel.Student_Marks;

                _context.Update(marks[0]);
                await _context.SaveChangesAsync();

                return Ok(marks);
            }
            return BadRequest("No Data Found");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(MarksModel marksModel)
        {
            List<MarksModel> marks = await _context.Marks.ToListAsync();
            marks = marks.Where(m => m.Student_ID == marksModel.Student_ID && m.Subject_ID == marksModel.Subject_ID).ToList();
            if(marks.Count != 0)
            {
                _context.Marks.Remove(marks[0]);
                await _context.SaveChangesAsync();
                return Ok("Deleted record Succesfully");
            }
            return BadRequest("No such data found");
        }
    }
}
