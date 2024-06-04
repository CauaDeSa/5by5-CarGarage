using Model;
using Repository;

namespace Service
{
    public class EntityService
    {
        private readonly CarRepository _repository = new();

        public bool Insert(List<Car> entitys) => _repository.Insert(entitys);
    }
}
