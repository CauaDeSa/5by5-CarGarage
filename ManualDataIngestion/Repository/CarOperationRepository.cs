using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Model;

namespace Repository
{
    public class CarOperationRepository : IRepository<CarOperation>
    {
        public string ConnectionString { get; set; }

        public CarOperationRepository() => ConnectionString = ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString;

        public bool Insert(CarOperation carOperation)
        {
            var status = false;

            try
            {
                using var connection = new SqlConnection(ConnectionString);
            
                connection.Open();
                connection.Execute(CarOperation.Insert, new { carOperation.CarPlate, carOperation.OperationId, carOperation.OperationStatus });
            
                status = true;
            } 
            catch (SqlException e)
            {
                System.Console.WriteLine(e.Message);
            }

            return status;
        }

        public List<CarOperation> RetrieveAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            
            connection.Open();

            var result = connection.QueryMultiple(CarOperation.RetrieveAll);
            var carOperations = result.Read<CarOperation>();

            return carOperations.AsList();
        }
    }
}
