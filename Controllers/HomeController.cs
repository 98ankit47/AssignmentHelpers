using Microsoft.AspNetCore.Mvc;
using AssignmentHelpers.Data;
using AssignmentHelpers.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentHelpers.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly DataContext DBdata;
        public HomeController(DataContext data)
        {
            this.DBdata = data;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeed()
        {
            var feeds = await DBdata.feeds.ToListAsync();
            return Ok(feeds);
        }

        [Route("{id:int}")]
        [ActionName("GetFeed")]
        [HttpGet]

        public async Task<IActionResult> GetFeed([FromRoute] int id)
        {
            //Firstordefault will return null value if criteria not mean and first will throw exception
            var feed = await DBdata.feeds.FirstOrDefaultAsync(x => x.Id == id);
            if (feed == null)
            {
                return NotFound(" No Feed");
            }
            return Ok(feed);
        }

        [HttpPost]
        [ActionName("AddFeed")]
        public async Task<IActionResult> AddFeed([FromBody] feed fd)
        {
            await DBdata.feeds.AddAsync(fd);
            await DBdata.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllFeed), fd);

        }

        [HttpPut]
        [Route("{id:int}")]
        [ActionName("UpdateFeed")]
        public async Task<IActionResult> UpdateFeed([FromRoute] int id, feed fd)
        {
            var exFeed = await DBdata.feeds.FirstOrDefaultAsync(x => x.Id == id);
            if (exFeed != null)
            {
                exFeed.feedPic = fd.feedPic;
                exFeed.description = fd.description;
                await DBdata.SaveChangesAsync();
                return Ok(exFeed);
            }
            else
            {
                return NotFound("Feed Not found");
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        [ActionName("DeleteFeed")]
        public async Task<IActionResult> DeleteFeed([FromRoute] int id)
        {
            var exFeed = await DBdata.feeds.FirstOrDefaultAsync(x => x.Id == id);
            if (exFeed != null)
            {
                DBdata.Remove(exFeed);
                await DBdata.SaveChangesAsync();
                return Ok(exFeed);
            }
            else
            {
                return NotFound("Feed Not found");
            }
        }
        [HttpGet]
        [ActionName("Login")]
        public async Task<bool> loginAsync(string username,string password)
        {
            var isAuth = await DBdata.clients.FirstOrDefaultAsync(x => x.email == username && x.password == password);
            if (isAuth != null)
            {
                return true;
            }
            return false;
         }

    }
    
}


