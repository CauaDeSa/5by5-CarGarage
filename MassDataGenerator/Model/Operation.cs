namespace Model
{
    public class Operation : IEntity
    {
        public static readonly string Insert = "INSERT INTO Operation (Description) VALUES (@Description)";

        public int Id { get; set; }
        public string Description { get; set; }
    }
}