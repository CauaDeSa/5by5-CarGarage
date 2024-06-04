namespace Model
{
    public class Car : IEntity
    {
        public readonly string Insert = "INSERT INTO Car (plate, carName, modelYear, manufactureYear, color) VALUES (@Plate, @Name, @ModelYear, @ManufactureYear, @Color)";

        public string Plate { get; set; }
        public string Name { get; set; }
        public int ModelYear { get; set; }
        public int ManufactureYear { get; set; }
        public string Color { get; set; }
    }
}