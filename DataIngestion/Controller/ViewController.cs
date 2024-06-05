
using Model;
using Service;

namespace Controller
{
    public class ViewController
    {
        private readonly JsonService _readFile = new();
        private readonly EntityService _entityService = new();

        public List<Car> GetListFromJson() => _readFile.GetListFromJson();

        public bool Insert(List<Car> entitys) => _entityService.Insert(entitys);
    }
}