using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{
    void Start()
    {
        int lang = PlayerPrefs.GetInt("lang", 1);
        LanguageManager.setLanguage(lang);

        int voice = PlayerPrefs.GetInt("sound");
        if (voice == 1)
        {
            Consts.audio = true;
        }
        else
        {
            Consts.audio = false;
        }
    }
}
