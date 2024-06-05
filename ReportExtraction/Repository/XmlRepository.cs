using Model;

namespace Repository
{
    public class XmlRepository
    {
        private readonly string _path = "../../../../../Reports/";

        private readonly string _extension = ".xml";

        public bool GenerateXmlFile(string xmlName, string cars)
        {
            try
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                if (!File.Exists(_path + xmlName + _extension))
                {
                    var file = File.Create(_path + xmlName + _extension);
                    file.Close();
                }

                using StreamWriter sw = new(_path + xmlName + _extension);
                sw.WriteLine(cars);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}