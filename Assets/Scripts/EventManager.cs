using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static Event[] events=new Event[4];

    public static int[] variances=new int[10];

    static EventManager(){
        events[0]=new Event("Вы упали в яму. Часть собранных ресурсов утрачена.", 0, 5);
        events[1]=new Event("Вы оказались в лесу. Количество дерева увеличено.", 1, 2);
        events[2]=new Event("Вы нашли клад. Количество ресурсов увеличено.", 2, 2);
        events[3]=new Event("Вы встретили магических существ. Они делятся с вами ресурсами.", 3, 1);

        int k=0;
        for (int i=0; i<events.Length; i++){
            for (int j=0; j<events[i].periodicity; j++){
                variances[k]=i;
                k++;
            }
        }
    }

    public static void eventAction(int index){
        if (index==0){
            Consts.game.tree+=10;
            Consts.game.water+=10;
            Consts.game.rock+=10;
            return;
        }
        if (index==1){
            Consts.game.tree-=10;
            return;
        }
        if (index==2){
            Consts.game.tree-=10;
            Consts.game.water-=10;
            Consts.game.rock-=10;
            return;
        }
        if (index==3){
            Consts.game.tree-=15;
            Consts.game.water-=15;
            Consts.game.rock-=15;
            return;
        }
    }
}
