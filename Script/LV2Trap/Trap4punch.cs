using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap4punch : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody PlayerRigid = other.rigidbody;
            PlayerRigid.AddForce(15,0,0,ForceMode.Impulse);
            Control.Instance.HitST(other);
        }
    }
}
