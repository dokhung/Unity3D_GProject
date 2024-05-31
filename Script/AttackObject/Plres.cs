using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plres : MonoBehaviour
{
    private float MoveDown = 0;
    private bool MoveDown_Coll = false;
    private bool MoveStop = false;
    private Coroutine cor = null;
    private Coroutine TimeCor = null;
    private bool isOn = false;
    IEnumerator MoveUPDown(bool isUp)
    {
        if (isUp)
        {
            while (transform.position.y < -6)
            {
                transform.Translate(0, 2.5f * Time.deltaTime, 0);
                yield return null;
            }
        }
        else
        {
            while (isOn)
            {
                transform.Translate(0, -5f * Time.deltaTime, 0);
                yield return null;
            }     
        }
    }

    // private void Update()
    // {
    //     if (MoveDown_Coll)
    //     {
    //         MoveDown += -2 * Time.deltaTime;
    //         transform.Translate(0, -5 * Time.deltaTime, 0);
    //     }
    //     else
    //     {
    //         if (MoveDown < 0)
    //         {
    //             MoveDown += 2 * Time.deltaTime;
    //             transform.Translate(0, 3 * Time.deltaTime, 0);
    //             Debug.Log(MoveDown);
    //         }
    //     }
    // }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (TimeCor != null)
            {
               StopCoroutine(TimeCor);
               TimeCor = null;
            }
            isOn = true;
            //MoveDown_Coll = true;
            if (cor!=null)
            {
                StopCoroutine(cor);
            }

            cor = StartCoroutine(MoveUPDown(false));
            //내려가는 코루틴을 시작함
        }
        
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOn = false;
           // MoveDown_Coll = false;
            //내려가는 코루틴을 진행 중이었다면, 멈추고
            //올라가는 코루틴을 진행
            if (TimeCor == null)
            {
                TimeCor = StartCoroutine(Exit()); 
            }
            
        }
    }

    IEnumerator Exit()
    {
        yield return new WaitForSeconds(1f);
        if (cor!=null)
        {
            StopCoroutine(cor);
        }

        cor = StartCoroutine(MoveUPDown(true));
        //내려가는 코루틴을 시작함 
        TimeCor = null;
    }
}
