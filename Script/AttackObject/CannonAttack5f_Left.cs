using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAttack5f_Left : MonoBehaviour
{
    // 역할 :일정시간마다 블릿 생성
    public GameObject CannonBulletPrefab;
    [SerializeField]
    //int poolCount = 1;
    private List<GameObject> objectPool = new List<GameObject>();

    private GameObject obj = null;
    private void Start()
    {
        StartCoroutine(ListBullet());
    }

    private IEnumerator ListBullet()
    {
        while (true)
        {
            if (obj == null)
            {
                obj = Instantiate(CannonBulletPrefab,transform.position,transform.rotation);
            }
            else
            {
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                obj.SetActive(true);
            }
                
            yield return new WaitForSeconds(3f);
            obj.SetActive(false);
            yield return new WaitForSeconds(2f);
            
        }
    }
}
