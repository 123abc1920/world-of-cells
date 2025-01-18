using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidEnemy : MonoBehaviour
{
    public int cell;
    public int[] a = { 1, Consts.ONE_ROW, -1, -Consts.ONE_ROW };
    public CellTypes type;
    public bool isAlive = true;
    private Color waterColor = new Color(0.16f, 0.32f, 0.5f, 1);
    private Color rockColor = new Color(0.24f, 0.21f, 0.21f, 1);
    private Color treeColor = new Color(0.25f, 0.43f, 0.11f, 1);

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
                GetComponent<SpriteRenderer>().color = treeColor;
            }
            if (this.type == CellTypes.ROCK)
            {
                GetComponent<SpriteRenderer>().color = rockColor;
            }
            if (this.type == CellTypes.WATER)
            {
                GetComponent<SpriteRenderer>().color = waterColor;
            }
        }
    }

    public void newPos(float x, float y)
    {
        transform.position = new Vector3(x, y, 1);
    }

    public void hideEnemy()
    {
        GetComponent<SpriteRenderer>().color = Consts.transparentColor;
    }
}
