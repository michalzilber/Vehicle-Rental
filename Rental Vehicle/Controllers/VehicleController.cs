using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rental_Vehicle.Enties;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private static List<Vehicle> vehicles = new List<Vehicle>{
                new Vehicle { codeVehicle=1234, type = "Bicycle" },
                new Vehicle {  codeVehicle=12544, type = "Scooter" }
            };
       
      

        // GET: api/<VaehicleController>
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return vehicles;
        }

        // GET api/<VaehicleController>/5
        [HttpGet("{codeVehicle}")]
        public string Get(int codeVehicle)
        {
            var index = vehicles.FindIndex(e => e.codeVehicle == codeVehicle);
            if (index != -1)
                return vehicles[index].type;

            return null;
        }

        // POST api/<VaehicleController>
        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            vehicles.Add(vehicle);

        }

        // PUT api/<VaehicleController>/5
        [HttpPut("{id}")]
        public void Put(int codeVeicle, [FromBody] Vehicle vehicle)
        {
            var index = vehicles.FindIndex(e => e.codeVehicle == codeVeicle);
            if (index != -1) { }
            vehicles[index].type = vehicle.type;
            vehicles[index].codeVehicle = vehicle.codeVehicle;
        }

       //מחיקה לפי קוד
        [HttpDelete("{id}")]
        public void Delete(int codeVehicle)
        {
            var index = vehicles.FindIndex(e => e.codeVehicle==codeVehicle);
            if (index != -1)
                vehicles.Remove(vehicles[index]);
            else
                Console.WriteLine("Not sucssed");

        }
    }
}
