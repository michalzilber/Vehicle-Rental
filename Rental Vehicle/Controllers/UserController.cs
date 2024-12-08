using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental_Vehicle.Enties;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService= userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }


        //מציאת משתמש
        [HttpGet("{tel}")]
        public ActionResult GetUser(String tel)
        {
            User user = _userService.GetUser(tel);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
        
        //עדכון משתמש
        [HttpPut("{tel}")]
        public void Put(String tel, [FromBody] User value)
        {
           
            _userService.Put(tel, value);
        }


        //הוספת משתמש
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            _userService.UpdateUser(user);
            return Ok(result);

            

        }

        // מחיקת משתמש
        [HttpDelete("{tel}")]
        public ActionResult Delete(string tel)
        {
            var user = _userService.GetUser(tel);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(tel);
            return NoContent();

        }
    }
   
}
