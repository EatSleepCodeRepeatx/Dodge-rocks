﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rockGeneration : MonoBehaviour {

    System.Random randomNum = new System.Random();
    //timer for main oeration for rock generation
    float timer01 = 0.0f;
    //timer for speed up the generation time
    float timer02 = 0.0f;
    //interval between each generation, smaller == faster
    float interval = 0.85f;
    float time = 1.0f;
    float intervelSpeed = 0.01f;

	void Update () {
        
        if (!Rock4Pooler.Instance.gameOver)
        {
            timer01 += Time.deltaTime;
            timer02 += Time.deltaTime;

            if (interval > 0.35f && timer02 > 1.0f )
            {
                timer02 = 0.0f;
                interval -= intervelSpeed;
            }

            if(interval<0.6f){
                intervelSpeed = 0.003f;
            }

           // Debug.Log(interval + " - " + intervelSpeed );




            if (timer01 > interval)
            {
                timer01 = 0.0f;
                GameObject oj = Rock4Pooler.Instance.GetPooledObject();
                if (oj != null)
                {
                    if (randomNum.Next(0, 2) == 0)
                    {
                        oj.transform.position = new Vector2((float)-2.6, 6);
                    }
                    else
                    {
                        oj.transform.position = new Vector2((float)-0.7, 6);
                    }
                    oj.SetActive(true);
                }

                oj = Rock4Pooler.Instance.GetPooledObject();
                if (oj != null)
                {
                    if (randomNum.Next(0, 2) == 0)
                    {
                        oj.transform.position = new Vector2((float)2.6, 6);
                    }
                    else
                    {
                        oj.transform.position = new Vector2((float)0.7, 6);
                    }
                    oj.SetActive(true);
                }
            }
        }
	}
}
