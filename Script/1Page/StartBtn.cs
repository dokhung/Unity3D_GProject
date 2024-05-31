using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public AudioClip StartClip;
    private AudioSource StartSource;
    public GameObject camera;

    private void Start()
    {
        StartSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayStart()
    {
        StartSource.PlayOneShot(StartClip);
        SceneManager.LoadScene("StartPlay");
    }

    public void AppClose()
    {
        Application.Quit();
    }
}
