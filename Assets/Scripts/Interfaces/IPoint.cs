using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IPoint
    {
        public Coordinate Coordinate { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }        
        
    }
}
