using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int cell;

    // Start is called before the first frame update
    void Start()
    {
        this.cell=0;
    }

    public void newPos(float x, float y){
        transform.position = new Vector3(x, y, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
