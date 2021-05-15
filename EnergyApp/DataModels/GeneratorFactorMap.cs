using EnergyApp.DataModels.Report;
using EnergyApp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyApp.DataModels.GeneratorFactor
{
    public class GeneratorFactorMap
    {
        public Generator OffshoreWind;
        public Generator OnshoreWind;
        public Generator Gas;
        public Generator Coal;

        public GeneratorFactorMap()
        {
            OffshoreWind = new Generator();
            OnshoreWind = new Generator();
            Gas = new Generator();
            Coal = new Generator();
        }
    }

    public class Generator
    {
        public Factor ValeuFactor = Factor.NotSet;
        public Factor EmissionsFactor = Factor.NotSet;
    }

    public enum Factor
    {
        NotSet = -1,
        High = 0,
        Medium = 1,
        Low = 2,
        NotApplicable = 3
    }
}
