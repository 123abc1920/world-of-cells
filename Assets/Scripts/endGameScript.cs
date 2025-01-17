using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class endGameScript : MonoBehaviour
{
    private Label title;
    private Label text;

    private Button closeBtn;

    private VisualElement root;
    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        root.style.display = DisplayStyle.None;

        title = root.Q<Label>("title");
        text = root.Q<Label>("text");

        closeBtn = root.Q<Button>("closeBtn");
        closeBtn.RegisterCallback<ClickEvent>(closeBtnAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.EndShown){
            title.text=Consts.titleText;
            text.text=Consts.textText;
            root.style.display = DisplayStyle.Flex;
        }else{
            root.style.display = DisplayStyle.None;
        }
    }

    private void closeBtnAction(ClickEvent e){
        Consts.EndShown=false;
        Consts.game.renewGame();
    }
}
