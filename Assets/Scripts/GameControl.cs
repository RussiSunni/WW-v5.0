using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public static GameObject helloCard, doorCard, goodbyeCard, openCard;

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
        //  helloCard = GameObject.Find("HelloButton");
        doorCard = GameObject.Find("DoorButton");
        goodbyeCard = GameObject.Find("GoodbyeButton");
        openCard = GameObject.Find("OpenButton");
        //  helloCard.SetActive(false);
        doorCard.SetActive(false);
        goodbyeCard.SetActive(false);
        openCard.SetActive(false);
    }

    public static void Restart()
    {
        doorCard.SetActive(false);
        goodbyeCard.SetActive(false);
        openCard.SetActive(false);
        Academy.cameraPos = new Vector3(0, 0, -10);
    }
}