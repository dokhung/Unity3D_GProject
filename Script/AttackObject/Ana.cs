using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ana : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Invoke("Init",2f);
        }
    }

    public void Init()
    {
        gameObject.SetActive(true);
    }
}
