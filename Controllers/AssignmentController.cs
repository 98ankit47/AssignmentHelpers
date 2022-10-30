using Microsoft.AspNetCore.Mvc;
using AssignmentHelpers.Data;
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
        [HttpGet]
        public async Task<IActionResult> GetAssigment([FromRoute] int id)
        {
            var assignment = await Assignmentdata.assignments.FirstOrDefaultAsync(x => x.Id == id);
            if(assignment==null)
            {
                return NotFound(" No Assignment");
            }
            return Ok(Assignmentdata);
        }
    }
}
