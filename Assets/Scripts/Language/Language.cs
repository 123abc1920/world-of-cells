using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Language
{
    public string Title;
    public string Play;
    public string Settings;
    public string Cards;
    public string Story;
    public string HowToPlay;

    public string SettingsTitle;
    public string ProgressLbl;
    public string ProgressBtn;
    public string SoundLbl;
    public string SoundBtnOn;
    public string SoundBtnOff;
    public string LanguageLbl;
    public string LanguageBtn;

    public string PlayerInfo;
    public string GoalInfo;
    public string EnemiesInfo;
    public string HutBridgeInfo;
    public string CardsInfo;

    public string CardsTitle;
    public string ProgressTitle;

    public string Tree;
    public string Water;
    public string Rock;
    public string Steps;
    public string StartNewGame;
    public string SkipStep;
    public string BuildBridge;
    public string BuildHut;
    public string BackToMenu;

    public string Ok;
    public string Close;
    public string Start;

    public string WinTxt;
    public string LoseTxt;
    public string RedEnd;
    public string CosmosEnd;
    public string WinEnd;

    public string[] Events = new string[EventManager.events.Length];
}
