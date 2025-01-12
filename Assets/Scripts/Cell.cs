using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int resourceCount;
    public CellTypes type;
    public Vector3 pos;
    public bool isAlive=true;
    public int id;

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

    void Update()
    {
       
    }

    public void newPos(int x, int y){
        transform.position = new Vector3(x, y, 1);
        pos=transform.position;
    }

    public void setPreDestroy(){
        GetComponent<SpriteRenderer>().color=Consts.destroyColor;
    }

    public void setDestroy(){
        GetComponent<SpriteRenderer>().color=Consts.transparentColor;
        Consts.game.texts[id].hideText();
        Consts.game.texts[id].resourceCount=0;
        this.isAlive=false;
    }

    public void getResource(){
        if (this.resourceCount==0){
            return;
        }
        GetComponent<SpriteRenderer>().color=Consts.emptyColor;
        Consts.game.texts[id].updateText(0);
        if (this.type==CellTypes.TREE){
            Consts.game.tree-=this.resourceCount;
            this.resourceCount=0;
            return;
        }
        if (this.type==CellTypes.ROCK){
            Consts.game.rock-=this.resourceCount;
            this.resourceCount=0;
            return;
        }
        if (this.type==CellTypes.WATER){
            Consts.game.water-=this.resourceCount;
            this.resourceCount=0;
            return;
        }
    }
}
