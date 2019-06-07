using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcedualGalaxyGame.Interface
{
    public interface IBody : IDrawable
    {
        string Name { get; set; }

        IBody Parent { get; }

        /// <summary>
        /// The Distance from the Parent to their child shall be dependant on the Astronomical unit (AU). 1 AU is 50 million kilometres.
        /// </summary>
        float distanceFromParent { get; }
    }
}
