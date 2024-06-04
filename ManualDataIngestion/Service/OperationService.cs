using Model;
using Repository;

namespace Service
{
    public class OperationService
    {
        private readonly OperationRepository _operationRepository;

        public OperationService() => _operationRepository = new();

        public List<Operation> GetAllOperations() => _operationRepository.RetrieveAll();

        public bool InsertOperation(Operation operation) => _operationRepository.Insert(operation);
    }
}