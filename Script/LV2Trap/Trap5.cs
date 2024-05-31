using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap5 : MonoBehaviour
{
    private float speed = 100;
    // Update is called once per frame
    void Update()
    {
       transform.Rotate(1 * speed * Time.deltaTime,0,0); 
    }
}
