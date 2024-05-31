using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SkillObject"))
        {
            other.gameObject.SetActive(false);
            transform.Rotate(90,0,0);
            StartCoroutine(Init());
        }
    }

    IEnumerator Init()
    {
        yield return new WaitForSeconds(3f);
        transform.Rotate(0,0,0);
    }
}
