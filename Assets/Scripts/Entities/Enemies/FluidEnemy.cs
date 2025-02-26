using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class FluidEnemy : MonoBehaviour
{
    public int cell;
    public int[] a = { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW };
    public CellTypes type;
    public bool isAlive = true;
    public bool canMove = true;

    public Sprite waterSprite;
    public Sprite treeSprite;
    public Sprite rockSprite;

    private System.Random random = new System.Random();
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
            if (this.type == CellTypes.TREE)
            {
                GetComponent<SpriteRenderer>().sprite = treeSprite;
            }
            if (this.type == CellTypes.ROCK)
            {
                GetComponent<SpriteRenderer>().sprite = rockSprite;
            }
            if (this.type == CellTypes.WATER)
            {
                GetComponent<SpriteRenderer>().sprite = waterSprite;
            }
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

    public void effect()
    {
        if (Consts.game.cells[Consts.game.fluidEnemy.cell].type == this.type)
        {
            Consts.game.cells[Consts.game.fluidEnemy.cell].resourceCount = 0;
        }
        if (random.Next(5) == 1)
        {
            this.type = Consts.types[random.Next(Consts.types.Length)];
        }
    }

    private int[] a1 = { 1, 9, 10, 11 };
    private int[] a2 = { 2, 19, 20, 21, 22, 18, 8 };

    private int findTarget()
    {
        for (int i = 0; i < a1.Length; i++)
        {
            int probe = Math.Max(0, Math.Min(99, this.cell + a1[i]));
            if (Consts.game.cells[probe].resourceCount > 0 && Consts.game.cells[probe].type == this.type && !Consts.game.cells[probe].isBridge && !Consts.game.cells[probe].isHut && Consts.game.cells[probe].isPreAlive)
            {
                return probe;
            }
            probe = Math.Max(0, Math.Min(99, this.cell - a1[i]));
            if (Consts.game.cells[probe].resourceCount > 0 && Consts.game.cells[probe].type == this.type && !Consts.game.cells[probe].isBridge && !Consts.game.cells[probe].isHut && Consts.game.cells[probe].isPreAlive)
            {
                return probe;
            }
        }
        for (int i = 0; i < a2.Length; i++)
        {
            int probe = Math.Max(0, Math.Min(99, this.cell + a2[i]));
            if (Consts.game.cells[probe].resourceCount > 0 && Consts.game.cells[probe].type == this.type && !Consts.game.cells[probe].isBridge && !Consts.game.cells[probe].isHut && Consts.game.cells[probe].isPreAlive)
            {
                return probe;
            }
            probe = Math.Max(0, Math.Min(99, this.cell - a2[i]));
            if (Consts.game.cells[probe].resourceCount > 0 && Consts.game.cells[probe].type == this.type && !Consts.game.cells[probe].isBridge && !Consts.game.cells[probe].isHut && Consts.game.cells[probe].isPreAlive)
            {
                return probe;
            }
        }
        return -1;
    }

    public int scan()
    {
        int target = findTarget();
        if (target == -1)
        {
            return target;
        }
        return FindPath.findPath(this.cell, target, this.a);
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

    public void renew(int index)
    {
        Cell target = Consts.game.cells[index];
        this.cell = index;
        this.newPos(target.pos.x, target.pos.y);
        this.type = Consts.types[random.Next(Consts.types.Length)];
        this.isAlive = true;
        this.canMove = true;
    }
}
