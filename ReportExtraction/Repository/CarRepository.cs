using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Model;

namespace Repository
{
    public class CarRepository
    {
        private string ConnectionString { get; set; }

        public CarRepository() => ConnectionString = ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString;

        public List<Car> RetrieveCarsByColor(string color)
        {
            using var connection = new SqlConnection(ConnectionString);

            return connection.Query<Car>(Car.RetrieveByColor, new { Color = color }).ToList();
        }

        public List<Car> RetrieveCarsByManufactureYear(int year)
        {
            using var connection = new SqlConnection(ConnectionString);

            return connection.Query<Car>(Car.RetrieveByManufactureYear, new { ManufactureYear = year }).ToList();
        }

        public List<Car> RetrieveCarsByPlate(List<string> plates)
        {
            using var connection = new SqlConnection(ConnectionString);

            return connection.Query<Car>(Car.RetrieveByPlate, new { Plate = plates }).ToList();
        }
    }
}