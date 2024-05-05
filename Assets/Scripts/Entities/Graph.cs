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
        this.CreateGraph();
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
    public void PrintGraph()
    {
        for (int i = 0; i < points.Count; i++)
        {
            for (int j = 0; j < points.Count; j++)
            {
                Console.Write(string.Format("{0:f1}", Matrix[i, j] + "\t"));
            }
            Console.WriteLine();
        }
        Console.ReadLine();
    }

    public List<Coordinate> FindPath(Coordinate start, Coordinate end)
    {
        int start_index = points.IndexOf(start);
        int end_index = points.IndexOf(end);
        bool[] visited = new bool[points.Count];
        Queue<int> queue = new Queue<int>();

        visited[start_index] = true;
        queue.Enqueue(start_index);

        while (queue.Count > 0)
        {
            int current_node = queue.Dequeue();

            if (current_node == end_index)
            {
                // Reconstruct path by backtracking 
                List<Coordinate> path = new List<Coordinate>();
                int prev = current_node;
                while (prev != -1)
                {
                    path.Insert(0, points[prev]);
                    prev = FindParrent(visited, prev);
                }
                return path;
            }

            for (int neighbor = 0; neighbor < points.Count; neighbor++)
            {
                if (Matrix[current_node, neighbor] < double.MaxValue && !visited[neighbor]) // Check for valid connection and unvisited node 
                {
                    visited[neighbor] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }

        return new List<Coordinate>(); // No path found 
    }

    private int FindParrent(bool[] visited, int node)
    {
        for (int i = 0; i < points.Count; i++)
        {
            if (visited[i] && Matrix[i, node] < double.MaxValue) // Check for visited parent with a connection 
            {
                return i;
            }
        }
        return -1; // No parent found (shouldn't happen in BFS) 
    }
}

