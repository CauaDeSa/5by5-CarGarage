using Model;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace Repository
{
    public class CarOperationRepository
    {
        private string ConnectionString { get; set; }

        public CarOperationRepository() => ConnectionString = "Data Source=127.0.0.1; Initial Catalog=DBCarGarage; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";

        public List<string> RetrieveCarPlatesByStatus(int operationStatus)
        {
            using var connection = new SqlConnection(ConnectionString);

            List<CarOperation> ops = connection.Query<CarOperation>(CarOperation.RetrieveByStatus, new { OperationStatus = operationStatus })
                .ToList();

            List<string> plates = new();

            foreach (var carOp in ops)
                plates.Add(carOp.CarPlate);    
            

            return plates;
            
        }
    }
}