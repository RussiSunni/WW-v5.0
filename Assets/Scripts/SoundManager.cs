using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static AudioClip helloSound, doorClosedSound, cardAppearSound, doorOpeningSound, goodbyeSound, doorSound, heySound, wolfGrowlSound, bumpSound, pageTurnSound;
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
        heySound = Resources.Load<AudioClip>("Sound/Hey");
        wolfGrowlSound = Resources.Load<AudioClip>("Sound/WolfGrowl");
        bumpSound = Resources.Load<AudioClip>("Sound/Bump");
        pageTurnSound = Resources.Load<AudioClip>("Sound/PageTurn");
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
    public static void playHeySound()
    {
        audioSrc.PlayOneShot(heySound);
    }
    public static void playWolfGrowlSound()
    {
        audioSrc.PlayOneShot(wolfGrowlSound);
    }
    public static void playBumpSound()
    {
        audioSrc.PlayOneShot(bumpSound);
    }
    public static void playPageTurnSound()
    {
        audioSrc.PlayOneShot(pageTurnSound);
    }
}
