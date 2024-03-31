using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Interfaces;

namespace Assets.Scripts.Entities.Add_Info
{
    internal class Auditorium : Point
    {
        int buildingId { get; set; }
        string Info { get; set; }

    }
}
