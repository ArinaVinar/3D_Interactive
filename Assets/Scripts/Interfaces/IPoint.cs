using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IPoint
    {
        Coordinate Coordinate { get; set; }
        bool Active { get; set; }
        string Type { get; set; }        
        
    }
}
