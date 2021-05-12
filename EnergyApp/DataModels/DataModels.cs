using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EnergyApp.DataModels
{
    class DataModels
    {

    }

    [Serializable]
    public class Day
    {
        [XmlElement("Date")]
        public DateTime Date;
        [XmlElement("Enerygy")]
        public double Energy;
        [XmlElement("Price")]
        public double Price;
    }

    [Serializable]
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

    [Serializable]
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
