using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class UIScripts : MonoBehaviour
{
    private Label stepsLbl;

    private Label treeLbl;
    private Label rockLbl;
    private Label waterLbl;

    private Button startBtn;
    private Button skipBtn;
    private Button bridgeBtn;
    private Button hutBtn;
    private Button menuBtn;

    private Color activeColor = new Color(0f, 1f, 1f, 1);

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        stepsLbl = root.Q<Label>("stepsLbl");
        treeLbl = root.Q<Label>("treeLbl");
        rockLbl = root.Q<Label>("rockLbl");
        waterLbl = root.Q<Label>("waterLbl");

        startBtn = root.Q<Button>("startBtn");
        startBtn.RegisterCallback<ClickEvent>(startBtnAction);
        startBtn.text = LanguageManager.L.StartNewGame;

        skipBtn = root.Q<Button>("skipBtn");
        skipBtn.RegisterCallback<ClickEvent>(skipBtnAction);
        skipBtn.text = LanguageManager.L.SkipStep;

        bridgeBtn = root.Q<Button>("bridgeBtn");
        bridgeBtn.RegisterCallback<ClickEvent>(bridgeBtnAction);
        bridgeBtn.text = LanguageManager.L.BuildBridge;

        hutBtn = root.Q<Button>("hutBtn");
        hutBtn.RegisterCallback<ClickEvent>(hutBtnAction);
        hutBtn.text = LanguageManager.L.BuildHut;

        menuBtn = root.Q<Button>("menuBtn");
        menuBtn.RegisterCallback<ClickEvent>(menuBtnAction);
        menuBtn.text = LanguageManager.L.BackToMenu;
    }

    // Update is called once per frame
    void Update()
    {
        stepsLbl.text = LanguageManager.L.Steps + Consts.game.stepCount;
        treeLbl.text = LanguageManager.L.Tree + Math.Max(0, Consts.game.tree);
        rockLbl.text = LanguageManager.L.Rock + Math.Max(0, Consts.game.rock);
        waterLbl.text = LanguageManager.L.Water + Math.Max(0, Consts.game.water);

        if (Consts.buildBridge)
        {
            bridgeBtn.style.unityBackgroundImageTintColor = activeColor;
        }
        else
        {
            bridgeBtn.style.unityBackgroundImageTintColor = Color.white;
        }

        if (Consts.buildHut)
        {
            hutBtn.style.unityBackgroundImageTintColor = activeColor;
        }
        else
        {
            hutBtn.style.unityBackgroundImageTintColor = Color.white;
        }
    }

    public void startBtnAction(ClickEvent e)
    {
        Consts.game.renewGame();
    }

    public void skipBtnAction(ClickEvent e)
    {
        Consts.game.skipStep();
    }

    public void bridgeBtnAction(ClickEvent e)
    {
        if (!Consts.buildHut)
        {
            Consts.buildBridge = !Consts.buildBridge;
        }
    }

    public void hutBtnAction(ClickEvent e)
    {
        if (!Consts.buildBridge)
        {
            Consts.buildHut = !Consts.buildHut;
        }
    }

    public void menuBtnAction(ClickEvent e)
    {
        Scenes.OpenMenu();
    }

}
