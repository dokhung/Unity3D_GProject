using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAttack : MonoBehaviour
{
    private float speed = 1.5f;
    private Rigidbody rigid;
    
    void Update()
    {
        transform.Rotate(0,1*speed,0);
    }

    
}
