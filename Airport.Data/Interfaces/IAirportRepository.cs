using AirportFlight.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportFlights.Data.Interfaces
{
    public interface IAirportRepository
    {
        Airport Create(Airport model);


        Airport GetById(int id);

        IEnumerable <Airport> GetAll();

        bool IsFull();
    }
}

