﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProcedualGalaxyGame.Interface;

namespace ProcedualGalaxyGame.Core
{
    public class Star : IBody
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public RLNET.RLColor Color { get; }

        public Star(string name, string type, RLNET.RLColor color)
        {
            this.Name = name;
            this.Type = type;
            this.Color = color;
        }
    }
}
