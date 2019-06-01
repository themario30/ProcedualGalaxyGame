using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedualGalaxyGame.Interface
{
    public interface IBody
    {
        string Name { get; set; }
        string Type { get; set; }

        RLNET.RLColor Color { get; }
    }
}
