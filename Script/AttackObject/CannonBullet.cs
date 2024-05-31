using System;
using System.Collections;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
    private float Speed = 5;
    

    private void Update()
    {
        transform.Translate(transform.right * -1 * Speed * Time.deltaTime);
    }
}

