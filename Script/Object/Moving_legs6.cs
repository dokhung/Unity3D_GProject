using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_legs6 : MonoBehaviour
{
    [Header("Speed")]
    public float ObjectSpeed = 10.0f;

    private bool isMovingForward = true;
    private float moveDuration = 2.0f;
    private float timer = 0.0f;
    private Rigidbody rb;
    
    public float xForce = 10f;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= moveDuration)
        {
            timer = 0.0f;
            isMovingForward = !isMovingForward;
        }
        float deltaMovement = ObjectSpeed * Time.deltaTime;
        Quaternion currentPosition = gameObject.transform.rotation;
        currentPosition.x += isMovingForward ? deltaMovement : -deltaMovement;
        gameObject.transform.rotation = currentPosition;
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
