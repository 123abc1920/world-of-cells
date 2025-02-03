using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int cell;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newPos(float x, float y)
    {
        transform.position = new Vector3(x, y + 16, 1);
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

    public void renew(int index){
        Cell target = Consts.game.cells[index];
        this.cell = index;
        this.newPos(target.pos.x, target.pos.y);
    }
}
