using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Model;

namespace Repository
{
    public class OperationRepository : IRepository<Operation>
    {
        private string ConnectionString { get; set; }

        public OperationRepository() => ConnectionString = ConfigurationManager.ConnectionStrings["stringConnection"].ConnectionString;

        public bool Insert(Operation operation)
        {
            var status = false;

            try
            {
                using var connection = new SqlConnection(ConnectionString);
                
                connection.Open();
                connection.Execute(Operation.Insert, new { operation.OperationDescription });

                status = true;
            } 
            catch (SqlException e)
            {
                System.Console.WriteLine(e.Message);
            }

            return status;
        }

        public List<Operation> RetrieveAll()
        {
            using var connection = new SqlConnection(ConnectionString);
            
            connection.Open();

            var result = connection.QueryMultiple(Operation.RetrieveAll);
            var operations = result.Read<Operation>();

            return operations.AsList();
        }
    }
}