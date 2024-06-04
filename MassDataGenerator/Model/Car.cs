namespace Model
{
    public class Car : IEntity
    {
        public static readonly string Insert = "INSERT INTO Car (plate, carName, modelYear, manufactureYear, color) VALUES (@Plate, @CarName, @ModelYear, @ManufactureYear, @Color)";
        public static readonly string RetrieveAll = "SELECT plate, carName, modelYear, manufactureYear, color FROM Car";

        public string Plate { get; set; }
        public string CarName { get; set; }
        public int ModelYear { get; set; }
        public int ManufactureYear { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"Plate............: {Plate}\n" +
                   $"Name.............: {CarName}\n" +
                   $"Model year.......: {ModelYear}\n" +
                   $"Manufacture year.: {ManufactureYear}\n" +
                   $"Color............: {Color}\n";
        }
    }
}