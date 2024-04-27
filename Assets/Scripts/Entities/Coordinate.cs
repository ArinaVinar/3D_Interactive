using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Coordinate
{
    public double X;
    public double Y;
    public int FloorNumber;

    public Coordinate(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"[{X},{Y}]";
    }
}

