using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace Assets.Scripts
{
    public class UIManager : MonoBehaviour
    {
        //экземпляр класса
        public static UIManager Instance { get; private set; }
        [SerializeField]
        private TMP_Dropdown dropdown_from;
        [SerializeField]
        private TMP_Dropdown dropdown_to;
        [SerializeField]
        private Button create_path;
        private Dictionary<string, Coordinate> DropdownData;

        public UIManager()
        {
            if(Instance == null)
                Instance = this;
        }

        public void SetValues(List<Coordinate> coordinates)
        {
            DropdownData = coordinates.ToDictionary(x => $"Точка: {x.X} {x.Y}", x => x);
            List<string> coordinate_string = DropdownData.Keys.ToList();

            dropdown_from.ClearOptions();
            dropdown_to.ClearOptions();

            dropdown_from.AddOptions(coordinate_string);
            dropdown_to.AddOptions(coordinate_string);
        }
        public void SubmitPath()
        {
            int dropdown_from_value = dropdown_from.value;
            string dropdown_from_message = dropdown_from.options[dropdown_from_value].text;

            int dropdown_to_value = dropdown_to.value;
            string dropdown_to_message = dropdown_to.options[dropdown_to_value].text;

            if (dropdown_from_message != null
                && dropdown_to_message != null 
                && DropdownData.ContainsKey(dropdown_from_message) 
                && DropdownData.ContainsKey(dropdown_to_message))
            {
                MapManager.Instance.CreatePath(DropdownData[dropdown_from_message], DropdownData[dropdown_to_message]);
            }

            //взять данные из dropdown, привести в нормальный внешний вид
            //обратиться к mapmanager и вызвать createPath
        }
    }

}

//добавить этаж, расставить точки вручную, записать их кооридинаты
//в новом тестовой репозитроии добавить эти точки 
