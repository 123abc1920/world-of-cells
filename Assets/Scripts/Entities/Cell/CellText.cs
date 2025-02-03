using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CellText : MonoBehaviour
{
    public int id;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = Consts.game.cells[this.id].resourceCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Consts.game.cells[this.id].isAlive || Consts.game.cells[this.id].isBridge || Consts.game.cells[this.id].isHut)
        {
            GetComponent<TMP_Text>().text = "";
        }
        else
        {
            GetComponent<TMP_Text>().text = Consts.game.cells[this.id].resourceCount.ToString();
        }
    }

    public void newPos(int x, int y)
    {
        transform.position = new Vector3(x, y, 0);
    }
}
