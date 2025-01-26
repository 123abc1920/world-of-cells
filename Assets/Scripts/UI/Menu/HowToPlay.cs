using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HowToPlay : MonoBehaviour
{
    private VisualElement root;

    private Button closeBtn;

    private Label player;
    private Label goal;
    private Label enemies;
    private Label hutbridge;
    private Label cards;

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        closeBtn = root.Q<Button>("closeBtn");
        closeBtn.text = LanguageManager.L.Ok;
        closeBtn.RegisterCallback<ClickEvent>(closeAction);

        player = root.Q<Label>("player");
        player.text = LanguageManager.L.PlayerInfo;

        goal = root.Q<Label>("goal");
        goal.text = LanguageManager.L.GoalInfo;

        enemies = root.Q<Label>("enemies");
        enemies.text = LanguageManager.L.EnemiesInfo;

        hutbridge = root.Q<Label>("hutbridge");
        hutbridge.text = LanguageManager.L.HutBridgeInfo;

        cards = root.Q<Label>("cards");
        cards.text = LanguageManager.L.CardsInfo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.HowToPlayShown)
        {
            root.style.display = DisplayStyle.Flex;
        }
        else
        {
            root.style.display = DisplayStyle.None;
        }
    }

    private void closeAction(ClickEvent e)
    {
        Consts.HowToPlayShown = false;
        Consts.MainMenuShown = true;
    }
}
