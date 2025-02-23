using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public int cell;
    private int[] a = { 1, Consts.ONE_ROW, Consts.ONE_ROW - 1, Consts.ONE_ROW + 1, -1, -Consts.ONE_ROW, -Consts.ONE_ROW + 1, -Consts.ONE_ROW - 1 };
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
        transform.position = new Vector3(x, y + 12, 1);
    }

    public List<int> getAvailableCells()
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

    public void renew(int index)
    {
        Cell target = Consts.game.cells[index];
        this.cell = index;
        this.newPos(target.pos.x, target.pos.y);
        this.isAlive = true;
        this.canMove = true;
    }
}
