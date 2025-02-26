using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;
public class FindPath
{
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

            List<int> availableCells = GetAvailableCells.getAvailableCells(p, a);
            for (int i = 0; i < availableCells.Count; i++)
            {
                int probe = Math.Min(99, Math.Max(0, availableCells[i]));
                if (!showns.Contains(probe))
                {
                    queue.Enqueue(probe);
                    if (!path.Keys.Contains(probe))
                    {
                        path.Add(probe, p);
                    }
                }
            }
        }

        if (p != target)
        {
            return -1;
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