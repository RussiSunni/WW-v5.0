using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutdoorsAmbientSound : MonoBehaviour
{
    private static AudioSource audioData;
    private AudioClip outdoorsSound;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    public static void StopOutdoorAmbientSound()
    {
        audioData.Pause();
    }
}
