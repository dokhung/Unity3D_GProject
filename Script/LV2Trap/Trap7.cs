using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap7 : MonoBehaviour
{
    public bool isdown = false;
    private float speed = 10;
    private float MoveY = 0;

    private void Start()
    {
        StartCoroutine(F_MoveY());
    }

    IEnumerator F_MoveY()
    {
        while (true)
        {
            if (!isdown)
            {
                MoveY += -1 * speed * Time.deltaTime;
                transform.Translate(0,-1 * speed * Time.deltaTime,0);
                
                if (MoveY <= -15)
                {
                    isdown = true;
                }
            }
            else
            {
                MoveY += 1* speed * Time.deltaTime;
                transform.Translate(0,1 * speed * Time.deltaTime,0);
                if (MoveY >= -2)
                {
                    isdown = false;
                }
                
            }
            yield return null;
            
        }
        
        
    }
}
