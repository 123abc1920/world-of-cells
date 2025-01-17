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

    private ListView list1;
    private ListView list2;

    public VisualTreeAsset listItem;

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        root.style.display = DisplayStyle.None;

        cardsLbl = root.Q<Label>("cardsLbl");

        closeCards = root.Q<Button>("closeCards");
        closeCards.RegisterCallback<ClickEvent>(closeCardsAction);

        list1 = root.Q<ListView>("list1");
        list2 = root.Q<ListView>("list2");

        list1.makeItem = () => listItem.CloneTree();
        list2.makeItem = () => listItem.CloneTree();

        Event[] left=new Event[EventManager.events.Length/2];
        Event[] right=new Event[EventManager.events.Length/2];

        int j=0;
        for (int i=0; i<EventManager.events.Length; i++){
            if (i%2==0){
                left[j]=EventManager.events[i];
            }else{
                right[j]=EventManager.events[i];
                j++;
            }
        }

        list1.bindItem = (element, index) =>
        {
            var currentEvent = left[index];
            var btn = element.Q<Button>("btn");
            btn.text = currentEvent.message;
            btn.RegisterCallback<ClickEvent>(evt => {
                openCard(currentEvent);
            });
        };
        list2.bindItem = (element, index) =>
        {
            var currentEvent = right[index];
            var btn = element.Q<Button>("btn");
            btn.text = currentEvent.message;
            btn.RegisterCallback<ClickEvent>(evt => {
                openCard(currentEvent);
            });
        };

        list1.itemsSource=left;
        list2.itemsSource=right;

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

    public void openCard(Event e){
        Consts.OneCardShown=true;
        Consts.eventText=e.message;
    }
}