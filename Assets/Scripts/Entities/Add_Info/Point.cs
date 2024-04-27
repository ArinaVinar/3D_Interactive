using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Entities.Add_Info
{
    public class Point : IPoint
    {
        public Point()
        {
            Coordinate = new Coordinate(0, 0);
            Active = true;
            Type = "Undefined";
        }
        public Point(Coordinate coordinate, bool active, string type)
        {
            Coordinate = coordinate;
            Active = active;
            Type = type;
        }

        public Coordinate Coordinate { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
    }
}
