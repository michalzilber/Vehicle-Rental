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
        private static List<User> users = new List<User>
        {
            new User{name="michal",tel="03123456",CodeVehicle=1233},
            new User{name="shira",tel="0344444",CodeVehicle=13233}
        };
       
        public UserController() { 

        }
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }
        //מציאת משתמש
        [HttpPut("{tel}")]
        public User GetUser(String tel) {
            var index = users.FindIndex(e => e.tel.Equals(tel));
            if (index != -1)
                return users[index];
            return null;

        }

        //הוספת משתמש
        [HttpPost]
        public User Post([FromBody] User value)
        {
            users.Add(value);
            return value;

        }

       //עדכון משתמש
        [HttpPut("{tel}")]
        public void Put(String tel, [FromBody] User value)
        {
            var index = users.FindIndex(e => e.tel.Equals(tel) );
            if (index != -1)
            {
                users[index].name = value.name;
                users[index].tel = value.tel;
            }
            Console.WriteLine("Not sucssed");

        }

        // מחיקת משתמש
        [HttpDelete("{tel}")]
        public void Delete(string tel)
        {
            var index = users.FindIndex(e => e.tel.Equals(tel));
            if(index != -1)
            users.Remove(users[index]);
            else
            Console.WriteLine("Not sucssed");

        }
    }
}
