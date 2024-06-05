namespace Repository
{
    public class JsonRepository
    {
        private readonly string _path = "../../../../../Reports/";
        private readonly string _file = "Cars.json";

        public bool CreateJson(string entitysString)
        {
            try
            {
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);

                if (!File.Exists(_path + _file))
                {
                    var file = File.Create(_path + _file);
                    file.Close();
                }

                using StreamWriter sw = new(_path + _file);
                sw.WriteLine(entitysString);

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