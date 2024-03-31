using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Entities.Add_Info
{
    internal class Point : IPoint
    {
        Coordinate IPoint.Coordinate { get; set; }
        bool IPoint.Active { get; set; }
        string IPoint.Type { get; set; }
    }
}
