using UnityEngine;
using System;

public class Consts{

    public static CellTypes[] types=  { CellTypes.TREE, CellTypes.ROCK, CellTypes.WATER};

    public static Color waterColor=new Color(0.31f, 0.6f, 0.77f, 1);
    public static Color treeColor=new Color(0.32f, 0.72f, 0.33f, 1);
    public static Color rockColor=new Color(0.38f, 0.38f, 0.38f, 1);
    public static Color bridgeColor=new Color(0.68f, 0.57f, 0.29f, 1);

    public static Cell[] cells=new Cell[100];
    public static CellText[] texts=new CellText[100];

    public static Player player;
    public static RedEnemy redEnemy;
    public static BlueEnemy blueEnemy;
    public static FluidEnemy fluidEnemy;

    public static int width=(int)Math.Round(Screen.height*0.0125f);
    public static int ONE_ROW = 10;

    public static void gameStep(Vector2 start){
        for (int i=0; i<Consts.cells.Length; i++){
            if (Array.IndexOf(MovingScript.getAvailableCells(Consts.player.cell, Consts.player.a), i)!=-1){
                if (Consts.cells[i].pos.x-Consts.width/2<=start.x&&start.x<Consts.cells[i].pos.x+Consts.width/2){
                    if (Consts.cells[i].pos.y+Consts.width/2>=start.y&&start.y>Consts.cells[i].pos.y-Consts.width/2){
                        Consts.player.cell=i;
                        Consts.player.newPos(Consts.cells[i].pos.x, Consts.cells[i].pos.y);
                        return;
                    }
                }
            }
        }
    }

}