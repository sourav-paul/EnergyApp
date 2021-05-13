using System;
using System.Collections.Generic;

namespace EnergyApp.DataModels
{
    public class Day
    {
        public DateTime Date;
        public double Energy;
        public double Price;
    }

    public enum Location
    {
        NotSet = -1,
        Onshore = 0,
        Offshore = 1
    }

    public class GenerationReport
    {
        public List<WindGenerator> Wind;
        public List<GasGenerator> Gas;
        public List<CoalGenerator> Coal;
    }

    public class EnergyGenerator
    {
        public string Name;

        public List<Day> Generation;
    }

    public class WindGenerator : EnergyGenerator
    {
        public Location Location;
    }
    public class GasGenerator : EnergyGenerator
    {
        public double EmissionsRating;
    }

    public class CoalGenerator : EnergyGenerator
    {
        public double TotalHeatGeneration;
        public double ActualNetGeneration;
        public double EmissionsRating;
    }
}
