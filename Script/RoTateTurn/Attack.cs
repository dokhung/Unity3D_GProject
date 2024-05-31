using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    
    // private Rigidbody rigid;
    // private void Start()
    // {
    //     rigid = GetComponent<Rigidbody>();
    // }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
        
            if (playerRigidbody != null)
            {
                Vector3 forceDirection = new Vector3(5, 5, 0);
                playerRigidbody.AddForce(forceDirection, ForceMode.Impulse);
                Control.Instance.HitST(other);
            }
        }
    }
}
