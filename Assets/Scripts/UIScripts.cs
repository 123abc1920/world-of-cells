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
    }

    // Update is called once per frame
    void Update()
    {
        stepsLbl.text="Steps: "+Consts.game.stepCount;
        treeLbl.text = "Tree: "+Math.Max(0, Consts.game.tree);
        rockLbl.text = "Rock: "+Math.Max(0, Consts.game.rock);
        waterLbl.text = "Water: "+Math.Max(0, Consts.game.water);
    }

    public void startBtnAction(ClickEvent e){
        Consts.game.renewGame();
    }

    public void skipBtnAction(ClickEvent e){
        Consts.game.skipStep();
    }

    public void bridgeBtnAction(ClickEvent e){
        Consts.buildBridge=!Consts.buildBridge;
    }

    public void hutBtnAction(ClickEvent e){
        Consts.buildHut=!Consts.buildHut;
    }

}
