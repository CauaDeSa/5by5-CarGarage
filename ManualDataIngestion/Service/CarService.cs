using Model;
using Repository;

namespace Service
{
    public class CarService
    {
        private readonly CarRepository _carRepository;

        public CarService() => _carRepository = new();

        public List<Car> GetAllCars() => _carRepository.RetrieveAll(); 

        public bool InsertCar(Car car) => _carRepository.Insert(car);
    }
}