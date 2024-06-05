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

        public string GenerateXml(List<Car> cars)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var xmlSerializer = new XmlSerializer(typeof(Car));
            var textWriter = new StringWriter();

            foreach (var car in cars)
                xmlSerializer.Serialize(textWriter, car, namespaces);

            return textWriter.ToString();
        }

        public bool GenerateXmlFile(string xmlName, string cars) => _xmlRepository.GenerateXmlFile(xmlName, cars);
    }
}