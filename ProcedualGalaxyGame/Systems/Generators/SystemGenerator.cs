using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Core;
using ProcedualGalaxyGame.Interface;
using ProcedualGalaxyGame.Systems.Generators;

namespace ProcedualGalaxyGame.Systems
{
    public static class SystemGenerator
    {
        private static readonly int maxPlanets = 6;

        public static SpaceSystem GeneratePlanetarySystem()
        {

            SpaceSystem system = new SpaceSystem();

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string Designation1 = $"{alphabet[RandomNumberGenerator.Range(0, 25)]}{alphabet[RandomNumberGenerator.Range(0, 25)]}";
            string Designation2 = $"{RandomNumberGenerator.Range(0, 999)}";

            system.Name = $"{Designation1}-{Designation2}";
            system.Speed = 5f;

            system.Bodies = new IBody[RandomNumberGenerator.Range(1, maxPlanets)];

            system.Star = StarGenerator.Generate();
            system.Name = system.Name;
            system.Bodies[0] = system.Star;

            for (int i = 1; i < system.Bodies.Length; i++)
            {
                system.Bodies[i] = generatePlanet($"{system.Name} {i}", system.Star);
            }

            return system;
        }

        public static Planet generatePlanet(string name, IBody parent = null)
        {
            Planet temp = new Planet(name, (PlanetType)RandomNumberGenerator.Range(0, Enum.GetNames(typeof(PlanetType)).Length),RLColor.Cyan, parent);
            return temp;
        }


        public static SpaceSystem CreateSolarSystem()
        {
            SpaceSystem map = new SpaceSystem();

            map.Name = "Sol";
            map.Speed = 5f;
            

            map.Bodies = new IBody[maxPlanets];

            map.Star = new Star("The Sun", "Sun", RLColor.Yellow);
            map.Bodies[0] = map.Star;


            map.Bodies[1] = new Planet("Mercury", PlanetType.NonHabitable, RLColor.Brown, map.Star, 0.39f);
            map.Bodies[2] = new Planet("Earth", PlanetType.Earthlike, RLColor.Blue, map.Star, 1f);
            map.Bodies[3] = new Planet("Mars", PlanetType.Marslike, RLColor.Red, map.Star, 1.524f);

            return map;
        }
    }
}
