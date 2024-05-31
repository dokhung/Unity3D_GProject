using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Invoke("Init",1f);
        }
    }

    public void Init()
    {
        gameObject.SetActive(true);
    }
}
