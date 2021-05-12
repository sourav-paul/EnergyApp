using EnergyApp.DataModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace EnergyApp.Misc
{
    class XmlParser
    {
        public GenerationReport GenerationReport;

        public XmlParser()
        {
            GenerationReport = new GenerationReport();
        }

        public void DeserializeXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationReport));

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["input-directory"], FileMode.Open))
            {
                GenerationReport = (GenerationReport)xmlSerializer.Deserialize(reader);
            }

            Console.WriteLine(GenerationReport.Wind.Count);
            Console.WriteLine(GenerationReport.Gas.Count);
            Console.WriteLine(GenerationReport.Coal.Count);
        }
    }
}
