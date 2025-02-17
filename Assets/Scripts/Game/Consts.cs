using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class Consts
{

    public static CellTypes[] types = { CellTypes.TREE, CellTypes.ROCK, CellTypes.WATER };

    public static Color transparentColor = new Color(0.82f, 0.78f, 0.72f, 0);
    public static Color semiTransparentColor = new Color(1f, 1f, 1f, 0.5f);

    public static int width = 19;
    public static int ONE_ROW = 10;

    public static bool buildHut = false;
    public static bool buildBridge = false;

    public static bool MainMenuShown;
    public static bool CardsShown;
    public static bool HowToPlayShown;

    public static bool OneCardShown;
    public static string eventText;
    public static Sprite eventSprite;
    public static bool EndShown;
    public static string titleText;
    public static string textText;
    public static Sprite spriteText;

    public static float lastClick = 0;

    public static bool audio;
    public static bool first = true;

    public static Game game;

}