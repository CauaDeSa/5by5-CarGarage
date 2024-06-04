namespace Model
{
    public class Operation : IEntity
    {
        public static readonly string Insert = "INSERT INTO Operation (operationDescription) VALUES (@OperationDescription)";
        public static readonly string RetrieveAll = "SELECT id, operationDescription FROM Operation";

        public int Id { get; set; }
        public string OperationDescription { get; set; }

        public override string ToString()
        {
            return $"Id...............: {Id}\n" +
                   $"Description......: {OperationDescription}\n";
        }
    }
}