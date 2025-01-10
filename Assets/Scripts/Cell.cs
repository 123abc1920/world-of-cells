using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int resourceCount;
    public CellTypes type;
    public Vector3 pos;

    void Start()
    {
        Color newColor=Color.green;
        if (this.type==CellTypes.ROCK){
            newColor=Consts.rockColor;
        }else if (this.type==CellTypes.WATER){
            newColor=Consts.waterColor;
        }else if (this.type==CellTypes.TREE){
            newColor=Consts.treeColor;
        }else if (this.type==CellTypes.BRIDGE){
            newColor=Consts.bridgeColor;
        }
        GetComponent<SpriteRenderer>().color=newColor;
    }

    public void newPos(int x, int y){
        transform.position = new Vector3(x, y, 1);
        pos=transform.position;
    }

    void Update()
    {
       
    }
}
