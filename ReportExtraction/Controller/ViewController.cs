using Model;
using Service;

namespace Controller
{
    public class ViewController
    {
        private readonly CarService _carService;
        private readonly XmlService _xmlService;
        private readonly CarOperationService _carOperationService;

        public ViewController()
        {
            _carService = new();
            _xmlService = new();
            _carOperationService = new();
        }

        public List<Car> GetCarsByColor(string color) => _carService.GetCarsByColor(color);

        public List<Car> GetCarsByManufactureYear(int year) => _carService.GetCarsByManufactureYear(year);

        public List<string> GetCarPlatesByStatus(int status) => _carOperationService.GetCarPlatesByStatus(status); 

        public List<Car> GetCarsByPlate(List<string> list) => _carService.GetCarsByPlate(list);

        public string GenerateXML(List<Car> cars) => _xmlService.WriteFile(cars);

        public bool CreateXmlFile(string xmlName, string carsXml) => _xmlService.GenerateXml(xmlName, carsXml);
    }
}