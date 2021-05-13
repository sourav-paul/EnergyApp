using EnergyApp.DataModels;
using EnergyApp.DataModels.Output;
using EnergyApp.DataModels.Report;
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

        public GenerationOutput GenerationOutput;

        public XmlParser()
        {
            GenerationReport = new GenerationReport();
            GenerationOutput = new GenerationOutput();
        }

        public void DeserializeXml()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GenerationReport));

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["input-directory"], FileMode.Open))
            {
                GenerationReport = (GenerationReport)xmlSerializer.Deserialize(reader);
            }

            xmlSerializer = new XmlSerializer(typeof(GenerationOutput));

            using (Stream reader = new FileStream(ConfigurationManager.AppSettings["output-directory"], FileMode.Open))
            {
                GenerationOutput = (GenerationOutput)xmlSerializer.Deserialize(reader);
            }

            //Console.WriteLine(GenerationReport.Wind.Count);
            //Console.WriteLine(GenerationReport.Gas.Count);
            //Console.WriteLine(GenerationReport.Coal.Count);

            Console.WriteLine(GenerationOutput.ActualHeatRates.Count);
            Console.WriteLine(GenerationOutput.MaxEmissionGenerators.Count);
            Console.WriteLine(GenerationOutput.Totals.Count);
        }
    }
}
