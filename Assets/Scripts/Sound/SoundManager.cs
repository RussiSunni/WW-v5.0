using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static AudioClip helloSound, doorClosedSound, doorLockedSound, cardAppearSound, doorOpeningSound, goodbyeSound, doorSound, heySound, wolfGrowlSound, bumpSound, pageTurnSound, footstepSound, correctSound, hiSound, evaSound, doorCraftSound, fairyCraftSound, effectPop;
    public static AudioClip fairyTalk01, fairyTalk02, fairyTalk03, fairyTalk04, fairyTalk05, fairyTalk06, fairyTalk07, fairyTalk08, fairyTalk09, fairyHuh, fairyOK, fairyHello, connectSound, SecretaryTalk01, SecretaryHuh, SecretaryTalk01A, SecretaryTalk01B, SecretaryTalk01C, SecretaryTalk02, SecretaryTalk03, SecretaryTalk04, SecretaryTalk05, WolfTalk01, wolfHi, ArenaMusic01, WolfHello, Student01Hi, Student01Huh, dinoTalk01, dinoTalk02, dinoTalk03, dinoTalk04, dinoTalk05, student06Talk01, student06Talk02, student06Talk03, student06Huh, student02Hi, interactionMusic;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();

        helloSound = Resources.Load<AudioClip>("Sound/AWS Polly/Hello");
        hiSound = Resources.Load<AudioClip>("Sound/AWS Polly/Hi");
        evaSound = Resources.Load<AudioClip>("Sound/AWS Polly/Eva");

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
        correctSound = Resources.Load<AudioClip>("Sound/Correct");
        interactionMusic = Resources.Load<AudioClip>("Sound/InteractionMusic");

        Student01Hi = Resources.Load<AudioClip>("Sound/AWS Polly/Student01Hi");
        Student01Huh = Resources.Load<AudioClip>("Sound/AWS Polly/Student01Huh");

        student06Talk01 = Resources.Load<AudioClip>("Sound/AWS Polly/Student06Talk01");
        student06Talk02 = Resources.Load<AudioClip>("Sound/AWS Polly/Student06Talk02");
        student06Talk03 = Resources.Load<AudioClip>("Sound/AWS Polly/Student06Talk03");

        student06Huh = Resources.Load<AudioClip>("Sound/AWS Polly/Student06Huh");

        student02Hi = Resources.Load<AudioClip>("Sound/AWS Polly/Student02Hi");

        // fairyTalk01 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk01");
        // fairyTalk02 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk02");
        // fairyTalk03 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk03");
        // fairyTalk04 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk04");
        // fairyTalk05 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk05");
        fairyTalk06 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk06");
        fairyTalk07 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk07");
        fairyTalk08 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk08");
        fairyTalk09 = Resources.Load<AudioClip>("Sound/AWS Polly/FairyTalk09");
        fairyHuh = Resources.Load<AudioClip>("Sound/AWS Polly/FairyHuh");
        fairyOK = Resources.Load<AudioClip>("Sound/AWS Polly/FairyOK");
        fairyHello = Resources.Load<AudioClip>("Sound/AWS Polly/FairyHello");

        // SecretaryTalk01A = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk01A");
        // SecretaryTalk01B = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk01B");
        // SecretaryTalk01C = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk01C");
        // SecretaryTalk02 = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk02");
        // SecretaryTalk03 = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk03");
        // SecretaryTalk04 = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk04");
        // SecretaryTalk05 = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk05");

        SecretaryTalk01 = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryTalk01");
        SecretaryHuh = Resources.Load<AudioClip>("Sound/AWS Polly/SecretaryHuh");

        WolfTalk01 = Resources.Load<AudioClip>("Sound/AWS Polly/WolfTalk01");
        WolfHello = Resources.Load<AudioClip>("Sound/AWS Polly/WolfHello");
        wolfHi = Resources.Load<AudioClip>("Sound/AWS Polly/WolfHi");

        dinoTalk01 = Resources.Load<AudioClip>("Sound/AWS Polly/DinoTalk01");
        dinoTalk02 = Resources.Load<AudioClip>("Sound/AWS Polly/DinoTalk02");
        dinoTalk03 = Resources.Load<AudioClip>("Sound/AWS Polly/DinoTalk03");
        dinoTalk04 = Resources.Load<AudioClip>("Sound/AWS Polly/DinoTalk04");
        dinoTalk05 = Resources.Load<AudioClip>("Sound/AWS Polly/DinoTalk05");

        ArenaMusic01 = Resources.Load<AudioClip>("Sound/Harp");

        fairyCraftSound = Resources.Load<AudioClip>("Sound/Crafted/Fairy");
        doorCraftSound = Resources.Load<AudioClip>("Sound/Crafted/Door");

        effectPop = Resources.Load<AudioClip>("Sound/EffectPop");
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

    public static void playCorrectSound()
    {
        audioSrc.PlayOneShot(correctSound);
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
    public static void playFairyTalk06Sound()
    {
        audioSrc.PlayOneShot(fairyTalk06);
    }

    public static void playFairyTalk07Sound()
    {
        audioSrc.PlayOneShot(fairyTalk07);
    }

    public static void playWolfTalk01Sound()
    {
        audioSrc.PlayOneShot(WolfTalk01);
    }

    public static void playArenaMusic01Sound()
    {
        audioSrc.PlayOneShot(ArenaMusic01);
    }

    public static void playWordSound(AudioClip audioClip)
    {
        audioSrc.PlayOneShot(audioClip);
    }

    // All ----------------------------------------
    public static void playSound(AudioClip audioclip)
    {
        audioSrc.PlayOneShot(audioclip);
    }

    // Student 6 ----------------------------------------

    public static void playStudent06Talk02Sound()
    {
        audioSrc.PlayOneShot(student06Talk02);
    }
    public static void playStudent06HuhSound()
    {
        audioSrc.PlayOneShot(student06Huh);
    }

    // Student 2 ----------------------------------------

    public static void playStudent02HiSound()
    {
        audioSrc.PlayOneShot(student02Hi);
    }
}
