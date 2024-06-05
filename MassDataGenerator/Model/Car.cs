namespace Model
{
    public class Car : IEntity
    {
        public static readonly string Insert = "INSERT INTO Car (plate, carName, modelYear, manufactureYear, color) VALUES (@Plate, @CarName, @ModelYear, @ManufactureYear, @Color)";
        public static readonly string RetrieveAll = "SELECT plate, carName, modelYear, manufactureYear, color FROM Car";
        public static readonly string RetrieveByColor = "SELECT plate, carName, modelYear, manufactureYear, color FROM Car WHERE color = @Color";
        public static readonly string RetrieveByManufactureYear = "SELECT plate, carName, modelYear, manufactureYear, color FROM Car WHERE manufactureYear = @ManufactureYear";
        public static readonly string RetrieveByPlate = "SELECT plate, carName, modelYear, manufactureYear, color FROM Car WHERE plate = @Plate";

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