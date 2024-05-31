using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Long_Legs_Move : MonoBehaviour
{
    [Header("Speed")]
    public float ObjectSpeed = 2.0f;

    private bool isMovingForward = true;
    private float moveDuration = 2.0f;
    private float timer = 0.0f;

    private void Update()
    {
        float deltaMovement = ObjectSpeed * Time.deltaTime;
        Quaternion currentRotation = gameObject.transform.rotation;
        currentRotation *= Quaternion.Euler(0f, 0f, deltaMovement);
        gameObject.transform.rotation = currentRotation;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.rotation.eulerAngles.x > 50)
            {
                Vector3 force = new Vector3(0, 10f, -10);
                other.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            }
        }
    }
}
