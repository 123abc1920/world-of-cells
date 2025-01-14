using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Game
{
    public Cell[] cells=new Cell[100];
    public CellText[] texts=new CellText[100];

    public Player player;
    public RedEnemy redEnemy;
    public BlueEnemy blueEnemy;
    public FluidEnemy fluidEnemy;

    public GameObject endGameDialog;

    public int stepCount=0;
    public int tree, rock, water;

    private System.Random random=new System.Random();
    private int[] toDestroy=new int[3];

    public Game(Player p, RedEnemy re, BlueEnemy be, FluidEnemy fe, Cell[] c, CellText[] ct, GameObject endGameDialog){
        this.player=p;
        this.redEnemy=re;
        this.blueEnemy=be;
        this.fluidEnemy=fe;

        this.endGameDialog=endGameDialog;

        for (int i=0; i<100; i++){
            this.cells[i]=c[i];
            this.texts[i]=ct[i];
        }
    }

    public void gameStep(Vector2 start){
        for (int i=0; i<cells.Length; i++){
            if (Array.IndexOf(getAvailableCells(player.cell, player.a), i)!=-1){
                if (cells[i].pos.x-Consts.width/2<=start.x&&start.x<cells[i].pos.x+Consts.width/2){
                    if (cells[i].pos.y+Consts.width/2>=start.y&&start.y>cells[i].pos.y-Consts.width/2){
                        if (cells[i].isAlive){
                            player.cell=i;

                            player.newPos(cells[i].pos.x, cells[i].pos.y);
                            Consts.game.cells[i].getResource();

                            monsterStep();

                            for (int j=0; j<3; j++){
                                this.cells[toDestroy[j]].setDestroy();
                                toDestroy[j]=random.Next(100);
                                if (this.cells[toDestroy[j]].isAlive){
                                    this.cells[toDestroy[j]].setPreDestroy();
                                }
                            }

                            Consts.game.stepCount++;
                            if (this.tree<=0&&this.rock<=0&&this.water<=0){
                                Consts.title.text="Вы победили!";
                                Consts.message.text="Вы собрали необходимые ресурсы!";
                                this.endGameDialog.SetActive(true);
                            }
                            return;
                        }
                    }
                }
            }
        }
    }

    public void monsterStep(){
        int[] availableCells=getAvailableCells(Consts.game.redEnemy.cell, Consts.game.redEnemy.a);
        int index=availableCells[this.random.Next(availableCells.Length)];
        if (cells[index].isAlive){
            Cell newCell=Consts.game.cells[index];
            Consts.game.redEnemy.newPos(newCell.pos.x, newCell.pos.y);
            Consts.game.redEnemy.cell=index;
        }

        availableCells=getAvailableCells(Consts.game.blueEnemy.cell, Consts.game.blueEnemy.a);
        index=availableCells[this.random.Next(availableCells.Length)];
        if (cells[index].isAlive){
            Cell newCell=Consts.game.cells[index];
            Consts.game.blueEnemy.newPos(newCell.pos.x, newCell.pos.y);
            Consts.game.blueEnemy.cell=index;
        }

        availableCells=getAvailableCells(Consts.game.fluidEnemy.cell, Consts.game.fluidEnemy.a);
        index=availableCells[this.random.Next(availableCells.Length)];
        if (cells[index].isAlive){
            Cell newCell=Consts.game.cells[index];
            Consts.game.fluidEnemy.newPos(newCell.pos.x, newCell.pos.y);
            Consts.game.fluidEnemy.cell=index;
        }
    }

    public int[] getAvailableCells(int cell, int[] a) {
        if (a.Length==2)
        {
            return new int[] {Math.Max(0, Math.Min(99, cell+a[0])), Math.Max(0, Math.Min(99, cell-a[0])), Math.Max(0, Math.Min(99, cell-a[1])), Math.Max(0, Math.Min(99, cell+a[1]))};
        }
        if (a.Length==4)
        {
            return new int[] {Math.Max(0, Math.Min(99, cell+a[0])), Math.Max(0, Math.Min(99, cell-a[0])), Math.Max(0, Math.Min(99, cell-a[1])), Math.Max(0, Math.Min(99, cell+a[1])), Math.Max(0, Math.Min(99, cell+a[2])), Math.Max(0, Math.Min(99, cell-a[2])), Math.Max(0, Math.Min(99, cell-a[3])), Math.Max(0, Math.Min(99, cell+a[3]))};
        }
        return new int[] {};
    }

    public void renewGame(){
        for (int i=0; i<100; i++){
            this.cells[i].restartCell();
            this.texts[i].updateText(this.cells[i].resourceCount);
        }

        this.tree=this.random.Next(20, 80);
        this.rock=this.random.Next(20, 80);
        this.water=this.random.Next(20, 80);
        this.stepCount=0;

        int index=random.Next(100);
        Cell target=cells[index];
        player.cell=index;
        this.cells[player.cell].getResource();
        player.newPos(target.pos.x, target.pos.y);

        index=random.Next(100);
        target=cells[index];
        redEnemy.cell=index;
        redEnemy.newPos(target.pos.x, target.pos.y);

        index=random.Next(100);
        target=cells[index];
        blueEnemy.cell=index;
        blueEnemy.newPos(target.pos.x, target.pos.y);

        index=random.Next(100);
        target=cells[index];
        fluidEnemy.cell=index;
        fluidEnemy.newPos(target.pos.x, target.pos.y);

        this.endGameDialog.SetActive(false);

        for (int j=0; j<3; j++)
        {
            toDestroy[j]=random.Next(100);
            this.cells[toDestroy[j]].setPreDestroy();
        }
    }
}
