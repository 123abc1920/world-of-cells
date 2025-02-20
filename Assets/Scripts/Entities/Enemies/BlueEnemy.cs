using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour
{
    public int cell;
    private int[] a = { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW };
    public bool isAlive = true;
    public bool canMove = true;

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
