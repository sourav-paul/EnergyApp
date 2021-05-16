using EnergyApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EnergyApp.DataModels
{
    public class ReferenceData
    {
        public Factors Factors;

        public ReferenceData()
        {
            Factors = new Factors();
        }
    }

    public class Factors
    {
        public ValueFactor ValueFactor;
        public EmissionsFactor EmissionsFactor;

        public Factors()
        {
            ValueFactor = new ValueFactor();
            EmissionsFactor = new EmissionsFactor();
        }
    }

    public class ValueFactor
    {
        public double High;
        public double Medium;
        public double Low;
    }

    public class EmissionsFactor
    {
        public double High;
        public double Medium;
        public double Low;
    }
}
