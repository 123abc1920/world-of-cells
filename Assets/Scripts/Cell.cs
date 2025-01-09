using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int resourceCount;
    public CellTypes type;

    void Start()
    {
        
    }

    public void newPos(int x, int y){
        transform.position = new Vector3(x, y, 1);
    }

    void Update()
    {

    }
}
