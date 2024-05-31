using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject1 : MonoBehaviour
{
    private float Speed = 5;
    private Rigidbody rd;

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.Translate(transform.forward * +1 * Speed * Time.deltaTime);
    }
}
