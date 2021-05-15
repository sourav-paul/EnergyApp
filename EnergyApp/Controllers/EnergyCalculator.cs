using EnergyApp.DataModels;
using EnergyApp.DataModels.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyApp.Controllers
{
    public class EnergyCalculator
    {
        public double DailyGenerationValue(Day day, double valueFactor)
        {
            return day.Energy * day.Price * valueFactor;
        }

        public double DailyEmissions(Day day, double emissionRating, EmissionsFactor emissionsFactor)
        {
            return day.Energy * emissionRating * emissionsFactor.Medium;
        }

        public double ActualHeatRate(double totalHeatInput, double actualNetGeneration)
        {
            return totalHeatInput * actualNetGeneration;
        }
    }
}
