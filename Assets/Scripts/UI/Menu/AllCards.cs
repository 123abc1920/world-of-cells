using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.AdaptivePerformance;

public class CardsUi : MonoBehaviour
{
    private Label cardsLbl;
    private Label getLbl;

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

        cardsLbl = root.Q<Label>("cardsLbl");
        cardsLbl.text = LanguageManager.L.CardsTitle;
        getLbl = root.Q<Label>("getLbl");

        closeCards = root.Q<Button>("closeCards");
        closeCards.RegisterCallback<ClickEvent>(closeCardsAction);
        closeCards.text = LanguageManager.L.Close;

        list1 = root.Q<ListView>("list1");
        list2 = root.Q<ListView>("list2");

        list1.makeItem = () => listItem.CloneTree();
        list2.makeItem = () => listItem.CloneTree();

        Event[] left;
        if (EventManager.events.Length % 2 == 0)
        {
            left = new Event[EventManager.events.Length / 2];
        }
        else
        {
            left = new Event[EventManager.events.Length / 2 + 1];
        }
        Event[] right = new Event[EventManager.events.Length / 2];

        

        int j = 0;
        for (int i = 0; i < EventManager.events.Length; i++)
        {
            if (i % 2 == 0)
            {
                left[j] = EventManager.events[i];
            }
            else
            {
                right[j] = EventManager.events[i];
                j++;
            }
        }

        list1.bindItem = (element, index) =>
        {
            var currentEvent = left[index];
            var btn = element.Q<Button>("btn");
            var art = element.Q<GroupBox>("art");
            if (EventManager.collection.Contains(currentEvent.id))
            {
                Sprite sp = Resources.Load<Sprite>("Sprites/events");
                StyleBackground styleBackground = new StyleBackground(sp);
                art.style.backgroundImage = styleBackground;
                btn.RegisterCallback<ClickEvent>(evt =>
                {
                    openCard(currentEvent);
                });
            }
        };
        list2.bindItem = (element, index) =>
        {
            var currentEvent = right[index];
            var btn = element.Q<Button>("btn");
            var art = element.Q<GroupBox>("art");
            if (EventManager.collection.Contains(currentEvent.id))
            {
                Sprite sp = Resources.Load<Sprite>("Sprites/events");
                StyleBackground styleBackground = new StyleBackground(sp);
                art.style.backgroundImage = styleBackground;
                btn.RegisterCallback<ClickEvent>(evt =>
                {
                    openCard(currentEvent);
                });
            }
        };

        list1.itemsSource = left;
        list2.itemsSource = right;
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.CardsShown)
        {
            root.style.display = DisplayStyle.Flex;
            getLbl.text = string.Format(LanguageManager.L.ProgressTitle, Math.Truncate(((double)EventManager.collection.Count / EventManager.events.Length) * 100));
        }
        else
        {
            root.style.display = DisplayStyle.None;
        }
    }

    public void closeCardsAction(ClickEvent e)
    {
        Consts.MainMenuShown = true;
        Consts.CardsShown = false;
    }

    public void openCard(Event e)
    {
        Consts.OneCardShown = true;
        Consts.eventText = LanguageManager.L.Events[e.id];
    }
}