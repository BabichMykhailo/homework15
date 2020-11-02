﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportFlight.Models
{
    public class AirportViewModel
    {
        public int Id { get; set; }
        public string Flight { get; set; }
        public int FlightNumber { get; set; }
        public DateTime FlightTime { get; set; }

    }
}
