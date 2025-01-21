using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsScript : MonoBehaviour
{
    private Label settingsTitle;
    private Label progressLbl;
    private Label langLbl;
    private Label soundLbl;

    private Button backBtn;
    private Button progressBtn;
    private Button langBtn;

    private VisualElement root;
    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        settingsTitle = root.Q<Label>("settingsTitle");
        progressLbl = root.Q<Label>("progressLbl");
        langLbl = root.Q<Label>("langLbl");
        soundLbl = root.Q<Label>("soundLbl");

        backBtn = root.Q<Button>("backBtn");
        backBtn.RegisterCallback<ClickEvent>(backBtnAction);

        progressBtn = root.Q<Button>("progressBtn");
        progressBtn.RegisterCallback<ClickEvent>(resetBtnAction);

        langBtn = root.Q<Button>("langBtn");
        langBtn.RegisterCallback<ClickEvent>(changeLangBtnAction);
    }

    // Update is called once per frame
    void Update()
    {
        langBtn.text = LanguageManager.L.LanguageBtn;
        langLbl.text = LanguageManager.L.LanguageLbl;
        soundLbl.text = LanguageManager.L.SoundLbl;
        settingsTitle.text = LanguageManager.L.SettingsTitle;
        backBtn.text = LanguageManager.L.Close;
        settingsTitle.text = LanguageManager.L.SettingsTitle;
        progressLbl.text = string.Format(LanguageManager.L.ProgressLbl, ((double)EventManager.collection.Count / EventManager.events.Length) * 100);
        progressBtn.text = LanguageManager.L.ProgressBtn;
    }

    public void backBtnAction(ClickEvent e)
    {
        Scenes.OpenMenu();
    }

    private void resetBtnAction(ClickEvent e)
    {
        EventManager.collection.Clear();
        DataScript.SaveData(EventManager.collection);
    }

    private void changeLangBtnAction(ClickEvent e)
    {
        LanguageManager.getNextLang();
    }
}
