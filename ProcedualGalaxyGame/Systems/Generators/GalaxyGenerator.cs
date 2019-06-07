using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProcedualGalaxyGame.Core;
using ProcedualGalaxyGame.Interface;

namespace ProcedualGalaxyGame.Systems.Generators
{
    public static class GalaxyGenerator
    {

        private static int MaxSystems = 100;

        public static Galaxy Generate()
        {
            Galaxy Galaxy = new Galaxy();
            Galaxy.Name = "Milky Way";

            Galaxy.Systems = new ISystem[MaxSystems];

            for(int i = 0; i < MaxSystems; i++)
            {
                Galaxy.Systems[i] = SystemGenerator.GeneratePlanetarySystem();
            }

            return Galaxy;
        }

    }
}
