using EnergyApp.DataModels;
using EnergyApp.DataModels.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyApp.Calculator
{
    class EnergyCalculator
    {
        public double DailyGenerationValue(Day day, double valueFactor)
        {
            return day.Energy * day.Price * valueFactor;
        }

        public double DailyEmissions(Day day, double emissionRating, EmissionsFactor emissionsFactor)
        {
            return day.Energy * emissionRating * emissionsFactor.Medium;
        }

        public void ActualHeatRate(double totalHeatInput, double actualNetGeneration)
        {

        }


    }

    public class GeneratorFactorMap
    {
        Dictionary<GeneratorType, Dictionary<FactorKey, FactorValue>> map = new Dictionary<GeneratorType, Dictionary<FactorKey, FactorValue>>() 
        {
            { GeneratorType.OffshoreWind, new Dictionary<FactorKey, FactorValue>()
                                            {
                                                { FactorKey.ValueFactor, FactorValue.Low },
                                                { FactorKey.EmissionsFactor, FactorValue.NotApplicable }
                                            }
            },
            { GeneratorType.OnshoreWind, new Dictionary<FactorKey, FactorValue>()
                                            {
                                                { FactorKey.ValueFactor, FactorValue.High },
                                                { FactorKey.EmissionsFactor, FactorValue.NotApplicable }
                                            }
            },
            { GeneratorType.Gas, new Dictionary<FactorKey, FactorValue>()
                                            {
                                                { FactorKey.ValueFactor, FactorValue.Medium },
                                                { FactorKey.EmissionsFactor, FactorValue.Medium }
                                            }
            },
            { GeneratorType.Coal, new Dictionary<FactorKey, FactorValue>()
                                            {
                                                { FactorKey.ValueFactor, FactorValue.High },
                                                { FactorKey.EmissionsFactor, FactorValue.NotApplicable }
                                            }
            },
        };
    }

    public enum GeneratorType
    {
        NotSet = -1,
        OffshoreWind = 0,
        OnshoreWind = 1,
        Gas = 2,
        Coal = 3
    }

    public enum FactorKey
    {
        NotSet = -1,
        ValueFactor = 0,
        EmissionsFactor = 1
    }

    public enum FactorValue
    {
        NotSet = -1,
        High = 0,
        Medium = 1,
        Low = 2,
        NotApplicable = 3
    }
}
