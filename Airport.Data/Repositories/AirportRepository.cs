using AirportFlight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportFlight.Data.Repositories
{
    public class AirportRepository
    {
        public int Capacity;
        private readonly List <Airport> _airports;
        private int Id;
        public AirportRepository()
        {
            Capacity = 0;
            _airports = new List<Airport>();
            Id = 1;
            Capacity++;
        }
        public void Create(Airport model)
        {
            model.Id = Id; 
            _airports.Add(model);
            Id++;
        }

        public Airport GetById(int id) 
        {
            var result = _airports.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
