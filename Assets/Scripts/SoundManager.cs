using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static AudioClip helloSound, doorClosedSound, doorLockedSound, cardAppearSound, doorOpeningSound, goodbyeSound, doorSound, heySound, wolfGrowlSound, bumpSound, pageTurnSound, footstepSound;
    public static AudioClip fairyTalk01, fairyTalk02, fairyTalk03, fairyTalk04, fairyTalk05, connectSound, SecretaryTalk01A, SecretaryTalk01B, SecretaryTalk01C;
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
        doorLockedSound = Resources.Load<AudioClip>("Sound/DoorLocked");

        fairyTalk01 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk01");
        fairyTalk02 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk02");
        fairyTalk03 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk03");
        fairyTalk04 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk04");
        fairyTalk05 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk05");

        SecretaryTalk01A = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk01A");
        SecretaryTalk01B = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk01B");
        SecretaryTalk01C = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk01C");
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
    public static void playDoorLockedSound()
    {
        audioSrc.PlayOneShot(doorLockedSound);
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
    public static void playFairyTalk03Sound()
    {
        audioSrc.PlayOneShot(fairyTalk03);
    }
    public static void playFairyTalk04Sound()
    {
        audioSrc.PlayOneShot(fairyTalk04);
    }
    public static void playFairyTalk05Sound()
    {
        audioSrc.PlayOneShot(fairyTalk05);
    }
    public static void playSecretaryTalk01ASound()
    {
        audioSrc.PlayOneShot(SecretaryTalk01A);
    }
    public static void playSecretaryTalk01BSound()
    {
        audioSrc.PlayOneShot(SecretaryTalk01B);
    }
    public static void playSecretaryTalk01CSound()
    {
        audioSrc.PlayOneShot(SecretaryTalk01C);
    }
}
