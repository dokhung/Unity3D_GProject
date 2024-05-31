using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeadRotate : MonoBehaviour
{
    private float speed = 100;

    private void Update()
    {
        transform.Rotate(1 * speed * Time.deltaTime,0,0);
    }
}
