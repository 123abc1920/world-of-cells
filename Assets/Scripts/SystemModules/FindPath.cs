using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
public class FindPath
{
    private static List<int> getAvailableCells(int cell, int[] a)
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
    public static int findPath(int start, int target, int[] a)
    {
        Queue<int> queue = new Queue<int>();
        List<int> showns = new List<int>();
        Dictionary<int, int> path = new Dictionary<int, int>();
        path.Add(start, -1);

        int p = start;
        queue.Enqueue(p);
        while (p != target && queue.Count > 0)
        {
            p = queue.Dequeue();
            showns.Add(p);

            for (int i = 0; i < getAvailableCells(p, a).Count; i++)
            {
                int probe = Math.Min(99, Math.Max(0, p - a[i]));
                if (!showns.Contains(probe) && Consts.game.cells[probe].isAlive && !Consts.game.cells[probe].isHut && Consts.game.cells[probe].isPreAlive)
                {
                    queue.Enqueue(probe);
                    if (!path.Keys.Contains(probe))
                    {
                        path.Add(probe, p);
                    }
                }
            }
        }

        int step = target;
        while (step != -1)
        {
            if (path[step] == start)
            {
                return step;
            }
            step = path[step];
        }

        return -1;
    }
}