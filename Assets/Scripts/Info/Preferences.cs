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
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        AudioSource audio = objs[0].GetComponent<AudioSource>();
        if (voice == 1)
        {
            Consts.audio = true;
            audio.Play();
        }
        else
        {
            Consts.audio = false;
            audio.Stop();
        }
    }
}
