using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Core;
using ProcedualGalaxyGame.Systems;

namespace ProcedualGalaxyGame.Systems.Generators
{
    public static class StarGenerator
    {
        
        public static Star Generate()
        {
            Star star = new Star();

            int temperature = RandomNumberGenerator.Range(2400, 52000);

            //Determinme Type of Star
            if(temperature < 3700)
            {
                star.Type = "M";
                star.SetColor(new RLColor(255, 0, 0));
            }
            else if(temperature < 5200)
            {
                star.Type = "K";
                star.SetColor(new RLColor(255, 218, 181));
            }
            else if (temperature < 6000)
            {
                star.Type = "G";
                star.SetColor(new RLColor(255, 237, 227));
            }
            else if (temperature < 7500)
            {
                star.Type = "F";
                star.SetColor(new RLColor(255, 255, 255));
            }
            else if(temperature < 10000)
            {
                star.Type = "A";
                star.SetColor(new RLColor(213, 224, 255));
            }
            else if (temperature < 30000)
            {
                star.Type = "B";
                star.SetColor(new RLColor(162,192,255));
            }
            else
            {
                star.Type = "O";
                star.SetColor(new RLColor(146, 181, 255));
            }

            int size = RandomNumberGenerator.Range(0, 10);

            switch(size)
            {
                case 1:
                    //Hypergiants
                    star.Type = star.Type + "0";
                    break;
                case 2:
                    //luminous supergiants or intermediate-size luminous supergiants
                    size = RandomNumberGenerator.Range(1, 2);
                    if (size == 2)
                        star.Type = star.Type + "Ia";
                    else
                        star.Type = star.Type + "Iab";
                    break;
                case 3:
                    //less luminous supergiants
                    star.Type = star.Type + "Ib";
                    break;
                case 4:
                    //bright giants
                    star.Type = star.Type + "II";
                    break;
                case 5:
                    //normal giants
                    star.Type = star.Type + "III";
                    break;
                case 6:
                    // 	subgiants
                    star.Type = star.Type + "IV";
                    break;
                case 7:
                    //main-sequence stars (dwarfs) 
                    star.Type = star.Type + "V";
                    break;
                case 8:
                    //subdwarfs
                    star.Type = star.Type + "VI";
                    break;
                case 9:
                    //white dwarfs
                    star.Type = star.Type + "VII";
                    break;
                case 10:
                    size = RandomNumberGenerator.Range(1, 10);
                    if(size != 10)
                        //white dwarfs  
                        star.Type = star.Type + "VII";
                    else
                        //the dwarves of all dwarves!
                        star.Type = star.Type + "VIII";
                    break;
            }

            return star;
        }
    }
}
