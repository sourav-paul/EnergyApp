using EnergyApp.DataModels;
using EnergyApp.DataModels.GeneratorFactor;
using EnergyApp.DataModels.Report;
using EnergyApp.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnergyApp.Controllers
{
    class GeneratorFactorMapController
    {
        private ReferenceData ReferenceData;
        private GeneratorFactorMap GeneratorFactorMap;

        public GeneratorFactorMapController()
        {
            ReferenceData = new ReferenceData();
            GeneratorFactorMap = new GeneratorFactorMap();

            LoadData();
        }

        private void LoadData()
        {
            ReferenceData = XmlParser.ReadReference();
            GeneratorFactorMap = XmlParser.ReadMap();
        }

        public void GetFactor(EnergyGenerator generator)
        {
            if (generator.Equals(typeof(WindGenerator)))
            {
                if (((WindGenerator)generator).Location == Location.Offshore)
                {

                }
                else if (((WindGenerator)generator).Location == Location.Onshore)
                {

                }
            }
            else if (generator.Equals(typeof(GasGenerator)))
            {

            }
            else if (generator.Equals(typeof(CoalGenerator)))
            {

            }
            else
            {
                Console.WriteLine("Unknown Generator Type");
            }

        }
    }
}
