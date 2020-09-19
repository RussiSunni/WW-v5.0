using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static AudioClip helloSound, doorClosedSound, cardAppearSound, doorOpeningSound, goodbyeSound, doorSound;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        helloSound = Resources.Load<AudioClip>("Sound/Hello");
        doorClosedSound = Resources.Load<AudioClip>("Sound/DoorClosed");
        cardAppearSound = Resources.Load<AudioClip>("Sound/CardAppear");
        doorOpeningSound = Resources.Load<AudioClip>("Sound/DoorOpening");
        goodbyeSound = Resources.Load<AudioClip>("Sound/Goodbye");
        doorSound = Resources.Load<AudioClip>("Sound/Door");
    }

    public static void playHelloSound()
    {
        audioSrc.PlayOneShot(helloSound);
    }
    public static void playDoorClosedSound()
    {
        audioSrc.PlayOneShot(doorClosedSound);
    }
    public static void playDoorOpeningSound()
    {
        audioSrc.PlayOneShot(doorOpeningSound);
    }
    public static void playCardAppearSound()
    {
        audioSrc.PlayOneShot(cardAppearSound);
    }
    public static void playGoodbyeSound()
    {
        audioSrc.PlayOneShot(goodbyeSound);
    }
    public static void playDoorSound()
    {
        audioSrc.PlayOneShot(doorSound);
    }
}
