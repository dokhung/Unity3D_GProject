using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Right_and_Left : MonoBehaviour
{
    private float speed = 3;
    private bool Stop = false;
    float TranslateX = 0;

    private void Start()
    {
        StartCoroutine(MoveX());
    }
    
    IEnumerator MoveX()
    {
        while (true)
        {
            if (!Stop)
            {
                TranslateX += 1 * speed * Time.deltaTime;
                transform.Translate(0, 0, 1 * speed * Time.deltaTime);
                if (TranslateX >= 3)
                {
                    Stop = true;
                }
            }
            else if (Stop)
            {
                TranslateX -= 1 * speed * Time.deltaTime;
                transform.Translate(0, 0, -1 * speed * Time.deltaTime);
                if (TranslateX <= -3)
                {
                    Stop = false;
                } 
            }
            yield return null;
        }
    }
}
