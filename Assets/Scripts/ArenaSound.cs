using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaSound : MonoBehaviour
{
    private static AudioSource audioData;


    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    public static void StartArenaSound()
    {
        audioData.Play(0);
    }

    public static void StopArenaSound()
    {
        audioData.Stop();
    }
}
