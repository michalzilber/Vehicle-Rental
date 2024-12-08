using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Vehicle.Core.Enties;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rental_Vehicle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
          _vehicleService = vehicleService;
        }

        // GET: api/<VaehicleController>
        [HttpGet]
        public IEnumerable<Vehicles> Get()
        {
            _vehicleService.Get();
        }

        // GET api/<VaehicleController>/5
        [HttpGet("{type}")]
        public string Get(string type)
        {
            _vehicleService.GetVehicle(type);
            
        }
      

        // POST api/<VaehicleController>
        [HttpPost]
        public void Post([FromBody] Vehicles vehicle)
        {
           _vehicleService.Post(vehicle);

        }

        // PUT api/<VaehicleController>/5
        [HttpPut("{id}")]
        public void Put(int codeVeicle, [FromBody] Vehicles vehicle)
        {
           _vehicleService.Put(codeVeicle, vehicle);
        }

       //מחיקה לפי קוד
        [HttpDelete("{id}")]
        public ActionResult Delete(int codeVehicle)
        {
            

        }
   
    }
}
