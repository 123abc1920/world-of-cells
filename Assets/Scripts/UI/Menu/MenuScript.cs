using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuScript : MonoBehaviour
{
    private Label gameTitle;

    private Button playBtn;
    private Button settingsBtn;
    private Button cardsBtn;
    private Button storyBtn;

    private VisualElement root;

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        gameTitle = root.Q<Label>("gameTitle");
        gameTitle.text = LanguageManager.L.Title;

        playBtn = root.Q<Button>("playBtn");
        playBtn.RegisterCallback<ClickEvent>(playBtnAction);
        playBtn.text = LanguageManager.L.Play;

        settingsBtn = root.Q<Button>("settingsBtn");
        settingsBtn.RegisterCallback<ClickEvent>(settingsBtnAction);
        settingsBtn.text = LanguageManager.L.Settings;

        cardsBtn = root.Q<Button>("cardsBtn");
        cardsBtn.RegisterCallback<ClickEvent>(openCardsBtnAction);
        cardsBtn.text = LanguageManager.L.Cards;

        storyBtn = root.Q<Button>("storyBtn");
        storyBtn.text = LanguageManager.L.Story;

        Consts.MainMenuShown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.MainMenuShown)
        {
            root.style.display = DisplayStyle.Flex;
        }
        else
        {
            root.style.display = DisplayStyle.None;
        }
    }

    public void playBtnAction(ClickEvent e)
    {
        Scenes.OpenGame();
    }

    public void settingsBtnAction(ClickEvent e)
    {
        Scenes.OpenSettings();
    }

    public void openCardsBtnAction(ClickEvent e)
    {
        Consts.MainMenuShown = false;
        Consts.CardsShown = true;
    }
}
