using EnergyApp.DataModels;
using EnergyApp.DataModels.Report;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyApp.Controllers
{
    public class EnergyCalculator
    {
        public static double? DailyGenerationValue(Day day, double? valueFactor)
        {
            if (valueFactor !=null)
            {
                return day.Energy * day.Price * valueFactor;
            }
            else
            {
                Console.WriteLine("Value Factor null");
                return null;
            }
        }

        public static double? DailyEmissions(Day day, double emissionRating, double? emissionsFactor)
        {
            return day.Energy * emissionRating * emissionsFactor;
        }

        public static double ActualHeatRate(double totalHeatInput, double actualNetGeneration)
        {
            return totalHeatInput * actualNetGeneration;
        }
    }
}
