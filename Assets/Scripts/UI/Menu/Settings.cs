using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsScript : MonoBehaviour
{
    private Label settingsTitle;

    private Button backBtn;

    private VisualElement root;
    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        root.style.display = DisplayStyle.None;

        settingsTitle = root.Q<Label>("settingsTitle");

        backBtn = root.Q<Button>("backBtn");
        backBtn.RegisterCallback<ClickEvent>(backBtnAction);

        Consts.SettingsShown=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Consts.SettingsShown){
            root.style.display = DisplayStyle.Flex;
        }else{
            root.style.display = DisplayStyle.None;
        }
    }

    public void backBtnAction(ClickEvent e){
        Consts.MainMenuShown=true;
        Consts.SettingsShown=false;
    }
}
