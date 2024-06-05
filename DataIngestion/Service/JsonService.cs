using Model;
using Repository;

namespace Service
{
    public class JsonService
    {
        private readonly ReadFile _readFile = new();

        public List<Car> GetListFromJson() => _readFile.GetListFromJson();
    }
}