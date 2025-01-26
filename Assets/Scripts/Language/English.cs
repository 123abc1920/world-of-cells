using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class English : Language
{
    public English()
    {
        Title = "World Of Cells";
        Play = "Play";
        Settings = "Settings";
        Cards = "Cards";
        Story = "Story";
        HowToPlay = "How To Play";

        SettingsTitle = "Settings";
        ProgressLbl = "Progress: {0}%";
        ProgressBtn = "Reset";
        SoundLbl = "Sound";
        SoundBtnOn = "On";
        SoundBtnOff = "Off";
        LanguageLbl = "Language";
        LanguageBtn = "Eng";

        PlayerInfo = "There are you. You find yourself on an unfamiliar planet.";
        GoalInfo = "Numbers - quantity of resources - are generated every game. You have to collect these resources to win.";
        EnemiesInfo = "There are enemies. Red can move to all of 8 cells around him. He attacks immediately. Blue moves only to cells which have common sides. He steals 10 resources each step if he attacks. The third type of monster changes its appearance and empties the cells.";
        HutBridgeInfo = "Houses and bridges are a special type of cells. You have to spend resources to build them. Bridges help to get over the destroyed cells. Houses shelter from enemies.";
        CardsInfo = "Sometimes events can be shown when you step into cell. Events can influence on quatity of resources or apply effects.";

        CardsTitle = "Collected Cards";
        ProgressTitle = "You collected {0}% of cards";

        Tree = "Tree: {0}/{0}";
        Water = "Water: {0}/{0}";
        Rock = "Rock: {0}/{0}";
        Steps = "Steps: ";
        StartNewGame = "Start new game";
        SkipStep = "Skip step";
        BuildBridge = "Build bridge";
        BuildHut = "Build hut";
        BackToMenu = "Back";

        Ok = "Accept";
        Close = "Close";
        Start = "Start new game";

        WinTxt = "You win!";
        LoseTxt = "You lose.";
        RedEnd = "Red monster attacked you.";
        CosmosEnd = "You were blown into space.";
        WinEnd = "You have collected all the necessary resources.";

        Events[0] = "You fell into a pit. You have lost some resources.";
        Events[1] = "You are in the forest. The quantity of wood was increased.";
        Events[2] = "You found a treasure. The quantity of resources was increased.";
        Events[3] = "You met magical creatures. They shared resources with you.";
        Events[4] = "It is raining. The rivres filled with water.";
        Events[5] = "The strong wind started blowing. There were a lot of rocks under the sand.";
        Events[6] = "There were several sunny days. New trees grown.";
        Events[7] = "You are entangled by plants. You have to skip several moves before you can get out.";
        Events[8] = "The music was started. It looks like the monsters have fallen asleep and can't move for a while.";
    }
}
