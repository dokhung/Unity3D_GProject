using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    void Start()
    {
        Invoke("ReturnTitleGo",5f);
    }

    public void ReturnTitleGo()
    {
        SceneManager.LoadScene("Title");
    }
}
