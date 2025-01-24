using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidEnemy : MonoBehaviour
{
    public int cell;
    public int[] a = { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW };
    public CellTypes type;
    public bool isAlive = true;

    public Sprite waterSprite;
    public Sprite treeSprite;
    public Sprite rockSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isAlive)
        {
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
    }

    public void newPos(float x, float y)
    {
        transform.position = new Vector3(x, y + 10, 1);
    }

    public void hideEnemy()
    {
        GetComponent<SpriteRenderer>().color = Consts.transparentColor;
    }
}
