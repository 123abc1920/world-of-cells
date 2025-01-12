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

    public int stepCount=0;
    public int tree, rock, water;

    private System.Random random=new System.Random();
    private int[] toDestroy=new int[3];

    public Game(Player p, RedEnemy re, BlueEnemy be, FluidEnemy fe, Cell[] c, CellText[] ct){
        this.player=p;
        this.redEnemy=re;
        this.blueEnemy=be;
        this.fluidEnemy=fe;

        this.tree=this.random.Next(20, 80);
        this.rock=this.random.Next(20, 80);
        this.water=this.random.Next(20, 80);

        for (int i=0; i<100; i++){
            this.cells[i]=c[i];
            this.texts[i]=ct[i];
        }

        for (int j=0; j<3; j++)
        {
            toDestroy[j]=random.Next(100);
            this.cells[toDestroy[j]].setPreDestroy();
        }
    }

    public void gameStep(Vector2 start){
        for (int i=0; i<cells.Length; i++){
            if (Array.IndexOf(getAvailableCells(player.cell, player.a), i)!=-1){
                if (cells[i].pos.x-Consts.width/2<=start.x&&start.x<cells[i].pos.x+Consts.width/2){
                    if (cells[i].pos.y+Consts.width/2>=start.y&&start.y>cells[i].pos.y-Consts.width/2){
                        if (cells[i].isAlive){
                            this.texts[player.cell].showText();
                            player.cell=i;
                            this.texts[player.cell].hideText();

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
            
            this.texts[Consts.game.redEnemy.cell].showText();
            Consts.game.redEnemy.cell=index;
            this.texts[Consts.game.redEnemy.cell].hideText();
        }

        availableCells=getAvailableCells(Consts.game.blueEnemy.cell, Consts.game.blueEnemy.a);
        index=availableCells[this.random.Next(availableCells.Length)];
        if (cells[index].isAlive){
            Cell newCell=Consts.game.cells[index];
            Consts.game.blueEnemy.newPos(newCell.pos.x, newCell.pos.y);
            
            this.texts[Consts.game.blueEnemy.cell].showText();
            Consts.game.blueEnemy.cell=index;
            this.texts[Consts.game.blueEnemy.cell].hideText();
        }

        availableCells=getAvailableCells(Consts.game.fluidEnemy.cell, Consts.game.fluidEnemy.a);
        index=availableCells[this.random.Next(availableCells.Length)];
        if (cells[index].isAlive){
            Cell newCell=Consts.game.cells[index];
            Consts.game.fluidEnemy.newPos(newCell.pos.x, newCell.pos.y);
            
            this.texts[Consts.game.fluidEnemy.cell].showText();
            Consts.game.fluidEnemy.cell=index;
            this.texts[Consts.game.fluidEnemy.cell].hideText();
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
}
