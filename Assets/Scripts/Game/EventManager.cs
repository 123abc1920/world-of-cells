using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static Event[] events = new Event[9];

    public static int[] variances = new int[25];

    public static List<int> collection;

    private static System.Random random = new System.Random();

    static EventManager()
    {
        collection = DataScript.LoadData();

        createEvents();

        int k = 0;
        for (int i = 0; i < events.Length; i++)
        {
            for (int j = 0; j < events[i].periodicity; j++)
            {
                variances[k] = i;
                k++;
            }
        }
    }

    public static void eventAction(Event e)
    {
        if (!collection.Contains(e.id))
        {
            collection.Add(e.id);
            DataScript.SaveData(collection);
        }
        e.Trigger();
    }

    private static void createEvents()
    {
        events[0] = new Event(0, 5, () =>
        {
            Consts.game.tree += 10;
            Consts.game.water += 10;
            Consts.game.rock += 10;
        });
        events[1] = new Event(1, 2, () =>
        {
            Consts.game.tree -= 10;
        });
        events[2] = new Event(2, 2, () =>
        {
            Consts.game.tree -= 10;
            Consts.game.water -= 10;
            Consts.game.rock -= 10;
        });
        events[3] = new Event(3, 2, () =>
        {
            Consts.game.tree -= 15;
            Consts.game.water -= 15;
            Consts.game.rock -= 15;
        });
        events[4] = new Event(4, 3, () =>
        {
            foreach (Cell c in Consts.game.cells)
            {
                if (c.type == CellTypes.WATER && c.isAlive && !c.isBridge && !c.isHut)
                {
                    c.refreshCell();
                }
            }
        });
        events[5] = new Event(5, 3, () =>
        {
            foreach (Cell c in Consts.game.cells)
            {
                if (c.type == CellTypes.ROCK && c.isAlive && !c.isBridge && !c.isHut)
                {
                    c.refreshCell();
                }
            }
        });
        events[6] = new Event(6, 3, () =>
        {
            foreach (Cell c in Consts.game.cells)
            {
                if (c.type == CellTypes.TREE && c.isAlive && !c.isBridge && !c.isHut)
                {
                    c.refreshCell();
                }
            }
        });
        events[7] = new Event(7, 3, () =>
        {
            Consts.game.effects.Add(new SleepEffectPlayer(random.Next(2, 5)));
        });
        events[8] = new Event(8, 2, () =>
        {
            Consts.game.effects.Add(new SleepEffectMonsters(random.Next(2, 5)));
        });
    }
}
