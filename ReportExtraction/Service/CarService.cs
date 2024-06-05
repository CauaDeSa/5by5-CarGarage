using Model;
using Repository;

namespace Service
{
    public class CarService
    {
        private readonly CarRepository _carRepository;

        public CarService() => _carRepository = new CarRepository();

        public List<Car> GetCarsByColor(string color) => _carRepository.RetrieveCarsByColor(color);

        public List<Car> GetCarsByManufactureYear(int year) => _carRepository.RetrieveCarsByManufactureYear(year);

        public List<Car> GetCarsByPlate(List<string> list) => _carRepository.RetrieveCarsByPlate(list);
    }
}