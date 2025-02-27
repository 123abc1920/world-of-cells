using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int cell;
    public bool canMove = true;
    public bool semiTransparent = false;
    private bool toLeft = false;
    private float step = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (semiTransparent)
        {
            GetComponent<SpriteRenderer>().color = Consts.semiTransparentColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (transform.position.x != Consts.game.cells[this.cell].getX() || transform.position.y != Consts.game.cells[this.cell].getY() + 16)
        {
            Vector3 start = new Vector3(transform.position.x, transform.position.y, 1);
            Vector3 finish = new Vector3(Consts.game.cells[this.cell].getX(), Consts.game.cells[this.cell].getY() + 16, 1);
            transform.position = Vector3.Lerp(start, finish, step);
            step += 0.1f;
        }
        else
        {
            step = 0.1f;
        }
    }

    public List<int> getAvailableCells()
    {
        List<int> result = new List<int>();
        int[] a = { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW };

        for (int i = 0; i < a.Length; i++)
        {
            int index = this.cell + a[i];

            if (index < 100 && index >= 0 && Consts.game.cells[index].isAlive)
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

    public void renew(int index)
    {
        this.cell = index;
    }
}
