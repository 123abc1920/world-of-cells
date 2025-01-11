using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript
{
    
    public static int[] getAvailableCells(int cell, int[] a) {
        if (a.Length==2)
        {
            return new int[] {cell+a[0], cell-a[0], cell-a[1], cell+a[1]};
        }
        if (a.Length==4)
        {
            return new int[] {cell+a[0], cell-a[0], cell-a[1], cell+a[1], cell+a[2], cell-a[2], cell-a[3], cell+a[3]};
        }
        return new int[] {};
    }

}
