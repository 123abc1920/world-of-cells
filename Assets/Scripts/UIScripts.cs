using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIScripts : MonoBehaviour
{
    private Label stepsLbl;

    private Label treeLbl;
    private Label rockLbl;
    private Label waterLbl;

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        stepsLbl = root.Q<Label>("stepsLbl");
        treeLbl = root.Q<Label>("treeLbl");
        rockLbl = root.Q<Label>("rockLbl");
        waterLbl = root.Q<Label>("waterLbl");
    }

    // Update is called once per frame
    void Update()
    {
        stepsLbl.text="Steps: "+Consts.game.stepCount;
        treeLbl.text = "Tree: "+Consts.game.tree;
        rockLbl.text = "Rock: "+Consts.game.rock;
        waterLbl.text = "Water: "+Consts.game.water;
    }
}
