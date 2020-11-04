using AirportFlight.Data.Models;
using AirportFlight.Domain.Services;
using AirportFlight.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airoport.Controllers
{
    public class AirportContoller
    {
        private readonly AirportService _airportService;
        private readonly IMapper _mapper;
        public AirportContoller()
        {
            _airportService = new AirportService();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirportPostModel, AirportModel>();
                cfg.CreateMap<AirportViewModel, AirportModel>().ReverseMap();
            });
            _mapper = new Mapper(mapperConfig);
        }
        public AirportViewModel CreateAirportRequest(AirportPostModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Flight))
            {
                throw new Exception("Invalid flight");
            }
            if (model.FlightNumber <= 0)
            {
                throw new Exception("Invalid number of flight");
            }
            var airportModel = _mapper.Map<AirportModel>(model);
            
            var CreatedAirport = _airportService.CreateAirport(airportModel);
            return _mapper.Map<AirportViewModel>(CreatedAirport);
        }

        public AirportViewModel GetAirportByIdRequest(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid id");
            }
            var airportModel = _airportService.GetAirportById(id);
            var result = _mapper.Map<AirportViewModel>(airportModel);
            return result;
        }

        public IEnumerable <AirportViewModel> GetAll()
        {
            var allAirports = _airportService.GetAll();
            var result = _mapper.Map<IEnumerable<AirportViewModel>>(allAirports);

            return result;
        }
    }
}
