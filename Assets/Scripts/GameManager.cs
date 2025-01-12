using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class click : MonoBehaviour
{
    public Cell cell;
    public CellText cellText;

    public Player player;
    public RedEnemy redEnemy;
    public BlueEnemy blueEnemy;
    public FluidEnemy fluidEnemy;

    public GameObject canvas;

    private int width=(int)Math.Round(Screen.height*0.0125f);
    private int row=10;
    private int col=10;

    private System.Random random=new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        startNewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startNewGame(){
        Player p=Instantiate(player);
        p.newPos(0, 0);

        Cell[] cells=new Cell[100];
        CellText[] texts=new CellText[100];
        for (int i = 0, x=0, y=0; i < col*row; i++, x+=width) {
            Cell c=Instantiate(cell);
            CellText t=Instantiate(cellText);
            c.newPos(x, y);
            c.resourceCount=random.Next(1, 20);
            c.type=Consts.types[random.Next(Consts.types.Length)];
            c.id=i;
            c.isAlive=true;

            t.resourceCount=c.resourceCount;
            t.newPos(x, y);
            if ((i+1)%col==0){
                y-=width;
                x=-width;
            }

            cells[i]=c;
            texts[i]=t;
        }

        RedEnemy rEnemy=Instantiate(redEnemy);
        int index=random.Next(100);
        Cell target=cells[index];
        rEnemy.cell=index;
        rEnemy.newPos(target.pos.x, target.pos.y);

        BlueEnemy bEnemy=Instantiate(blueEnemy);
        index=random.Next(100);
        target=cells[index];
        bEnemy.cell=index;
        bEnemy.newPos(target.pos.x, target.pos.y);

        FluidEnemy fEnemy=Instantiate(fluidEnemy);
        index=random.Next(100);
        target=cells[index];
        fEnemy.cell=index;
        fEnemy.newPos(target.pos.x, target.pos.y);
        
        Consts.game=new Game(p, rEnemy, bEnemy, fEnemy, cells, texts);
    }

}
