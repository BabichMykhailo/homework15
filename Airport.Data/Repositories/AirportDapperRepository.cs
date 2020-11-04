using AirportFlight.Data.Models;
using AirportFlights.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportFlight.Data.Repositories
{
    public class AirportDapperRepository : IAirportRepository
    {
        private readonly string _connectionString;
        public int Capacity;
        public AirportDapperRepository()
        {
            _connectionString = "Data Source=DESKTOP-0HLV6ID\\MSSQLSERVER03;Initial Catalog=AirportDB;Integrated Security=true";
            Capacity = 0;
        }
        public Airport Create(Airport model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"INSERT INTO Airports(Flight, FlightNumber, FlightTime) VALUES('{model.Flight}',"
                    + $"{model.FlightNumber}, '{model.FlightTime.ToString("s")}');"
                    + $"SELECT CAST(SCOPE_IDENTITY() AS INT)";

                int id = connection.Query<int>(sqlQuery, model).FirstOrDefault();
                model.Id = id;
            }

            return model;
        }

        public IEnumerable<Airport> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Query<Airport>("SELECT * FROM Airports");
            }
        }

        public Airport GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.QueryFirst<Airport>($"SELECT * FROM Airports WHERE Id={id}");
            }
        }

        public bool IsFull()
        {
            return Capacity >= 10;
        }
    }
}
