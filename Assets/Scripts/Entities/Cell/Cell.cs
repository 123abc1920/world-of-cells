using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell : MonoBehaviour
{
    public int resourceCount;
    public CellTypes type;
    public Vector3 pos;
    public bool isAlive = true;
    public bool isPreAlive = true;
    public bool isBridge = false;
    public bool isHut = false;
    public int id;

    private System.Random random = new System.Random();

    void Start()
    {

    }

    void Update()
    {

    }

    public void newPos(int x, int y)
    {
        transform.position = new Vector3(x, y, 1);
        pos = transform.position;
    }

    public void setPreDestroy()
    {
        if (this.isAlive)
        {
            GetComponent<SpriteRenderer>().color = Consts.destroyColor;
        }
        this.isPreAlive = false;
    }

    public void setDestroy()
    {
        GetComponent<SpriteRenderer>().color = Consts.transparentColor;
        Consts.game.texts[id].hideText();
        Consts.game.texts[id].resourceCount = 0;
        this.isAlive = false;
        this.isPreAlive = true;
    }

    public void setBridge()
    {
        if (this.isHut)
        {
            return;
        }
        this.isAlive = true;
        GetComponent<SpriteRenderer>().color = Consts.bridgeColor;
        if (!this.isPreAlive)
        {
            GetComponent<SpriteRenderer>().color = Consts.destroyColor;
        }
        Consts.game.tree += 10;
        Consts.game.water += 10;
        Consts.game.rock += 10;
        this.isBridge = true;
        Consts.buildBridge = false;
    }

    public void setHut()
    {
        GetComponent<SpriteRenderer>().color = Consts.hutColor;
        Consts.game.tree += 10;
        Consts.game.water += 10;
        Consts.game.rock += 10;
        this.isHut = true;
        Consts.buildHut = false;
    }

    public void getResource()
    {
        GetComponent<SpriteRenderer>().color = Consts.emptyColor;
        Consts.game.texts[id].updateText(0);
        if (this.resourceCount == 0)
        {
            return;
        }
        if (this.type == CellTypes.TREE)
        {
            Consts.game.tree -= this.resourceCount;
            this.resourceCount = 0;
            return;
        }
        if (this.type == CellTypes.ROCK)
        {
            Consts.game.rock -= this.resourceCount;
            this.resourceCount = 0;
            return;
        }
        if (this.type == CellTypes.WATER)
        {
            Consts.game.water -= this.resourceCount;
            this.resourceCount = 0;
            return;
        }
    }

    public void restartCell()
    {
        this.isAlive = true;
        this.isHut = false;
        this.isBridge = false;

        this.type = Consts.types[random.Next(Consts.types.Length)];
        this.resourceCount = random.Next(1, 20);

        Color newColor = Color.green;
        if (this.type == CellTypes.ROCK)
        {
            newColor = Consts.rockColor;
        }
        else if (this.type == CellTypes.WATER)
        {
            newColor = Consts.waterColor;
        }
        else if (this.type == CellTypes.TREE)
        {
            newColor = Consts.treeColor;
        }
        else if (this.type == CellTypes.BRIDGE)
        {
            newColor = Consts.bridgeColor;
        }
        GetComponent<SpriteRenderer>().color = newColor;
    }
}
