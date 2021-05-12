using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyApp.DataModels
{
    class DataModels
    {
    }

    public class Day
    {
        public DateTime Date;
        public double Energy;
        public double price;
    }

    public enum Location
    {
        NotSet = -1,
        Onshore = 0,
        Offshore = 1
    }

    public class EnergySource
    {
        public string Name;

        public List<Day> Generation;
    }
    public class Wind : EnergySource
    {
        public Location Location;
    }
    public class Gas : EnergySource
    {
        public double EmissionsRating;
    }

    public class Coal : EnergySource
    {
        public double TotalHeatGeneration;
        public double ActualNetGeneration;
        public double EmissionsRating;
    }
}
