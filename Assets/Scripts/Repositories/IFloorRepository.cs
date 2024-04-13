using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Entities.Add_Info;

namespace Assets.Scripts.Repositories
{
    public interface IFloorRepository
    {
        public Floor Get(int number);
        public List<Floor> GetAll();

    }
}
