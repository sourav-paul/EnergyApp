using EnergyApp.DataModels;
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

namespace EnergyApp.Misc
{
    class XmlParser
    {
        public GenerationReport GenerationReport;

        public GenerationOutput GenerationOutput;

        public XmlParser()
        {
            GenerationReport = new GenerationReport();
            GenerationOutput = new GenerationOutput();
        }

        public void ReadInput()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationReport));

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["input-directory"], FileMode.Open))
            {
                GenerationReport = (GenerationReport)xmlSerializer.Deserialize(reader);
            }
        }

        public ReferenceData ReadReference()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ReferenceData));

            ReferenceData ReferenceData = new ReferenceData();

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["reference-directory"], FileMode.Open))
            {
                ReferenceData = (ReferenceData)xmlSerializer.Deserialize(reader);
            }

            Console.WriteLine(ReferenceData.Factors.EmissionsFactor.High);
            Console.WriteLine(ReferenceData.Factors.ValueFactor.High);

            return ReferenceData;
        }

        public void WriteOutput()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationOutput));

            TextWriter writer = new StreamWriter(ConfigurationManager.AppSettings["test-output-directory"]);
            
            xmlSerializer.Serialize(writer, GenerationOutput);
        }
    }
}
