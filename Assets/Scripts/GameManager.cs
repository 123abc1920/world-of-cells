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

    private int width=20;
    private int row=10;
    private int col=10;

    // Start is called before the first frame update
    void Start()
    {
        startFirstGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFirstGame(){
        Player p=Instantiate(player);
        RedEnemy rEnemy=Instantiate(redEnemy);
        BlueEnemy bEnemy=Instantiate(blueEnemy);
        FluidEnemy fEnemy=Instantiate(fluidEnemy);

        Cell[] cells=new Cell[100];
        CellText[] texts=new CellText[100];
        for (int i = 0, x=0, y=0; i < col*row; i++, x+=width) {
            Cell c=Instantiate(cell);
            CellText t=Instantiate(cellText);
            c.newPos(x, y);
            c.id=i;

            t.newPos(x, y);
            if ((i+1)%col==0){
                y-=width;
                x=-width;
            }

            cells[i]=c;
            texts[i]=t;
        }
        
        Consts.game=new Game(p, rEnemy, bEnemy, fEnemy, cells, texts);
        Consts.game.renewGame();
    }

}
