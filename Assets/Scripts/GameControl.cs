using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public static GameObject helloCard, doorCard, goodbyeCard, openCard, yesCard, noCard, readCard, hiCard, stopCard, closeCard, byeCard, thankYouCard, niceCard, toCard, meetCard, youCard, niceToMeetYouTooCard, okCard, sueCard, mayCard, theCard, sorryCard, goodCard, badCard;
    public static string scene;
    public GameObject UICanvas, dictionaryCanvas;

    void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UICanvas = GameObject.Find("UICanvas");
        // dictionaryCanvas = GameObject.Find("DictionaryCanvas");
        // dictionaryCanvas.SetActive(false);

        helloCard = GameObject.Find("HelloButton");
        doorCard = GameObject.Find("DoorButton");
        goodbyeCard = GameObject.Find("GoodbyeButton");
        openCard = GameObject.Find("OpenButton");
        yesCard = GameObject.Find("YesButton");
        noCard = GameObject.Find("NoButton");
        readCard = GameObject.Find("ReadButton");
        hiCard = GameObject.Find("HiButton");
        // enterCard = GameObject.Find("EnterButton");
        stopCard = GameObject.Find("StopButton");
        closeCard = GameObject.Find("CloseButton");
        byeCard = GameObject.Find("ByeButton");
        thankYouCard = GameObject.Find("ThankYouButton");
        goodCard = GameObject.Find("GoodButton");
        badCard = GameObject.Find("BadButton");


        niceCard = GameObject.Find("NiceButton");
        toCard = GameObject.Find("ToButton");
        meetCard = GameObject.Find("MeetButton");
        youCard = GameObject.Find("YouButton");
        niceToMeetYouTooCard = GameObject.Find("NiceToMeetYouTooButton");
        okCard = GameObject.Find("OKButton");
        sueCard = GameObject.Find("SueButton");
        mayCard = GameObject.Find("MayButton");
        theCard = GameObject.Find("TheButton");
        sorryCard = GameObject.Find("SorryButton");

        //  doorCard.SetActive(false);

        goodbyeCard.SetActive(false);
        openCard.SetActive(false);
        yesCard.SetActive(false);
        noCard.SetActive(false);
        readCard.SetActive(false);
        hiCard.SetActive(false);    
        stopCard.SetActive(false);
        closeCard.SetActive(false);
        byeCard.SetActive(false);
        thankYouCard.SetActive(false);
        goodCard.SetActive(false);
        badCard.SetActive(false);

        okCard.SetActive(false);
        sueCard.SetActive(false);
        mayCard.SetActive(false);
        theCard.SetActive(false);
        sorryCard.SetActive(false);

        scene = "Academy";
    }

    public void Dictionary()
    {
        if (dictionaryCanvas.activeSelf)
        {
            dictionaryCanvas.SetActive(false);
            UICanvas.SetActive(true);
        }
        else if (UICanvas.activeSelf)
        {
            dictionaryCanvas.SetActive(true);
            UICanvas.SetActive(false);
        }
    }

    public static void Restart()
    {
        Destroy(control);
    }
}