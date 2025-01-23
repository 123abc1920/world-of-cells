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

    public Sprite treeSprite;
    public Sprite waterSprite;
    public Sprite rockSprite;
    public Sprite hutSprite;
    public Sprite bridgeSprite;

    public Sprite treeDestroySprite;
    public Sprite waterDestroySprite;
    public Sprite rockDestroySprite;
    public Sprite hutDestroySprite;
    public Sprite bridgeDestroySprite;

    public Sprite treeEmptySprite;
    public Sprite waterEmptySprite;
    public Sprite rockEmptySprite;

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
            if (this.type == CellTypes.ROCK)
            {
                GetComponent<SpriteRenderer>().sprite = rockDestroySprite;
            }
            else if (this.type == CellTypes.WATER)
            {
                GetComponent<SpriteRenderer>().sprite = waterDestroySprite;
            }
            else if (this.type == CellTypes.TREE)
            {
                GetComponent<SpriteRenderer>().sprite = treeDestroySprite;
            }
            if (this.isBridge)
            {
                GetComponent<SpriteRenderer>().sprite = bridgeDestroySprite;
            }
            if (this.isHut)
            {
                GetComponent<SpriteRenderer>().sprite = hutDestroySprite;
            }
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
        this.isAlive = true;
        GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().sprite = bridgeSprite;
        if (!this.isPreAlive)
        {
            GetComponent<SpriteRenderer>().sprite = bridgeDestroySprite;
        }
        Consts.game.tree += 10;
        Consts.game.water += 10;
        Consts.game.rock += 10;
        this.isBridge = true;
        Consts.buildBridge = false;
    }

    public void setHut()
    {
        GetComponent<SpriteRenderer>().sprite = hutSprite;
        Consts.game.tree += 10;
        Consts.game.water += 10;
        Consts.game.rock += 10;
        this.isHut = true;
        Consts.buildHut = false;
    }

    public void getResource()
    {
        Consts.game.texts[id].updateText(0);
        if (this.resourceCount == 0)
        {
            return;
        }
        if (this.type == CellTypes.TREE)
        {
            Consts.game.tree -= this.resourceCount;
            GetComponent<SpriteRenderer>().sprite = treeEmptySprite;
            this.resourceCount = 0;
            return;
        }
        if (this.type == CellTypes.ROCK)
        {
            Consts.game.rock -= this.resourceCount;
            GetComponent<SpriteRenderer>().sprite = rockEmptySprite;
            this.resourceCount = 0;
            return;
        }
        if (this.type == CellTypes.WATER)
        {
            Consts.game.water -= this.resourceCount;
            GetComponent<SpriteRenderer>().sprite = waterEmptySprite;
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

        GetComponent<SpriteRenderer>().color = Color.white;
        if (this.type == CellTypes.ROCK)
        {
            GetComponent<SpriteRenderer>().sprite = rockSprite;
        }
        else if (this.type == CellTypes.WATER)
        {
            GetComponent<SpriteRenderer>().sprite = waterSprite;
        }
        else if (this.type == CellTypes.TREE)
        {
            GetComponent<SpriteRenderer>().sprite = treeSprite;
        }
    }
}
