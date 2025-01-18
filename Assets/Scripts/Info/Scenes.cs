using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public static void OpenMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public static void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public static string getActiveScene(){
        return SceneManager.GetActiveScene().name;
    }
}
