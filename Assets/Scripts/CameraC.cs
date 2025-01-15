using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraC : MonoBehaviour
{
    private static Vector2 vector;
    private static Vector3 pos;

    private int width=(int)Math.Round(Screen.height*0.0125f);
    private int row=10;
    private int col=10;

    // Start is called before the first frame update
    void Start()
    {
        pos=transform.position;
    }

    public static void translate(Vector2 v){
        vector=v;
    }

    public static Vector3 getPos(){
        return pos;
    }

    // Update is called once per frame
    public Vector2 start;
    public Vector2 finish;
    void Update()
    { 
        Resolution[] resolutions = Screen.resolutions;
        float padTop=Screen.height*0.25f;
        float padBottom=Screen.height*0.1f;

        float padLeft=Screen.width*0.1f;
        float padRight=padLeft;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                start = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
            }
            if (touch.phase == TouchPhase.Moved){
                finish=Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                float fx=-finish.x, sx=start.x, fy=-finish.y, sy=start.y;
                if (transform.position.x<30&&-finish.x+start.x<0){
                    fx=0;
                    sx=0;
                }
                if (transform.position.x>209-50&&-finish.x+start.x>0){
                    fx=0;
                    sx=0;
                }
                if (transform.position.y>-40&&-finish.y+start.y>0){
                    fy=0;
                    sy=0;
                }
                if (transform.position.y<-209+104&&-finish.y+start.y<0){
                    fy=0;
                    sy=0;
                }

                transform.Translate(new Vector3(Mathf.Lerp(fx,sx, 0.5f),Mathf.Lerp(fy,sy, 0.5f), 0), Space.World);
                start=finish;
                return;
            }
            if (touch.phase == TouchPhase.Stationary)
            {
                if (Consts.buildBridge||Consts.buildHut){
                    Consts.game.build(start);
                }else{
                    Consts.game.gameStep(start);
                }
            }
        }
    }
}
