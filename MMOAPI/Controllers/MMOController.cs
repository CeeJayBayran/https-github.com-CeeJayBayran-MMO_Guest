using Business_Logic;
using ClassLibrary1;
using DataMMO.DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace MMOAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MMOController : Controller
    {
        private readonly BLMMO _bl = new BLMMO();
        private readonly  DBMillionaireOrg db = new DBMillionaireOrg();

        //MY API CODE FOR CONTROLLERS //
        [HttpGet]
        public IEnumerable<Guest> GetAllGuests()
        {
            return _bl.AllGuests();
        }
        [HttpGet("search")]
        public ActionResult<Guest> SearchGuest([FromQuery] string name)
        {
         var guest = _bl.Search(name);
         if (guest != null)
         return Ok(guest);
         else
                return NotFound("Guest not found.");
        } 
        [HttpGet("exists")]
        public ActionResult<bool> Exists([FromQuery] string name)
        {
        return Ok(_bl.Exists(name));
        }

        [HttpPost("register")]
        public ActionResult<bool> RegisterGuest([FromQuery] string name)
        {
        var success = _bl.Register(name);
        if (success)
        return Ok(true);
        else
        return BadRequest("Registration failed. Guest may not be allowed or already registered.");
        }
        [HttpPost("exit")]
        public ActionResult<bool> ExitGuest([FromQuery] string name)
        {
            var success = _bl.Exit(name);
            if (success)
                return Ok(true);
            else
                return BadRequest("Exit failed. Guest may not be registered.");
        }
        [HttpDelete("remove")]
        public ActionResult<bool> RemoveGuest([FromQuery] string name)
        {
            var success = _bl.Exit(name); 
            if (success)
                return Ok(true);
            else
                return NotFound("Guest not found or already exited.");
        }
    }
}
