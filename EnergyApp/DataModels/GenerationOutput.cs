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
        public string Name = "Unnamed";
        public double? Total = 0.0;
    }

    public class Day
    {
        public string Name = "Unnamed";
        public DateTime Date = new DateTime();
        public double? Emissions = null;
    }

    public class ActualHeatRate
    {
        public string Name = "Unnamed";
        public double? HeatRate = null;
    }
}
