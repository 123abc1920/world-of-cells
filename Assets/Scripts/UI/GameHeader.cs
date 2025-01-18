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

    private Color firstColor=new Color(0.74f, 0.74f, 0.74f, 1), activeColor=new Color(0.5f, 0.63f, 0.81f, 1);

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

        skipBtn = root.Q<Button>("skipBtn");
        skipBtn.RegisterCallback<ClickEvent>(skipBtnAction);

        bridgeBtn=root.Q<Button>("bridgeBtn");
        bridgeBtn.RegisterCallback<ClickEvent>(bridgeBtnAction);

        hutBtn=root.Q<Button>("hutBtn");
        hutBtn.RegisterCallback<ClickEvent>(hutBtnAction);

        menuBtn=root.Q<Button>("menuBtn");
        menuBtn.RegisterCallback<ClickEvent>(menuBtnAction);

        firstColor=hutBtn.style.backgroundColor.value;
    }

    // Update is called once per frame
    void Update()
    {
        stepsLbl.text="Steps: "+Consts.game.stepCount;
        treeLbl.text = "Tree: "+Math.Max(0, Consts.game.tree);
        rockLbl.text = "Rock: "+Math.Max(0, Consts.game.rock);
        waterLbl.text = "Water: "+Math.Max(0, Consts.game.water);

        if (Consts.buildBridge){
            bridgeBtn.style.backgroundColor=activeColor;
        }else{
            bridgeBtn.style.backgroundColor=firstColor;
        }

        if (Consts.buildHut){
            hutBtn.style.backgroundColor=activeColor;
        }else{
            hutBtn.style.backgroundColor=firstColor;
        }
    }

    public void startBtnAction(ClickEvent e){
        Consts.game.renewGame();
    }

    public void skipBtnAction(ClickEvent e){
        Consts.game.skipStep();
    }

    public void bridgeBtnAction(ClickEvent e){
        if (!Consts.buildHut){
            Consts.buildBridge=!Consts.buildBridge;
        }
    }

    public void hutBtnAction(ClickEvent e){
        if (!Consts.buildBridge){
            Consts.buildHut=!Consts.buildHut;
        }
    }

    public void menuBtnAction(ClickEvent e){
        Scenes.OpenMenu();
    }

}
