using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
public class GetAvailableCells
{
    public static List<int> getAvailableCells(int cell, int[] a)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < a.Length; i++)
        {
            int index = cell + a[i];

            if (index < 100 && index >= 0 && Consts.game.cells[index].isPreAlive && !Consts.game.cells[index].isHut && Consts.game.cells[index].isAlive)
            {
                if (!(cell % 10 == 0 && index % 10 == 9))
                {
                    if (!(cell % 10 == 9 && index % 10 == 0))
                    {
                        result.Add(index);
                    }
                }
            }
        }

        return result;
    }
}