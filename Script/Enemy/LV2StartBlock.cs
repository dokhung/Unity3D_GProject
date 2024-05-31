using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LV2StartBlock : MonoBehaviour
{
    public int HP = 100;
    // private MeshRenderer mr;
    // private void Start()
    // {
    //     mr = GetComponent<MeshRenderer>();
    // }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("SkillObject"))
        {
            other.gameObject.SetActive(false);
            HP -= 20;
        }
        
        else if (other.gameObject.CompareTag("AttackObject"))
        {
            other.gameObject.SetActive(false);
            HP -= 10;
        }
    }

    private void Update()
    {
        if (HP <= 0)
        {
            gameObject.SetActive(false);
            Invoke("Reset",30f);
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }
}
