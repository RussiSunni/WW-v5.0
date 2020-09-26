using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public static GameObject helloCard, doorCard, goodbyeCard, openCard, yesCard, noCard, readCard, hiCard, enterCard, stopCard;

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
        doorCard = GameObject.Find("DoorButton");
        goodbyeCard = GameObject.Find("GoodbyeButton");
        openCard = GameObject.Find("OpenButton");
        yesCard = GameObject.Find("YesButton");
        noCard = GameObject.Find("NoButton");
        readCard = GameObject.Find("ReadButton");
        hiCard = GameObject.Find("HiButton");
        enterCard = GameObject.Find("EnterButton");
        stopCard = GameObject.Find("StopButton");


        doorCard.SetActive(false);
        goodbyeCard.SetActive(false);
        openCard.SetActive(false);
        yesCard.SetActive(false);
        noCard.SetActive(false);
        readCard.SetActive(false);
        hiCard.SetActive(false);
        enterCard.SetActive(false);
        stopCard.SetActive(false);
    }

    public static void Restart()
    {
        Destroy(control);
    }
}