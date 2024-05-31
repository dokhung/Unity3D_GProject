using System;
using UnityEngine;

public class GetGoldItem : MonoBehaviour
{
    public float rotationSpeed = 5f; // 회전 속도

    void Update()
    {
        // Y축을 기준으로 무한 회전
        transform.Rotate(Vector3.up, rotationSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Control.Instance.Player_AddItem();
            Control.Instance.MyMoney += 10;
            Control.Instance.Score += 50;
            gameObject.SetActive(false);
            Invoke("Init",2f);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          Invoke("Init",2f);  
        }
    }

    public void Init()
    {
        gameObject.SetActive(true);
    }
}

