using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProcedualGalaxyGame.Interface;
using RLNET;

namespace ProcedualGalaxyGame.Core
{
    //this class is for objects in space who are not planets and suns
    public class Body : IBody, IDrawable
    {
        //IBody Interface
        public string Name { get; set; }
        public string Type { get; set; }

        public IBody Parent { get; }

        public float distanceFromParent { get; }

        //IDrawable Interface
        public RLColor Color { get; }
    }
}
