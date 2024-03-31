using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Entities.Add_Info
{
    internal class ChowPoint : Point
    {
        string Info { get; set; }
        int buildingId { get; set; }
    }
}
