using EnergyApp.DataModels;
using EnergyApp.DataModels.GeneratorFactor;
using EnergyApp.DataModels.Report;
using System;

namespace EnergyApp.Controllers
{
    public class FactorPair
    {
        public double? ValueFactor;
        public double? EmissionsFactor;
    }

    class GeneratorFactorMapController
    {
        private ReferenceData ReferenceData;
        private GeneratorFactorMap GeneratorFactorMap;

        public GeneratorFactorMapController()
        {
            ReferenceData = new ReferenceData();
            GeneratorFactorMap = new GeneratorFactorMap();

            LoadData();
        }

        private void LoadData()
        {
            ReferenceData = XmlParser.ReadReference();
            GeneratorFactorMap = XmlParser.ReadMap();
        }

        public FactorPair GetFactor(EnergyGenerator generator)
        {
            FactorPair FactorPair = new FactorPair();

            if (generator.Equals(typeof(WindGenerator)))
            {
                if (((WindGenerator)generator).Location == Location.Offshore)
                {
                    FactorPair.ValueFactor = ConvertValueFactor(GeneratorFactorMap.OffshoreWind.ValueFactor);
                    FactorPair.EmissionsFactor = ConvertEmissionsFactor(GeneratorFactorMap.OffshoreWind.EmissionsFactor);
                }
                else if (((WindGenerator)generator).Location == Location.Onshore)
                {
                    FactorPair.ValueFactor = ConvertValueFactor(GeneratorFactorMap.OnshoreWind.ValueFactor);
                    FactorPair.EmissionsFactor = ConvertEmissionsFactor(GeneratorFactorMap.OnshoreWind.EmissionsFactor);
                }
            }
            else if (generator.Equals(typeof(GasGenerator)))
            {
                FactorPair.ValueFactor = ConvertValueFactor(GeneratorFactorMap.Gas.ValueFactor);
                FactorPair.EmissionsFactor = ConvertEmissionsFactor(GeneratorFactorMap.Gas.EmissionsFactor);
            }
            else if (generator.Equals(typeof(CoalGenerator)))
            {
                FactorPair.ValueFactor = ConvertValueFactor(GeneratorFactorMap.Coal.ValueFactor);
                FactorPair.EmissionsFactor = ConvertEmissionsFactor(GeneratorFactorMap.Coal.EmissionsFactor);
            }
            else
            {
                Console.WriteLine("Unknown Generator Type");

                FactorPair = null;
            }

            return FactorPair;
        }

        private double? ConvertValueFactor(Factor factor)
        {
            switch (factor)
            {
                case Factor.NotSet:
                    Console.WriteLine("Value Factor Not Set");
                    return null;
                case Factor.High:
                    return ReferenceData.Factors.ValueFactor.High;
                case Factor.Medium:
                    return ReferenceData.Factors.ValueFactor.Medium;
                case Factor.Low:
                    return ReferenceData.Factors.ValueFactor.Low;
                case Factor.NotApplicable:
                    Console.WriteLine("Value Factor Can't be NotApplicable");
                    return null;
                default:
                    Console.WriteLine("Unknown Factor");
                    return null;
            }
        }

        private double? ConvertEmissionsFactor(Factor factor)
        {
            switch (factor)
            {
                case Factor.NotSet:
                    Console.WriteLine("Emissions Factor Not Set");
                    return null;
                case Factor.High:
                    return ReferenceData.Factors.EmissionsFactor.High;
                case Factor.Medium:
                    return ReferenceData.Factors.EmissionsFactor.Medium;
                case Factor.Low:
                    return ReferenceData.Factors.EmissionsFactor.Low;
                case Factor.NotApplicable:
                    Console.WriteLine("Emissions Factor Can't be NotApplicable");
                    return null;
                default:
                    Console.WriteLine("Unknown Factor");
                    return null;
            }
        }
    }
}
