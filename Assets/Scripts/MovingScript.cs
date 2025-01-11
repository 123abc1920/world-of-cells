using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovingScript
{
    
    public static int[] getAvailableCells(int cell, int[] a) {
        if (a.Length==2)
        {
            return new int[] {Math.Max(0, Math.Min(99, cell+a[0])), Math.Max(0, Math.Min(99, cell-a[0])), Math.Max(0, Math.Min(99, cell-a[1])), Math.Max(0, Math.Min(99, cell+a[1]))};
        }
        if (a.Length==4)
        {
            return new int[] {Math.Max(0, Math.Min(99, cell+a[0])), Math.Max(0, Math.Min(99, cell-a[0])), Math.Max(0, Math.Min(99, cell-a[1])), Math.Max(0, Math.Min(99, cell+a[1])), Math.Max(0, Math.Min(99, cell+a[2])), Math.Max(0, Math.Min(99, cell-a[2])), Math.Max(0, Math.Min(99, cell-a[3])), Math.Max(0, Math.Min(99, cell+a[3]))};
        }
        return new int[] {};
    }

}
