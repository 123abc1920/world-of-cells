using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class MenuScript : MonoBehaviour
{
    private Label gameTitle;

    private Button playBtn;
    private Button settingsBtn;
    private Button cardsBtn;
    private Button storyBtn;

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        gameTitle = root.Q<Label>("gameTitle");

        playBtn = root.Q<Button>("playBtn");
        playBtn.RegisterCallback<ClickEvent>(playBtnAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playBtnAction(ClickEvent e){
        Scenes.OpenGame();
    }
}
