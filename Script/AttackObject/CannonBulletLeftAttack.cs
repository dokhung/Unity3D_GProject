using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBulletLeftAttack : MonoBehaviour
{
    private float Speed = 5;

    private void Update()
    {
        transform.Translate(transform.right * 1 * Speed * Time.deltaTime);
    }
}
