using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Entities.Add_Info;

public class Edge
{
    public Coordinate First;
    public Coordinate Second;


    public Edge(Coordinate first, Coordinate second)
    {
        First = first;
        Second = second;
    }

    public double Length
    {
        get { return Math.Sqrt(Math.Pow(Second.X - First.X, 2) + Math.Pow(Second.Y - First.Y, 2)); }
    }
}
