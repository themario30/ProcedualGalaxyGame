using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Interface;

namespace ProcedualGalaxyGame.Core
{
    public class SpaceSystem : ISystem
    {
        public string Name { get; set; }
        public float Speed { get; set; }

        public IBody[] Bodies { get; set; }
        public Random r;

        public Star Star;

        public void Draw(RLConsole map, int width, int height)
        {
            map.Print(width / 2, height / 2, "O", Star.Color);

            r = new Random();

            float radius = (height - 1) / 2;

            for (int i = 1; i < Bodies.Length; i++)
            {
                float distanceFromSun = radius / (i - Bodies.Length);

                if (Bodies[i] == null)
                    continue;

                for (int j = 0; j < 90; j++)
                {
                    int xOrbit = (int)(distanceFromSun * Math.Sin(j));
                    int yOrbit = (int)(distanceFromSun * Math.Cos(j));

                    map.Print(width / 2 - xOrbit, height/2 - yOrbit, ".", RLColor.White);
                }

                double angle = r.Next(0, 360);



                //converts the angle from degree to radians
                angle = angle * (Math.PI / 180);

                int x = (int)(distanceFromSun * Math.Sin(angle));
                int y = (int)(distanceFromSun * Math.Cos(angle));

                Console.WriteLine($"({x},{y}) Radius: {distanceFromSun}");

                map.Print(width/2 - x, height/2 - y, "o", Bodies[i].Color);

            }
        }

    }
}
