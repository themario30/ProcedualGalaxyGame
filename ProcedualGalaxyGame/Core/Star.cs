using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using RLNET;
using ProcedualGalaxyGame.Interface;

namespace ProcedualGalaxyGame.Core
{
    public class Star : IBody, IDrawable
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public IBody Parent { get; }
        public float distanceFromParent { get; }


        public RLNET.RLColor Color { get; private set; }

        /// <summary>
        /// The Temperature relies in K (Kelvin).
        /// </summary>
        public int Temperature;

        public Star()
        {
            distanceFromParent = 1f;
            this.Color = RLNET.RLColor.Yellow;
        }

        public Star(string name, string type, RLColor color)
        {
            this.Name = name;
            this.Type = type;
            this.Color = color;
            distanceFromParent = 1f;
        }

        public void SetColor(RLColor color)
        {
            this.Color = color;
        }
    }



}
