using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

public class Graph
{
    public List<Coordinate> points = new List<Coordinate>();
    public List<Edge> edges = new List<Edge>();

    public double[,] Matrix;

    public Graph(List<Coordinate> points, List<Edge> edges)
    {
        this.points = points;
        this.edges = edges;
        Matrix = new double[points.Count, points.Count];
    }

    public void CreateGraph()
    {
        for (int i = 0; i < points.Count; i++)
        {
            for (int j = 0; j < points.Count; j++)
            {
                var edge = edges.FirstOrDefault(e =>
                {
                    return e.First == points[i] && e.Second == points[j] || e.Second == points[i] && e.First == points[j];
                });
                if (edge != null)
                {
                    Matrix[i, j] = edge.Length;
                }
                else
                {
                    Matrix[i, j] = 0;
                }

            }
        }
    }

    public override string ToString()
    {
        var res = new StringBuilder();
        for (int i = 0; i < points.Count; i++)
        {
            for (int j = 0; j < points.Count; j++)
            {
                res.Append(string.Format("{0:f1}", Matrix[i, j] + "\t"));
            }
            res.AppendLine();
        }
        return res.ToString();
    }

    public double Dijkstra(Coordinate start, Coordinate end)
    {
        Dictionary<Coordinate, double> distances = new Dictionary<Coordinate, double>();
        HashSet<Coordinate> visited = new HashSet<Coordinate>();

        foreach (var point in points)
        {
            distances[point] = double.PositiveInfinity;
        }

        distances[start] = 0;

        while (visited.Count < points.Count)
        {
            Coordinate current = null;
            double minDistance = double.PositiveInfinity;

            foreach (var point in points)
            {
                if (!visited.Contains(point) && distances[point] < minDistance)
                {
                    current = point;
                    minDistance = distances[point];
                }
            }

            if (current == null)
            {
                break;
            }

            visited.Add(current);

            foreach (var edge in edges)
            {
                if (edge.First == current)
                {
                    double distanceThroughCurrent = distances[current] + edge.Length;
                    if (distanceThroughCurrent < distances[edge.Second])
                    {
                        distances[edge.Second] = distanceThroughCurrent;
                    }
                }
            }
        }

        return distances[end];
    }

    public List<Coordinate> ShortestWay(Coordinate start, Coordinate end)
    {
        Dictionary<Coordinate, double> distances = new Dictionary<Coordinate, double>();
        // ������� ��� �������� �������������� ����� �� ���������� ����
        Dictionary<Coordinate, Coordinate> previous = new Dictionary<Coordinate, Coordinate>();
        HashSet<Coordinate> visited = new HashSet<Coordinate>();

        foreach (var point in points)
        {
            distances[point] = double.PositiveInfinity;
        }

        distances[start] = 0;

        while (visited.Count < points.Count)
        {
            Coordinate current = null;
            double minDistance = double.PositiveInfinity;

            foreach (var point in points)
            {
                if (!visited.Contains(point) && distances[point] < minDistance)
                {
                    current = point;
                    minDistance = distances[point];
                }
            }

            if (current == null)
            {
                break;
            }

            visited.Add(current);

            foreach (var edge in edges)
            {
                if (edge.First == current)
                {
                    double distanceThroughCurrent = distances[current] + edge.Length;
                    if (distanceThroughCurrent < distances[edge.Second])
                    {
                        distances[edge.Second] = distanceThroughCurrent;
                        previous[edge.Second] = current; // ��������� �������������� ������� �� ���������� ����
                    }
                }
            }
        }

        // ������������ ������ ����� ����������� ����
        List<Coordinate> shortestPath = new List<Coordinate>();
        Coordinate currentPoint = end;

        while (currentPoint != null)
        {
            shortestPath.Insert(0, currentPoint); // ��������� ������� ����� � ������ ������ (����� ���� ��� � ������� �� ������ � �����)
            currentPoint = previous.ContainsKey(currentPoint) ? previous[currentPoint] : null; // ��������� � �������������� ����� �� ���������� ����
        }

        return shortestPath;
    }
}

