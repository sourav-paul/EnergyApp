﻿using System;
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
    }
    
    public class Generator
    {
        public string Name;
        public double Total;
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
