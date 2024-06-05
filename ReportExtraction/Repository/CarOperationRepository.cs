using Model;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Repository
{
    public class CarOperationRepository
    {
        private string ConnectionString { get; set; }

        public CarOperationRepository() => ConnectionString = ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString;

        public List<Car> RetrieveCarByStatus(int operationStatus)
        {
            using var connection = new SqlConnection(ConnectionString);

            return connection.Query<Car>(CarOperation.RetrieveByStatus, new { operationStatus }).ToList();
        }
    }
}