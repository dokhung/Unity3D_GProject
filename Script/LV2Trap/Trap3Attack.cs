using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap3Attack : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody PlayerRigid = other.rigidbody;
            PlayerRigid.AddForce(20,0,0,ForceMode.Impulse);
        }
    }
}
