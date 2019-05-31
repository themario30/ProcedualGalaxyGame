using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedualGalaxyGame.Interface

{
    interface ISystem
    {
        string Name { get; set; }
        float Speed { get; set; }

        IBody[] Bodies {get; set;}
       
    }
}
