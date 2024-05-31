using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointFunsion : MonoBehaviour
{
    void Update()
    {
       transform.Rotate(new Vector3(0,100f*Time.deltaTime)); 
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Invoke("Respon",2f);

        }
    }

    public void Respon()
    {
        gameObject.SetActive(true);
    }
}
