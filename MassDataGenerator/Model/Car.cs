namespace Model
{
    public class Car : IEntity
    {
        public static readonly string Insert = "INSERT INTO Car (Plate, Name, ModelYear, ManufactureYear, Color) VALUES (@Plate, @Name, @ModelYear, @ManufactureYear, @Color)";

        public string Plate { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int ManufactureYear { get; set; }
        public string Color { get; set; }
    }
}