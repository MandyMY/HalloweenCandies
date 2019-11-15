using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static Sounds instance;

    public AudioSource bgMusic;
    public AudioSource playerMusic;
    public AudioClip jump, over;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void JumpM()
    {
        playerMusic.clip = jump;
        playerMusic.Play();
    }

    public void DieM()
    {
        playerMusic.clip = over;
        playerMusic.Play();
    }

    public void BgM(bool play)
    {
        if (play) bgMusic.Play();
        else bgMusic.Stop();
    }
}
