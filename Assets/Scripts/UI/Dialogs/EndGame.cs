using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class endGameScript : MonoBehaviour
{
    private Label title;
    private Label text;

    private VisualElement image;

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

        image = root.Q<VisualElement>("endImg");

        closeBtn = root.Q<Button>("closeBtn");
        closeBtn.text = LanguageManager.L.StartNewGame;
        closeBtn.RegisterCallback<ClickEvent>(closeBtnAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.EndShown)
        {
            title.text = Consts.titleText;
            text.text = Consts.textText;
            StyleBackground styleBackground = new StyleBackground(Consts.spriteText);
            image.style.backgroundImage = styleBackground;
            root.style.display = DisplayStyle.Flex;
        }
        else
        {
            root.style.display = DisplayStyle.None;
        }
    }

    private void closeBtnAction(ClickEvent e)
    {
        Consts.EndShown = false;
        Consts.game.renewGame();
    }
}
