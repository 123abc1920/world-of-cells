using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class click : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    public Cell cell;
    public CellText cellText;

    public GameObject canvas;

    private int width=(int)Math.Round(Screen.height*0.0125f);
    private int row=10;
    private int col=10;

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        for (int i = 0, x=0, y=0; i < col*row; i++, x+=width) {
            Cell c=Instantiate(cell);
            CellText t=Instantiate(cellText);
            c.newPos(x, y);
            t.newPos(x, y);
            if ((i+1)%col==0){
                y-=width;
                x=-width;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
