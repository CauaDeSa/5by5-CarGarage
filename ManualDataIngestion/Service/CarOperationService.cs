using Model;
using Repository;

namespace Service
{
    public class CarOperationService
    {
        private readonly CarOperationRepository _carOperationRepository;

        public CarOperationService() => _carOperationRepository = new();

        public List<CarOperation> GetAllCarOperations() => _carOperationRepository.RetrieveAll();

        public bool InsertCarOperation(CarOperation carOperation) => _carOperationRepository.Insert(carOperation);
    }
}