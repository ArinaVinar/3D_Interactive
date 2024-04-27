using Assets.Scripts.Entities.Add_Info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts.Repositories
{
    public class DebugFloorRepository : IFloorRepository
    {
        private List<Floor> floors = new List<Floor>();
        private Random r = new Random();

        //size - кол-во точек в графе
        public DebugFloorRepository(int size = 5)
        {
            List<Point> points = new List<Point>();
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < size; i++)
                points.Add(new Point()
                {
                    Coordinate = new(r.Next(-50, 50) / 10f, r.Next(-50, 50) / 10f),
                    Active = true,
                    Type = "yes"
                });

            for (int i = 0; i < size - 1; i++)
                edges.Add(new Edge(points[i].Coordinate, points[i + 1].Coordinate));

            var additionalEdges = r.Next(0, size - 1);

            for (int i = 0; i < additionalEdges; i++)
            {
                int indA = r.Next(0, size - 1);
                int indB = r.Next(0, size - 1);
                if (indA == indB || indA + 1 == indB) //нужно чтобы убрать петли и не повторять пути
                {
                    //indB = r.Next(0, size - 1);
                    continue;
                }
                else
                {
                    edges.Add(new Edge(points[indA].Coordinate, points[indB].Coordinate));
                }
            }
            List<Coordinate> point_coordinate = new List<Coordinate>();
            for (int i = 0; i < points.Count; i++)
            {
                point_coordinate.Add(points[i].Coordinate);
            }
            Graph graph = new Graph(point_coordinate, edges);
            //Graph graph = new Graph(points.Select(p => p.Coordinate).ToList(), edges.ToList());

            floors.Add(new Floor()
            {
                Number = 16,
                Info = "yes",
                Status = true,
                Graph = graph
            });
        }

        public Floor Get(int number)
        {
            // найти этаж с номером number и записать в переменную
            // проверить равна ли переменная null, если равна, вернуть ошибку
            // иначе вернуть результат

            var result = floors.Find((floor) => floor.Number == number);
            if (result == null)
                throw new Exception("error ёпта");
            return result;
        }

        public List<Floor> GetAll()
        {
            return floors;
        }
    }
}
