using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProcedualGalaxyGame.Interface;

namespace ProcedualGalaxyGame.Core
{
    class System : ISystem
    {
        public string Name { get; set; }
        public float Speed { get; set; }

        public IBody[] Bodies { get; set; }

    }
}
