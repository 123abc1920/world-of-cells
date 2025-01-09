using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 
using UnityEngine.UI;

public class CellText : MonoBehaviour
{
    public int resourceCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void newPos(int x, int y){
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = this.resourceCount.ToString();
    }
}
