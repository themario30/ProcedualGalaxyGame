using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedualGalaxyGame.Systems
{
    public static class RandomNumberGenerator
    {
        private static Random Random;

        public static int Range(int min, int max)
        {
            if (Random == null)
                Random = new Random();

            return Random.Next(min, max);
        }

    }
}
