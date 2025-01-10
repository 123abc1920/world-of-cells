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
    public Player player;

    public GameObject canvas;

    private int width=(int)Math.Round(Screen.height*0.0125f);
    private int row=10;
    private int col=10;

    private System.Random random=new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        Player p=Instantiate(player);
        p.newPos(0, 0);
        Consts.player=p;

        for (int i = 0, x=0, y=0; i < col*row; i++, x+=width) {
            Cell c=Instantiate(cell);
            CellText t=Instantiate(cellText);
            c.newPos(x, y);
            c.resourceCount=random.Next(1, 20);
            c.type=Consts.types[random.Next(Consts.types.Length)];

            t.resourceCount=c.resourceCount;
            t.newPos(x, y);
            if ((i+1)%col==0){
                y-=width;
                x=-width;
            }

            Consts.cells[i]=c;
            Consts.texts[i]=t;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
