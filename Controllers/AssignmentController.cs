using Microsoft.AspNetCore.Mvc;
using AssignmentHelpers.Data;
using AssignmentHelpers.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentHelpers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : Controller
    {
        private readonly DataContext Assignmentdata;
        public AssignmentController(DataContext data)
        {
            this.Assignmentdata = data;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAssigment()
        {
            var assignment = await Assignmentdata.assignments.ToListAsync();
            return Ok(Assignmentdata);
        }
        [Route("{id:int}")]
        [ActionName("GetAssigment")]
        [HttpGet]
        public async Task<IActionResult> GetAssigment([FromRoute] int id)
        {
            //Firstordefault will return null value if criteria not mean and first will throw exception
            var assignment = await Assignmentdata.assignments.FirstOrDefaultAsync(x => x.Id == id);
            if(assignment==null)
            {
                return NotFound(" No Assignment");
            }
            return Ok(Assignmentdata);
        }

        [HttpPost]
        public async Task<IActionResult> AddAssignment([FromBody] assignment assignment )
        {
            assignment.Id = 2;
            await Assignmentdata.assignments.AddAsync(assignment);
            await Assignmentdata.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAssigment),assignment);

        }
    }
}
