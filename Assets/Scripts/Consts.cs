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

    public static int width=(int)Math.Round(Screen.height*0.0125f);

}