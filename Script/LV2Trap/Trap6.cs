using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Trap6 : MonoBehaviour
{
    public GameObject RockPrefab;
    public List<GameObject> RockPRefabObjectPool;
    private GameObject obj;
    public Transform Target;

    private void Start()
    {
        StartCoroutine(pool());
    }

    IEnumerator pool()
    {
        while (true)
        {
            if (obj == null)
            {
                    obj = Instantiate(RockPrefab, Target.transform.position, Target.transform.rotation);
                    obj.SetActive(false);
            }
            else
            {
                    obj.transform.position = Target.transform.position;
                    obj.transform.rotation = Target.transform.rotation;
                    
            }
            
            yield return new WaitForSeconds(1f);
            obj.SetActive(true);
            yield return new WaitForSeconds(6f);
            obj.SetActive(false);
            
        }
    }
}
