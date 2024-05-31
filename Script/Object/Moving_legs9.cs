using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_legs9 : MonoBehaviour
{
    [Header("Speed")]
    public float ObjectSpeed = 10.0f;

    private bool isMovingForward = true;
    private float moveDuration = 2.0f;
    private float timer = 0.0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= moveDuration)
        {
            timer = 0.0f;
            isMovingForward = !isMovingForward;
        }
        float deltaMovement = ObjectSpeed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        currentPosition.x += isMovingForward ? deltaMovement : -deltaMovement;
        gameObject.transform.position = currentPosition;
    }
}
