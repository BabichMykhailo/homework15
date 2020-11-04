using AirportFlight.Data.Models;
using AirportFlight.Data.Repositories;
using AirportFlights.Data.Interfaces;
using AirportFlights.Data.Repositories;
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
        
        private readonly IAirportRepository _airportRepository;
        private readonly IMapper _mapper;
        public AirportService()
        {
            
            _airportRepository = new AirportDapperRepository();
            var mapperConfig = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<AirportModel, Airport>().ReverseMap();
                cfg.CreateMap<AirportModel, Airport>(); 
            });
            _mapper = new Mapper(mapperConfig);
        }
        public AirportModel CreateAirport(AirportModel model)
        {
            if(_airportRepository.IsFull())
            {
                throw new Exception("Maximum capacity");
            }
            var airport = _mapper.Map<Airport>(model);
            var CreatedAirport = _airportRepository.Create(airport);
            return _mapper.Map<AirportModel>(CreatedAirport);
        }


        public AirportModel GetAirportById(int id)
        {
            var airport = _airportRepository.GetById(id);
            var result = _mapper.Map<AirportModel>(airport);
            return result;
        }
        
        public IEnumerable<AirportModel> GetAll()
        {
            var allAirports = _airportRepository.GetAll();
            var result = _mapper.Map<IEnumerable<AirportModel>>(allAirports);

            return result;
        }

    }
}
