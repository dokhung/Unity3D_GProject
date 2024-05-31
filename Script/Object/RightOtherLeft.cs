using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightOtherLeft : MonoBehaviour
{
    public bool isUp = false;
    private float speed = 10;
    float rotationX = 0;
    
    private void Start()
    {
        
        StartCoroutine(MoveX());
    }

    IEnumerator MoveX()
    {
        
        while (true)
        {
            if (!isUp)
            {
                rotationX += -1 * speed * Time.deltaTime;
                transform.Rotate(-1 * speed * Time.deltaTime,0,0);
                if (rotationX <= -15f)
                {
                    isUp = true;
                }
            }
            else if(isUp)
            {  
                rotationX += 1 * speed * Time.deltaTime;
                transform.Rotate(1 * speed * Time.deltaTime,0,0);
                if (rotationX >= 15f)
                {
                    isUp = false;
                } 
            }

            yield return null;
        }
    }
}
