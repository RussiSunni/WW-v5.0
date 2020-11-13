using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static AudioClip helloSound, doorClosedSound, cardAppearSound, doorOpeningSound, goodbyeSound, doorSound, heySound, wolfGrowlSound, bumpSound, pageTurnSound, footstepSound;
    public static AudioClip fairyTalk01, fairyTalk02, fairyTalk03, connectSound;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        helloSound = Resources.Load<AudioClip>("Sound/Hello");
        doorClosedSound = Resources.Load<AudioClip>("Sound/DoorClosed");
        cardAppearSound = Resources.Load<AudioClip>("Sound/CardAppear");
        connectSound = Resources.Load<AudioClip>("Sound/Connect");
        doorOpeningSound = Resources.Load<AudioClip>("Sound/DoorOpening");
        goodbyeSound = Resources.Load<AudioClip>("Sound/Goodbye");
        doorSound = Resources.Load<AudioClip>("Sound/Door");
        heySound = Resources.Load<AudioClip>("Sound/Hey");
        wolfGrowlSound = Resources.Load<AudioClip>("Sound/WolfGrowl");
        bumpSound = Resources.Load<AudioClip>("Sound/Bump");
        pageTurnSound = Resources.Load<AudioClip>("Sound/PageTurn");
        footstepSound = Resources.Load<AudioClip>("Sound/Footstep");

        fairyTalk01 = Resources.Load<AudioClip>("Sound/AWS Polly/Hello_how_are_you?_AWS");
        fairyTalk02 = Resources.Load<AudioClip>("Sound/AWS Polly/Are_you_lost?_AWS");
        fairyTalk03 = Resources.Load<AudioClip>("Sound/AWS Polly/Are_you_lost?_AWS");
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
    public static void playConnectSound()
    {
        audioSrc.PlayOneShot(connectSound);
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
    public static void playFootstepSound()
    {
        audioSrc.PlayOneShot(footstepSound);
    }
    public static void playFairyTalk01Sound()
    {
        audioSrc.PlayOneShot(fairyTalk01);
    }
    public static void playFairyTalk02Sound()
    {
        audioSrc.PlayOneShot(fairyTalk02);
    }
}
