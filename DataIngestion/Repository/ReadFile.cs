using Model;
using Newtonsoft.Json;

namespace Repository
{
    public class ReadFile
    {
        private readonly string _path = "../../../../../MassDataGenerator/Reports/";
        private readonly string _file = "Cars.json";

        public List<Car> GetJson()
        {
            StreamReader file = new(_path + _file);

            string jsonString = file.ReadToEnd();

            return JsonConvert.DeserializeObject<List<Car>>(jsonString) ?? new List<Car>();
        }
    }
}