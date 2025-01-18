using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Consts{

    public static CellTypes[] types=  { CellTypes.TREE, CellTypes.ROCK, CellTypes.WATER};

    public static Color waterColor=new Color(0.31f, 0.6f, 0.77f, 1);
    public static Color treeColor=new Color(0.32f, 0.72f, 0.33f, 1);
    public static Color rockColor=new Color(0.38f, 0.38f, 0.38f, 1);
    public static Color bridgeColor=new Color(0.68f, 0.57f, 0.29f, 1);
    public static Color hutColor=new Color(0.57f, 0.89f, 0.82f, 1);
    public static Color destroyColor=new Color(0.7f, 0.24f, 0.32f, 1);
    public static Color emptyColor=new Color(0.82f, 0.78f, 0.72f, 1);
    public static Color transparentColor=new Color(0.82f, 0.78f, 0.72f, 0);

    public static int width=20;
    public static int ONE_ROW = 10;

    public static bool buildHut=false;
    public static bool buildBridge=false;

    public static bool MainMenuShown;
    public static bool SettingsShown;
    public static bool CardsShown;

    public static bool OneCardShown;
    public static string eventText;
    public static bool EndShown;
    public static string titleText;
    public static string textText;

    public static float lastClick=0;

    public static Game game;

}