using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraC : MonoBehaviour
{
    private static Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    public Vector2 start;
    public Vector2 finish;
    private float delta = 0.5f;
    void Update()
    {
        if (!Consts.EndShown && !Consts.OneCardShown)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    start = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    finish = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.nearClipPlane));
                    float fx = -finish.x, sx = start.x, fy = -finish.y, sy = start.y;
                    if (transform.position.x < 30 && -finish.x + start.x < 0)
                    {
                        fx = 0;
                        sx = 0;
                    }
                    if (transform.position.x > 209 - 50 && -finish.x + start.x > 0)
                    {
                        fx = 0;
                        sx = 0;
                    }
                    if (transform.position.y > -40 && -finish.y + start.y > 0)
                    {
                        fy = 0;
                        sy = 0;
                    }
                    if (transform.position.y < -209 + 104 && -finish.y + start.y < 0)
                    {
                        fy = 0;
                        sy = 0;
                    }

                    transform.Translate(new Vector3(Mathf.Lerp(fx, sx, 0.5f), Mathf.Lerp(fy, sy, 0.5f), 0), Space.World);
                    start = finish;
                    return;
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    if (Time.time - Consts.lastClick >= delta)
                    {
                        if (Consts.buildBridge || Consts.buildHut)
                        {
                            Consts.game.build(start);
                        }
                        else
                        {
                            if (Consts.game.player.canMove)
                            {
                                Consts.game.gameStep(start);
                            }
                            else
                            {
                                Consts.game.skipStep();
                            }
                        }
                        Consts.lastClick = Time.time;
                    }
                }
            }
        }
    }
}
