using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMove : MonoBehaviour
{
    private float speed = 100;
    void Update()
    {
        transform.Rotate(0,1*speed*Time.deltaTime,0);
    }
}
