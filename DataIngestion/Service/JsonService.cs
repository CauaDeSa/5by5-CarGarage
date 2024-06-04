using Model;
using Repository;

namespace Service
{
    public class JsonService
    {
        private readonly ReadFile _readFile = new();

        public List<Car> GetJson() => _readFile.GetJson();
    }
}