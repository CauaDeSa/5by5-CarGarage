using Model;

namespace Repository
{
    public class XmlRepository
    {
        private readonly string _path = "../../../../../Reports/";

        private readonly string _file = ".xml";

        public bool GenerateXml(string xmlName, string cars)
        {
            try
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                if (!File.Exists(_path + xmlName + _file))
                {
                    var file = File.Create(_path + xmlName + _file);
                    file.Close();
                }

                using StreamWriter sw = new(_path + xmlName + _file);
                sw.WriteLine(cars);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }
    }
}