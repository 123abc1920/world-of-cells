using System;
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
    private Button voiceBtn;

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

        voiceBtn = root.Q<Button>("voiceBtn");
        voiceBtn.RegisterCallback<ClickEvent>(voiceBtnAction);
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
        progressLbl.text = string.Format(LanguageManager.L.ProgressLbl, Math.Truncate(((double)EventManager.collection.Count / EventManager.events.Length) * 100));
        progressBtn.text = LanguageManager.L.ProgressBtn;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        AudioSource audio = objs[0].GetComponent<AudioSource>();
        if (audio.isPlaying)
        {
            voiceBtn.text = LanguageManager.L.SoundBtnOn;
        }
        else
        {
            voiceBtn.text = LanguageManager.L.SoundBtnOff;
        }
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
        PlayerPrefs.SetInt("lang", LanguageManager.getLanguage());
    }

    private void voiceBtnAction(ClickEvent e)
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        AudioSource audio = objs[0].GetComponent<AudioSource>();
        if (audio.isPlaying)
        {
            audio.Stop();
            Consts.audio = true;
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            audio.Play();
            Consts.audio = false;
            PlayerPrefs.SetInt("sound", 0);
        }

        if (audio.isPlaying)
        {
            PlayerPrefs.SetInt("sound", 1);
        }
        else
        {
            PlayerPrefs.SetInt("sound", 0);
        }
    }
}
