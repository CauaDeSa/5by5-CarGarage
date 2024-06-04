using Model;
using Service;

namespace Controller
{
    public class ViewController
    {
        private EntityService _entityService => new();
        private WriteFile _writeFile => new();

        public bool CreateJson(List<IEntity> entitys) => _entityService.CreateJson(_writeFile.ConvertToJson(entitys));
    }
}