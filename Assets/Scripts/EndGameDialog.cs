using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialog : MonoBehaviour
{
    public Image Image;
    public TMP_Text title;
    public TMP_Text message;

    // Start is called before the first frame update
    void Start()
    {
        Consts.Image=Image;
        Consts.title=title;
        Consts.message=message;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBnClick(){
        Consts.game.renewGame();
    }
}
