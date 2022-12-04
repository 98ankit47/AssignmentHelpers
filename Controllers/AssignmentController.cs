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
            if (assignment == null)
            {
                return NotFound(" No Assignment");
            }
            return Ok(Assignmentdata);
        }

        [HttpPost]

        public async Task<IActionResult> AddAssignment([FromBody] assignment assign)
        {
            await Assignmentdata.assignments.AddAsync(assign);
            await Assignmentdata.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllAssigment), assign);

        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAssignment([FromRoute] int id, assignment assign)
        { 
            var exAssign = await Assignmentdata.assignments.FirstOrDefaultAsync(x => x.Id == id);
            if (exAssign != null)
            {
                exAssign.currency = assign.currency;
                exAssign.subject = assign.subject;
                exAssign.paymentPending = assign.paymentPending;
                exAssign.paymentRecieved = assign.paymentRecieved;
                exAssign.deadline = assign.deadline;
                exAssign.university = assign.university;
                await Assignmentdata.SaveChangesAsync();
                return Ok(exAssign);
            }
            else
            {
                return NotFound("Assignment Not found");
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] int id)
        {
            var exAssign = await Assignmentdata.assignments.FirstOrDefaultAsync(x => x.Id == id);
            if (exAssign != null)
            {
                Assignmentdata.Remove(exAssign);
                await Assignmentdata.SaveChangesAsync();
                return Ok(exAssign);
            }
            else
            {
                return NotFound("Assignment Not found");
            }
        }

    }
}
