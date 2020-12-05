using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicSound : MonoBehaviour
{
    private static AudioSource audioData;
    //private AudioClip mainMusicSound;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    public static void StopMainMusicSound()
    {
        audioData.Pause();
    }

    public static void PlayMainMusicSound()
    {
        audioData.Play(0);
    }
}
