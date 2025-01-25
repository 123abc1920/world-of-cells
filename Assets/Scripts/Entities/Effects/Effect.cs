using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    private int longing;

    public int getLonging()
    {
        return longing;
    }

    public void setLonging(int l)
    {
        this.longing = l;
    }

    public abstract void effect();
}
