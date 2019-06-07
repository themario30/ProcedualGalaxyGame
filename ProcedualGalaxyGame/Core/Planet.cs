using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RLNET;
using ProcedualGalaxyGame.Interface;
using ProcedualGalaxyGame.Systems;

namespace ProcedualGalaxyGame.Core
{
    public class Planet : IBody, IDrawable
    {

        //IBody Interfaces
        public string Name { get; set; }
        public PlanetType PlanetType;

        public IBody Parent { get; private set; }

        public float distanceFromParent { get; private set; }

        //the size of the planet, based on the radius from the core to the surface.
        public float radius = 5f;

        //IDrawable Interfaces
        public RLColor Color { get; }

        public Planet(string name, PlanetType type, RLColor color)
        {
            this.Name = name;
            this.PlanetType = type;
            this.Color = color;

        }

        public Planet(string name, PlanetType type, RLColor color, IBody parent, float distanceFromParent = 0f)
        {
            this.Name = name;
            this.PlanetType = type;
            this.Color = color;
            this.Parent = parent;
            this.distanceFromParent = distanceFromParent;
        }

        public void setParent(IBody parent, float distanceFromParent)
        {
            this.Parent = parent;
            this.distanceFromParent = distanceFromParent;
        }
    }
}
