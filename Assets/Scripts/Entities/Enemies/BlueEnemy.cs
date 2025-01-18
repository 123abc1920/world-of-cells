using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour
{
    public int cell;
    public int[] a={1, Consts.ONE_ROW, -1, -Consts.ONE_ROW};
    public bool isAlive=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newPos(float x, float y){
        transform.position = new Vector3(x, y, 1);
    }
}
