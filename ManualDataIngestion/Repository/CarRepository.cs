using Dapper;
using Microsoft.Data.SqlClient;
using Model;
using System.Configuration;

namespace Repository
{
    public class CarRepository : IRepository<Car>
    {
        private string ConnectionString { get; set; }

        public CarRepository() => ConnectionString = ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString;

        public bool Insert(Car car)
        {
            var status = false;

            try
            {
                using var connection = new SqlConnection(ConnectionString);
                
                connection.Open();
                connection.Execute(Car.Insert, new { car.Plate, car.CarName, car.ModelYear, car.ManufactureYear, car.Color });

                status = true;
            }
            catch (SqlException e)
            {
                System.Console.WriteLine(e.Message);
            }

            return status;
        }

        public List<Car> RetrieveAll()
        {
            using var connection = new SqlConnection(ConnectionString);

            connection.Open();

            var result = connection.QueryMultiple(Car.RetrieveAll);

            var cars = result.Read<Car>();

            List<Car> carList = cars.AsList();

            return carList;
        }
    }
}