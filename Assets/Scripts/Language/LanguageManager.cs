using System;
using UnityEngine;

public class LanguageManager
{
    private static Language[] languages = { new English(), new Russian() };
    public static Language L;

    public static void setLanguage(int i)
    {
        L = languages[i];
    }

    public static int getLanguage()
    {
        return Array.IndexOf(languages, LanguageManager.L);
    }

    public static void getNextLang()
    {
        int index = Array.IndexOf(languages, LanguageManager.L);
        if (index == languages.Length - 1)
        {
            LanguageManager.L = languages[0];
        }
        else
        {
            LanguageManager.L = languages[index + 1];
        }
    }
}
