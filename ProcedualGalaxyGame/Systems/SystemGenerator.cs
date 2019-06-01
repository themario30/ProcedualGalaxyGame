using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Core;
using ProcedualGalaxyGame.Interface;

namespace ProcedualGalaxyGame.Systems
{
    class SystemGenerator
    {
        private static readonly int maxPlanets = 4;

        public static SpaceSystem CreateSystem()
        {
            SpaceSystem map = new SpaceSystem();

            map.Name = "Sol";
            map.Speed = 5f;
            

            map.Bodies = new IBody[maxPlanets];

            map.Star = new Star("The Sun", "Sun", RLColor.Yellow);
            map.Bodies[0] = map.Star;


            map.Bodies[1] = new Planet("Earth", "Planet", RLColor.Blue);
            map.Bodies[2] = new Planet("Mars", "Planet", RLColor.Red);

            return map;
        }
    }
}
