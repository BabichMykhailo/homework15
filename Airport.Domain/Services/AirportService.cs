using AirportFlight.Data.Models;
using AirportFlight.Data.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportFlight.Domain.Services
{
    public class AirportService
    {
        
        private readonly AirportRepository _airportRepository;
        private readonly IMapper _mapper;
        public AirportService()
        {
            
            _airportRepository = new AirportRepository();
            var mapperConfig = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<AirportModel, Airport>().ReverseMap();
                cfg.CreateMap<AirportModel, Airport>(); 
            });
            _mapper = new Mapper(mapperConfig);
        }
        public void CreateAirport(AirportModel model)
        {
            if(_airportRepository.Capacity >= 10)
            {
                throw new Exception("Maximum capacity");
            }
            var airport = _mapper.Map<Airport>(model);
            _airportRepository.Create(airport);
            
        }
        public AirportModel GetAirportById(int id)
        {
            var airport = _airportRepository.GetById(id);
            var result = _mapper.Map<AirportModel>(airport);
            return result;
        } 
    }
}
