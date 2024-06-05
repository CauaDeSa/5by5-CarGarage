namespace Model
{
    public class CarOperation : IEntity
    {
        public static readonly string Insert = "INSERT INTO CarOperation (carPlate, operationId, operationStatus) VALUES (@CarPlate, @OperationId, @OperationStatus)";
        public static readonly string RetrieveAll = "SELECT id, carPlate, operationId, operationStatus FROM CarOperation";
        public static readonly string RetrieveByStatus = "SELECT id, carPlate, operationId, operationStatus FROM CarOperation WHERE operationStatus = @OperationStatus";

        public int Id { get; set; }
        public string CarPlate { get; set; }
        public int OperationId { get; set; }
        public bool OperationStatus { get; set; }

        public override string ToString()
        {
            return $"Id...............: {Id}\n" +
                   $"Car plate........: {CarPlate}\n" +
                   $"Operation Id.....: {OperationId}\n" +
                   $"Status...........: {OperationStatus}\n";
        }
    }
}