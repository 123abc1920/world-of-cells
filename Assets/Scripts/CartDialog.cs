using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cartDialog : MonoBehaviour
{
    public Image image;
    public TMP_Text title;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        Consts.eventImage=image;
        Consts.eventTitle=title;
        Consts.eventMessage=text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBnClick(){
        Consts.game.getEvent();
    }
}
