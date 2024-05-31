using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAttack2 : MonoBehaviour
{
    private float speed = 2;
    void Update()
    {
        transform.Rotate(0,-1*speed,0);
    }
}
