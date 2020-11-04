using AirportFlight.Data.Models;
using AirportFlights.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportFlights.Data.Repositories
{
    public class AirportRepositoryADONet : IAirportRepository
    {
        private readonly string _connectionString;
        public int Capacity;
        public AirportRepositoryADONet()
        {
            _connectionString = "Data Source=DESKTOP-0HLV6ID\\MSSQLSERVER03;Initial Catalog=AirportDB;Integrated Security=true";
            Capacity = 0;
        }
        public Airport Create(Airport model)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"INSERT INTO Airports(Flight, FlightNumber, FlightTime) OUTPUT " +
                    $"Inserted.Id VALUES('{model.Flight}', {model.FlightNumber}, '{model.FlightTime.ToString("s")}')";

                var id = command.ExecuteScalar();
                model.Id = (int)id;
                Capacity++;

                return model;
            }
        }


        public bool IsFull()
        {
            return Capacity >= 10;
        }

        public IEnumerable<Airport> GetAll()
        {
            var result = new List<Airport>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM Airports";

                SqlDataReader reader = command.ExecuteReader();
                Airport airport = new Airport();

                while (reader.Read())
                {
                    airport.Id = airport.Id = reader.GetInt32(0);
                    airport.Flight = reader.GetString(1);
                    airport.FlightNumber = reader.GetInt32(2);
                    airport.FlightTime = (DateTime)reader["FlightTime"];
                    result.Add(airport);
                }
            }

            return result;
        }

       

        public Airport GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();

                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = $"SELECT * FROM Airports WHERE Id={id}";

                SqlDataReader reader = command.ExecuteReader();
                Airport result = new Airport();
                reader.Read();

                result.Id = reader.GetInt32(0);
                result.Flight = reader.GetString(1);
                result.FlightNumber = reader.GetInt32(2);
                result.FlightTime = (DateTime)reader["FlightTime"];

                return result;
            }
        }
    }
}
