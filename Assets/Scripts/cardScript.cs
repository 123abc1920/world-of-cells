using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class cardScript : MonoBehaviour
{
    private Label eventMessage;

    private Button closeCardBtn;

    private VisualElement root;
    private VisualElement eventImg;
    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        root.style.display = DisplayStyle.None;

        eventMessage = root.Q<Label>("eventMessage");

        closeCardBtn = root.Q<Button>("closeCardBtn");
        closeCardBtn.RegisterCallback<ClickEvent>(closeCardBtnAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.OneCardShown){
            eventMessage.text=Consts.eventText;
            root.style.display = DisplayStyle.Flex;
        }else{
            root.style.display = DisplayStyle.None;
        }
    }

    public void closeCardBtnAction(ClickEvent e){
        Consts.OneCardShown=false;
    }
}
