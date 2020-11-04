using Airoport.Controllers;
using AirportFlight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportFlight
{
    public class Program
    {
        static void Main(string[] args)
        {
            var controller = new AirportContoller();
            var model = new AirportPostModel() 
            {
                Flight = "Kiev - New-York", 
                FlightNumber = 1,
                FlightTime = DateTime.UtcNow

            };
            var a = controller.CreateAirportRequest(model);
            var ab = controller.GetAll();
           
        }
    }
}
