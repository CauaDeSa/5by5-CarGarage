using Model;
using Service;

namespace Controller
{
    public class ViewController
    {
        private readonly CarService _carService;
        private readonly OperationService _operationService;
        private readonly CarOperationService _carOperationService;

        public ViewController()
        {
            _carService = new();
            _operationService = new();
            _carOperationService = new();
        }

        public List<Car> GetAllCars() => _carService.GetAllCars();
        
        public List<Operation> GetAllOperations() => _operationService.GetAllOperations();

        public List<CarOperation> GetAllCarOperations() => _carOperationService.GetAllCarOperations();

        public bool InsertCar(Car car) => _carService.InsertCar(car);

        public bool InsertOperation(Operation operation) => _operationService.InsertOperation(operation);

        public bool InsertCarOperation(CarOperation carOperation) => _carOperationService.InsertCarOperation(carOperation);
    }
}