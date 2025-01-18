using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int cell;

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

    public List<int> getAvailableCells() {
        List<int> result=new List<int> ();
        int[] a={1, Consts.ONE_ROW, -1, -Consts.ONE_ROW};

        for (int i=0; i<a.Length; i++){
            int index=this.cell+a[i];

            if (Consts.game.cells[index].isAlive&&index<100&&index>=0){
                result.Add(index);
            }
        }

        return result;
    }
}
