using Model;
using Repository;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Service
{
    public class XmlService
    {
        private XmlRepository _xmlRepository;

        public XmlService() => _xmlRepository = new();

        public string WriteFile(List<Car> cars)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var xmlSerializer = new XmlSerializer(typeof(Car));
            var textWriter = new StringWriter();

            foreach (var car in cars)
                xmlSerializer.Serialize(textWriter, car, namespaces);

            return textWriter.ToString();
        }

        public bool GenerateXml(string xmlName, string cars) => _xmlRepository.GenerateXml(xmlName, cars);
    }
}