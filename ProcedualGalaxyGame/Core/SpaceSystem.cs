using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Interface;
using ProcedualGalaxyGame.Systems;

namespace ProcedualGalaxyGame.Core
{
    public class SpaceSystem : ISystem, IDrawable
    {
        public string Name { get; set; }
        public float Speed { get; set; }

        public IBody[] Bodies { get; set; }
        public Random r;

        public RLColor Color { get; }

        public Star Star;

        public void Draw(RLConsole map, int width, int height)
        {
            map.Print(width / 2, height / 2, "O", Star.Color);

            r = new Random();

            drawSystemMap(map, width, height);
        }

        private void drawSystemMap(RLConsole map, int width, int height, bool showName = true,bool drawOrbitLines = true)
        {
            //Draw a Space System with each planet along a sun.
            //Draw the orbits of a system

            float radius = height / 2;

            // For loop starts at one because the sun is the first body in the system.
            for (int i = 1; i < Bodies.Length; i++)
            {

                float distanceFromSun = ((float)i / Bodies.Length) * radius;
                float angle = (float)(r.Next(0, 360) * GameLogic.DEG2RAD);

                //Console.WriteLine($"Distance {Bodies.Length} Angle {angle}");

                if(drawOrbitLines)
                {
                    int orbitDots = 18 * i;
                    for (int j = 0; j < 360; j += (360 / orbitDots))
                    {
                        int xOrbit = (int)(distanceFromSun * Math.Sin(j * GameLogic.DEG2RAD));
                        int yOrbit = (int)(distanceFromSun * Math.Cos(j * GameLogic.DEG2RAD));

                        map.Print(xOrbit + width/2, yOrbit + height/2, ".", RLColor.White);
                    }

                }

                int x = (int)(distanceFromSun * Math.Sin(angle));
                int y = (int)(distanceFromSun * Math.Cos(angle));

                map.Print(x + width/2, y + height/2, "o", Bodies[i].Color);
                map.Print(x + width / 2 - Bodies[i].Name.Length/2, y + 1 + height / 2, Bodies[i].Name, Bodies[i].Color);

                //Console.WriteLine($"Planet {Bodies[i].Name} ({x},{y}) Radius: {distanceFromSun}");
            }
            
        }


        private void drawOrbits(RLConsole map, int width, int height, float radius)
        {
            for (int j = 0; j < 360; j += (360/ 20))
            {

                int xOrbit = (int)(radius * Math.Sin(j * (Math.PI / 180)));
                int yOrbit = (int)(radius * Math.Cos(j * (Math.PI / 180)));

                map.Print(width / 2 - xOrbit, height / 2 - yOrbit, ".", RLColor.White);
            }
        }

        //below
        /*
        private void drawSystemMap(RLConsole map, int width, int height)
        {
            float farestPlanetDistance = 0f;
            float nearestPlanetDistance = float.MaxValue;

            foreach(IBody body in Bodies)
            {
                farestPlanetDistance = Math.Max(farestPlanetDistance, body.distanceFromParent);
            }

            foreach(IBody body in Bodies)
            {
                if (body != Star)
                    nearestPlanetDistance = Math.Min(nearestPlanetDistance, body.distanceFromParent);
            }

            Console.WriteLine($"Farest Planet Distance: {farestPlanetDistance}");
            Console.WriteLine($"Nearest Planet Distance: {nearestPlanetDistance}");
            

            for (int i = 1; i < Bodies.Length; i++)
            {
                float radius = GameLogic.Lerp(5, (height) / 2, (((Bodies[i].distanceFromParent - nearestPlanetDistance) / farestPlanetDistance)));
                drawOrbits(map, width, height, radius);
            }

                for (int i = 1; i < Bodies.Length; i++)
            {


                float radius = GameLogic.Lerp(5, (height) / 2, (((Bodies[i].distanceFromParent - nearestPlanetDistance) / farestPlanetDistance)));

                Console.WriteLine($"Radius value: {radius}");

                if (Bodies[i] == null)
                    continue;

                double angle = r.Next(0, 360);



                //converts the angle from degree to radians
                angle = angle * (Math.PI / 180);

                int x = (int)(radius * Math.Sin(angle));
                int y = (int)(radius * Math.Cos(angle));

                Console.WriteLine($"({x},{y}) Radius: {radius} Angle: {angle * (180 / Math.PI)}");

                map.Print(width / 2 - x, height / 2 - y, "o", Bodies[i].Color);
                map.Print(width / 2 - x, height / 2 - y + 1, Bodies[i].Name, Bodies[i].Color);

            }
        }
        */

    }
}
