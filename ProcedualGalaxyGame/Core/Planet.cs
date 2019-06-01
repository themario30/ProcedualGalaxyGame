using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Interface;

namespace ProcedualGalaxyGame.Core
{
    public class Planet : IBody
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public RLColor Color { get; }

        public Planet(string name, string type, RLColor color)
        {
            this.Name = name;
            this.Type = type;
            this.Color = color;
        }
    }
}
