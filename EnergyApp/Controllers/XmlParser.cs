using EnergyApp.DataModels;
using EnergyApp.DataModels.GeneratorFactor;
using EnergyApp.DataModels.Output;
using EnergyApp.DataModels.Report;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EnergyApp.Controllers
{
    public class XmlParser
    {
        public static GenerationReport ReadInput()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationReport));

            GenerationReport GenerationReport = new GenerationReport();

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["input-directory"], FileMode.Open))
            {
                GenerationReport = (GenerationReport)xmlSerializer.Deserialize(reader);
            }

            return GenerationReport;
        }

        public static ReferenceData ReadReference()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ReferenceData));

            ReferenceData ReferenceData = new ReferenceData();

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["reference-directory"], FileMode.Open))
            {
                ReferenceData = (ReferenceData)xmlSerializer.Deserialize(reader);
            }

            return ReferenceData;
        }

        public static GeneratorFactorMap ReadMap()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GeneratorFactorMap));

            GeneratorFactorMap GeneratorFactorMap = new GeneratorFactorMap();

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["generator-factor-map-directory"], FileMode.Open))
            {
                GeneratorFactorMap = (GeneratorFactorMap)xmlSerializer.Deserialize(reader);
            }

            return GeneratorFactorMap;
        }

        public static void WriteOutput(GenerationOutput GenerationOutput)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationOutput));

            TextWriter writer = new StreamWriter(ConfigurationManager.AppSettings["output-directory"]);

            xmlSerializer.Serialize(writer, GenerationOutput);
        }
    }
}
