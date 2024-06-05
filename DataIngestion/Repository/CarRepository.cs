using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Model;

namespace Repository
{
    public class CarRepository
    {
        private string ConnectionString { get; set; }

        public CarRepository() => ConnectionString = ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString;

        public bool Insert(List<Car> entitys)
        {
            var status = false;

            try
            {
                foreach (Car car in entitys)
                {
                    using (var connection = new SqlConnection(ConnectionString))
                    {
                        connection.Open();
                        connection.Execute(Car.Insert, new { car.Plate, car.CarName, car.ModelYear, car.ManufactureYear, car.Color });

                        status = true;
                    }
                }

                return status;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return status;
            }
        }
    }
}
