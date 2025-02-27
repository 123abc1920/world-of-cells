using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public int cell;
    public int[] a = { 1, Consts.ONE_ROW, Consts.ONE_ROW - 1, Consts.ONE_ROW + 1, -1, -Consts.ONE_ROW, -Consts.ONE_ROW + 1, -Consts.ONE_ROW - 1 };
    public bool isAlive = true;
    public bool canMove = true;
    private bool toLeft = true;
    private float step = 0.1f;

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
        if (transform.position.x != Consts.game.cells[this.cell].getX() || transform.position.y != Consts.game.cells[this.cell].getY() + 12)
        {
            Vector3 start = new Vector3(transform.position.x, transform.position.y, 1);
            Vector3 finish = new Vector3(Consts.game.cells[this.cell].getX(), Consts.game.cells[this.cell].getY() + 12, 1);
            transform.position = Vector3.Lerp(start, finish, step);
            step += 0.1f;
        }
        else
        {
            step = 0.1f;
        }
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

    public void effect()
    {
        if (this.cell == Consts.game.player.cell)
        {
            Consts.titleText = LanguageManager.L.LoseTxt;
            Consts.textText = LanguageManager.L.RedEnd;
            Consts.spriteText = Resources.Load<Sprite>("Sprites/redEnemyEnd");
            Consts.EndShown = true;
        }
    }

    public int scan()
    {
        int target = Consts.game.player.cell;
        int min = Math.Max(0, this.cell - 33);
        int max = Math.Min(99, this.cell + 33);
        if (target % 10 >= min % 10 && target / 10 >= min / 10 && target % 10 <= max % 10 && target / 10 <= max / 10)
        {
            return FindPath.findPath(this.cell, target, this.a);
        }
        return -1;
    }

    public void renew(int index)
    {
        this.cell = index;
        this.isAlive = true;
        this.canMove = true;
    }
}
