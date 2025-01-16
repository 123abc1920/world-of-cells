using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardsUi : MonoBehaviour
{
    private Label cardsLbl;

    private Button closeCards;

    private VisualElement root;

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        root.style.display = DisplayStyle.None;

        cardsLbl = root.Q<Label>("cardsLbl");

        closeCards = root.Q<Button>("closeCards");
        closeCards.RegisterCallback<ClickEvent>(closeCardsAction);

        Consts.SettingsShown=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.CardsShown){
            root.style.display = DisplayStyle.Flex;
        }else{
            root.style.display = DisplayStyle.None;
        }
    }

    public void closeCardsAction(ClickEvent e){
        Consts.MainMenuShown=true;
        Consts.CardsShown=false;
    }
}
