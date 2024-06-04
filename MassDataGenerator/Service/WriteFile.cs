using Model;
using Newtonsoft.Json;

namespace Service
{
    public class WriteFile
    {
        public string ConvertToJson(List<IEntity> entitys) => JsonConvert.SerializeObject(entitys);
    }
}