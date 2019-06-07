using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedualGalaxyGame.Systems
{
    //this class will be used in case I can't find a function which will help me with math stuff
    public class GameLogic
    {

        public static double DEG2RAD = (Math.PI / 180f);

        //snatched from Wikipedia
        // Precise method, which guarantees v = v1 when t = 1.
        public static float Lerp(float v0, float v1, float t)
        {
            return (1 - t) * v0 + t * v1;
        }
    }
}
