using Assets.Scripts.Entities.Add_Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PointGameObject : MonoBehaviour
    {
        private Point pointData;

        public Point PointData
        {
            get
            {
                return pointData;
            }
            set 
            {
                if (pointData == null)
                    pointData = value;
                else
                    Debug.Log("Пошел нахуй");
            }
        }

    }
}
