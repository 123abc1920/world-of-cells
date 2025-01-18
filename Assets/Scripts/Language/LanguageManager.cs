using System;

public class LanguageManager
{
    private static Language[] languages = { new English(), new Russian() };
    public static Language L = languages[1];

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
