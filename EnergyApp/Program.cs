using EnergyApp.Controllers;
using EnergyApp.DataModels.Output;
using EnergyApp.DataModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;

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
            
            Run();
        }

        private static void Run()
        {
            GetGenerationReport();

            CalculateOutput();

            WriteReportToFile();
        }

        private static void CalculateOutput()
        {
            CalculateTotalDailyGenerationValue();

            CalculateHighestDailyEmissions();

            CalculateActualHeatRate();
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
        }

        private static void CalculateHighestDailyEmissions()
        {
            var gas_coal_generator = GenerationReport.Gas.Zip(GenerationReport.Coal, (gas, coal) => (gas, coal));

            foreach (var generator in gas_coal_generator)
            {
                var gas_coal_days = generator.gas.Generation.Zip(generator.coal.Generation, (gasDay, coalDay) => (gasDay, coalDay));

                foreach (var dayPair in gas_coal_days)
                {
                    if (dayPair.gasDay.Date == dayPair.coalDay.Date)
                    {
                        var gasDailyEmissions = EnergyCalculator.DailyEmissions(dayPair.gasDay.Energy,
                                                            generator.gas.EmissionsRating,
                                                            GeneratorFactorMapController.GetFactor(generator.gas).EmissionsFactor);

                        var coalDailyEmissions = EnergyCalculator.DailyEmissions(dayPair.coalDay.Energy,
                                                              generator.coal.EmissionsRating,
                                                              GeneratorFactorMapController.GetFactor(generator.coal).EmissionsFactor);

                        if (gasDailyEmissions > coalDailyEmissions)
                        {
                            GenerationOutput.MaxEmissionGenerators.Add(
                                             new DataModels.Output.Day(generator.gas.Name, 
                                                                       dayPair.gasDay.Date,
                                                                       gasDailyEmissions));
                        }
                        else
                        {
                            GenerationOutput.MaxEmissionGenerators.Add(
                                             new DataModels.Output.Day(generator.coal.Name,
                                                                       dayPair.coalDay.Date,
                                                                       coalDailyEmissions));
                        }
                    }
                    else
                    {
                        // TODO: Handle uneven day counts
                    }
                }
            }
        }

        private static void CalculateActualHeatRate()
        {

        }

        private static void WriteReportToFile()
        {
            
        }

    }
}
