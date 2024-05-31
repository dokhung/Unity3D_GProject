using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotalRotate : MonoBehaviour
{
    private float Speed = 8;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,1*Speed*Time.deltaTime,0);
    }
}
