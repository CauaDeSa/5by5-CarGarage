using Repository;
using Model;

namespace Service
{
    public class CarOperationService
    {
        private readonly CarOperationRepository _carOperationRepository;

        public CarOperationService() => _carOperationRepository = new();

        public List<Car> RetrieveCarByStatus(int operationStatus) => _carOperationRepository.RetrieveCarByStatus(operationStatus);
    }
}