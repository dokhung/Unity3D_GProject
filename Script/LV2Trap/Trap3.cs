using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap3 : MonoBehaviour
{
    public bool isUp = false;
    private float speed = 100;
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
                rotationX += 1 * speed * Time.deltaTime;
                transform.Rotate(0,0,1 * speed * Time.deltaTime);
                if (rotationX >= 90f)
                {
                    isUp = true;
                }

            }
            else if(isUp)
            {  
                rotationX += -1 * speed * Time.deltaTime;
                transform.Rotate(0,0,-1* speed * Time.deltaTime);
                if (rotationX <= -90f)
                {
                    isUp = false;
                }
                
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody PlayerRigid = other.rigidbody;
            PlayerRigid.AddForce(20,0,0,ForceMode.Impulse);
        }
    }
}
