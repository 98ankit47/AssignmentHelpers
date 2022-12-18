using Microsoft.AspNetCore.Mvc;
using AssignmentHelpers.Data;
using AssignmentHelpers.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentHelpers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly DataContext DBdata;
        public ClientController(DataContext data)
        {
            this.DBdata = data;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClinet()
        {
            var client = await DBdata.clients.ToListAsync();
            return Ok(client);
        }

        [Route("{id:int}")]
        [ActionName("GetClient")]
        [HttpGet]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            //Firstordefault will return null value if criteria not mean and first will throw exception
            var client = await DBdata.clients.FirstOrDefaultAsync(x => x.Id == id);
            if (client == null)
            {
                return NotFound(" No Clinets");
            }
            return Ok(client);
        }

        [HttpPost]

        public async Task<IActionResult> AddClient([FromBody] client ct)
        {
            await DBdata.clients.AddAsync(ct);
            await DBdata.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllClinet), ct);

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateClient([FromRoute] int id, client ct)
        {
            var exClient = await DBdata.clients.FirstOrDefaultAsync(x => x.Id == id);
            if (exClient != null)
            {
                exClient.firstName = ct.firstName;
                exClient.lastName = ct.lastName;
                exClient.email = ct.email;
                exClient.Address = ct.Address;
                exClient.city = ct.city;
                exClient.state = ct.state;
                exClient.country = ct.country;
                exClient.course = ct.course;
                exClient.university = ct.university;
                exClient.duration = ct.duration;
                await DBdata.SaveChangesAsync();
                return Ok(exClient);
            }
            else
            {
                return NotFound("Client Not found");
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            var exClient = await DBdata.clients.FirstOrDefaultAsync(x => x.Id == id);
            if (exClient != null)
            {
                DBdata.Remove(exClient);
                await DBdata.SaveChangesAsync();
                return Ok(exClient);
            }
            else
            {
                return NotFound("Client Not found");
            }
        }
    }
}
