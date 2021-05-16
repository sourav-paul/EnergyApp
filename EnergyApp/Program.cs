using EnergyApp.Controllers;
using EnergyApp.DataModels.Output;
using EnergyApp.DataModels.Report;
using System;

namespace EnergyApp
{
    class Program
    {
        static GeneratorFactorMapController GeneratorFactorMapController = new GeneratorFactorMapController();

        static GenerationReport GenerationReport = new GenerationReport();

        static GenerationOutput GenerationOutput = new GenerationOutput();

        static void Main(string[] args)
        {
            Console.WriteLine("Energy App");

            GetGenerationReport();

            CalculateTotalDailyGenerationValue();

            CalculateHighestDailyEmissions();

            CalculateActualHeatRate();

            WriteReportToFile();
        }

        private static void GetGenerationReport()
        {
            GenerationReport = XmlParser.ReadInput();
        }

        private static void CalculateTotalDailyGenerationValue()
        {
            foreach (var generator in GenerationReport.Wind)
            {
                if (generator.Location == Location.Offshore)
                {
                    AddDailyGenerationValue(generator);
                }
                else if (generator.Location == Location.Onshore)
                {
                    AddDailyGenerationValue(generator);
                }
            }

            foreach (var generator in GenerationReport.Gas)
            {
                AddDailyGenerationValue(generator);
            }

            foreach (var generator in GenerationReport.Coal)
            {
                AddDailyGenerationValue(generator);
            }
        }

        private static void AddDailyGenerationValue(EnergyGenerator generator)
        {
            Generator gen = new Generator(generator.Name);

            foreach (var item in generator.Generation)
            {
                gen.Total += EnergyCalculator.DailyGenerationValue(item, GeneratorFactorMapController.GetFactor(generator).ValueFactor);
            }

            GenerationOutput.Totals.Add(gen);

            Console.WriteLine(GenerationOutput.Totals[0].Total);
            Console.WriteLine(GenerationOutput.Totals[1].Total);
            Console.WriteLine(GenerationOutput.Totals[2].Total);
            Console.WriteLine(GenerationOutput.Totals[3].Total);
        }

        private static void CalculateHighestDailyEmissions()
        {

        }
        private static void CalculateActualHeatRate()
        {

        }
        private static void WriteReportToFile()
        {
            
        }

    }
}
