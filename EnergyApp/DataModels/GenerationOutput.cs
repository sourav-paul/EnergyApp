using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EnergyApp.DataModels.Output
{
    public class GenerationOutput
    {
        public List<Generator> Totals;
        public List<Day> MaxEmissionGenerators;
        public List<ActualHeatRate> ActualHeatRates;

        public GenerationOutput()
        {
            Totals = new List<Generator>();
            MaxEmissionGenerators = new List<Day>();
            ActualHeatRates = new List<ActualHeatRate>();
        }
    }
    
    public class Generator
    {
        public string Name;
        public double? Total;

        public Generator(string name = "Unnamed")
        {
            Name = name;
            Total = 0;
        }
    }

    public class Day
    {
        public string Name;
        public DateTime Date;
        public double Emission;
    }

    public class ActualHeatRate
    {
        public string Name;
        public double HeatRate;
    }
}
