using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlueEnemy : MonoBehaviour
{
    public int cell;
    public int[] a = { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW };
    public bool isAlive = true;
    public bool canMove = true;
    private bool toLeft = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isAlive)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Consts.transparentColor;
        }
    }

    public void newPos(float x, float y)
    {
        transform.position = new Vector3(x, y + 10, 1);
    }

    public void flip(int old, int neu)
    {
        bool newLeft = true;
        if (old % 10 <= neu % 10)
        {
            newLeft = false;
        }
        if (toLeft != newLeft)
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            toLeft = newLeft;
        }
    }

    public int scan()
    {
        int target = Consts.game.player.cell;
        int min = Math.Max(0, this.cell - 22);
        int max = Math.Min(99, this.cell + 22);
        if (target % 10 >= min % 10 && target / 10 >= min / 10 && target % 10 <= max % 10 && target / 10 <= max / 10)
        {
            return FindPath.findPath(this.cell, target, this.a);
        }
        return -1;
    }

    public void effect()
    {
        if (Consts.game.player.cell == this.cell)
        {
            Consts.game.yourtree -= 10;
            Consts.game.yourwater -= 10;
            Consts.game.yourrock -= 10;
        }
    }

    public void renew(int index)
    {
        Cell target = Consts.game.cells[index];
        this.cell = index;
        this.newPos(target.pos.x, target.pos.y);
        this.isAlive = true;
        this.canMove = true;
    }
}
