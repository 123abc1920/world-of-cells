using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            AudioSource audio = objs[0].GetComponent<AudioSource>();
            if (!Consts.audio)
            {
                audio.Stop();
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
