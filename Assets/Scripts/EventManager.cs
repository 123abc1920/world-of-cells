using System;

public class EventManager
{
    public static Event[] events=new Event[3];

    public static int[] variances={0,0,0,0,0,0,1,1,1,2,2};

    private static Random random=new Random();

    static EventManager(){
        events[0]=new Event("Вы упали в яму. Часть собранных ресурсов утрачена.", 0);
        events[1]=new Event("Вы оказались в лесу. Количество дерева увеличено.", 1);
        events[2]=new Event("Вы нашли клад. Количество ресурсов увеличено.", 2);
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
    }
}
