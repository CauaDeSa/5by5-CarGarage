using Model;
using Repository;

namespace Service
{
    public class EntityService
    {
        private readonly JsonRepository _jsonRepository;

        public EntityService() => _jsonRepository = new();

        public bool CreateJson(string entitysString) => _jsonRepository.CreateJson(entitysString);
    }
}