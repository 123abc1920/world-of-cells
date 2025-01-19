using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CellText : MonoBehaviour
{
    public int resourceCount;
    public bool hidden = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = this.resourceCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newPos(int x, int y)
    {
        transform.position = new Vector3(x, y, 0);
    }

    public void hideText()
    {
        GetComponent<TMP_Text>().text = "";
        hidden = true;
    }

    public void updateText(int r)
    {
        this.resourceCount = r;
        if (this.hidden)
        {
            return;
        }
        GetComponent<TMP_Text>().text = this.resourceCount.ToString();
    }
}
