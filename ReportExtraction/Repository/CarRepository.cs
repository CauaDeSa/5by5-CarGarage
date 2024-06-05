using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Model;

namespace Repository
{
    public class CarRepository
    {
        private string ConnectionString { get; set; }

        public CarRepository() => ConnectionString = "Data Source=127.0.0.1; Initial Catalog=DBCarGarage; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";

        public List<Car> RetrieveCarsByColor(string color)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var result = connection.QueryMultiple(Car.RetrieveByColor, new { Color = color });

            var cars = result.Read<Car>();

            List<Car> carList = cars.AsList();

            return carList;
        }

        public List<Car> RetrieveCarsByManufactureYear(int year)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var result = connection.QueryMultiple(Car.RetrieveByManufactureYear, new { ManufactureYear = year });

            var cars = result.Read<Car>();

            List<Car> carList = cars.AsList();

            return carList;
        }

        public List<Car> RetrieveCarsByPlate(List<string> list)
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var result = connection.QueryMultiple(Car.RetrieveByPlate, new { Plate = list });

            var cars = result.Read<Car>();

            List<Car> carList = cars.AsList();

            return carList;
        }

    }
}