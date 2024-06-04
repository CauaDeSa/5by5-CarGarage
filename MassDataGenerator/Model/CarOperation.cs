namespace Model
{
    public class CarOperation : IEntity
    {
        public static readonly string Insert = "INSERT INTO CarOperation (CarPlate, OperationId, Status) VALUES (@CarPlate, @OperationId, @Status)";

        public int Id { get; set; }
        public Car CarPlate { get; set; }
        public Operation OperationId { get; set; }
        public bool Status { get; set; }
    }
}