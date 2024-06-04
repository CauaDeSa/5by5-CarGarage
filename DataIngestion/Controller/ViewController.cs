
using Model;
using Service;

namespace Controller
{
    public class ViewController
    {
        private readonly JsonService _readFile = new();
        private readonly EntityService _entityService = new();

        public List<Car> GetJson() => _readFile.GetJson();

        public bool Insert(List<Car> entitys) => _entityService.Insert(entitys);
    }
}