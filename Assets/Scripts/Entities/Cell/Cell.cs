using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour
{
    public int resourceCount;
    public int maxCount;
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

    public Animation anim;

    void Start()
    {

    }

    void Update()
    {
        if (this.isAlive)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            if (this.resourceCount != 0)
            {
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
            else
            {
                if (this.type == CellTypes.TREE)
                {
                    GetComponent<SpriteRenderer>().sprite = treeEmptySprite;
                }
                if (this.type == CellTypes.ROCK)
                {
                    GetComponent<SpriteRenderer>().sprite = rockEmptySprite;
                }
                if (this.type == CellTypes.WATER)
                {
                    GetComponent<SpriteRenderer>().sprite = waterEmptySprite;
                }
            }

            if (this.isBridge)
            {
                GetComponent<SpriteRenderer>().sprite = bridgeSprite;
            }
            if (this.isHut)
            {
                GetComponent<SpriteRenderer>().sprite = hutSprite;
            }
        }
        if (!this.isPreAlive)
        {
            if (this.type == CellTypes.TREE)
            {
                GetComponent<SpriteRenderer>().sprite = treeDestroySprite;
            }
            if (this.type == CellTypes.ROCK)
            {
                GetComponent<SpriteRenderer>().sprite = rockDestroySprite;
            }
            if (this.type == CellTypes.WATER)
            {
                GetComponent<SpriteRenderer>().sprite = waterDestroySprite;
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
        if (!this.isAlive)
        {
            GetComponent<SpriteRenderer>().color = Consts.transparentColor;
        }
    }

    public void tapCell()
    {
        GetComponent<Animator>().Play("CellAnim", -1, 0.0f);
    }

    public void newPos(int x, int y)
    {
        transform.position = new Vector3(x, y, 1);
        pos = transform.position;
    }

    public void setPreDestroy()
    {
        this.isPreAlive = false;
    }

    public void setDestroy()
    {
        this.isAlive = false;
        this.isPreAlive = true;
    }

    public void setBridge()
    {
        this.isAlive = true;
        Consts.game.yourtree -= 10;
        Consts.game.yourwater -= 10;
        Consts.game.yourrock -= 10;
        this.isBridge = true;
        Consts.buildBridge = false;
    }

    public void setHut()
    {
        Consts.game.yourtree -= 10;
        Consts.game.yourwater -= 10;
        Consts.game.yourrock -= 10;
        this.isHut = true;
        Consts.buildHut = false;
    }

    public void getResource()
    {
        if (this.resourceCount == 0 || this.isBridge || this.isHut)
        {
            return;
        }
        if (this.type == CellTypes.TREE)
        {
            Consts.game.yourtree += this.resourceCount;
            this.resourceCount = 0;
            return;
        }
        if (this.type == CellTypes.ROCK)
        {
            Consts.game.yourrock += this.resourceCount;
            this.resourceCount = 0;
            return;
        }
        if (this.type == CellTypes.WATER)
        {
            Consts.game.yourwater += this.resourceCount;
            this.resourceCount = 0;
            return;
        }
    }

    public void refreshCell()
    {
        this.resourceCount = Math.Min(this.resourceCount + 10, this.maxCount);
    }

    public void restartCell()
    {
        this.isAlive = true;
        this.isPreAlive = true;
        this.isHut = false;
        this.isBridge = false;

        this.type = Consts.types[random.Next(Consts.types.Length)];
        this.resourceCount = random.Next(1, 20);
        this.maxCount = this.resourceCount;

        GetComponent<SpriteRenderer>().color = Color.white;
        tapCell();
    }
}
