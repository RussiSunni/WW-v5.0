using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public static GameObject helloCard, goodbyeCard, openCard, yesCard, noCard, readCard, hiCard, stopCard, closeCard, byeCard, thankYouCard, okCard, sueCard, mayCard, theCard, sorryCard, goodCard, badCard, girlCard, boyCard;
    public static GameObject oneCard, twoCard, threeCard, fourCard, fiveCard, sixCard, sevenCard, eightCard, nineCard, tenCard, elevenCard, twelveCard, thirteenCard, fourteenCard, fifteenCard, sixteenCard, seventeenCard, eighteenCard, nineteenCard, twentyCard;
    public static string scene;
    public GameObject UICanvas, dictionaryCanvas;
    public string playerName;

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
        goodbyeCard = GameObject.Find("GoodbyeButton");
        openCard = GameObject.Find("OpenButton");
        yesCard = GameObject.Find("YesButton");
        noCard = GameObject.Find("NoButton");
        readCard = GameObject.Find("ReadButton");
        hiCard = GameObject.Find("HiButton");
        stopCard = GameObject.Find("StopButton");
        closeCard = GameObject.Find("CloseButton");
        byeCard = GameObject.Find("ByeButton");
        thankYouCard = GameObject.Find("ThankYouButton");
        goodCard = GameObject.Find("GoodButton");
        badCard = GameObject.Find("BadButton");
        okCard = GameObject.Find("OKButton");
        girlCard = GameObject.Find("GirlButton");
        boyCard = GameObject.Find("BoyButton");


        oneCard = GameObject.Find("1Button");
        twoCard = GameObject.Find("2Button");
        threeCard = GameObject.Find("3Button");
        fourCard = GameObject.Find("4Button");
        fiveCard = GameObject.Find("5Button");
        sixCard = GameObject.Find("6Button");
        sevenCard = GameObject.Find("7Button");
        eightCard = GameObject.Find("8Button");
        nineCard = GameObject.Find("9Button");
        tenCard = GameObject.Find("10Button");
        elevenCard = GameObject.Find("11Button");
        twelveCard = GameObject.Find("12Button");
        thirteenCard = GameObject.Find("13Button");
        fourteenCard = GameObject.Find("14Button");
        fifteenCard = GameObject.Find("15Button");
        sixteenCard = GameObject.Find("16Button");
        seventeenCard = GameObject.Find("17Button");
        eighteenCard = GameObject.Find("18Button");
        nineteenCard = GameObject.Find("19Button");
        twentyCard = GameObject.Find("20Button");



        sueCard = GameObject.Find("SueButton");
        mayCard = GameObject.Find("MayButton");
        theCard = GameObject.Find("TheButton");
        sorryCard = GameObject.Find("SorryButton");


        //   goodbyeCard.SetActive(false);
        //   openCard.SetActive(false);
        // yesCard.SetActive(false);
        // noCard.SetActive(false);
        readCard.SetActive(false);
        hiCard.SetActive(false);
        stopCard.SetActive(false);
        closeCard.SetActive(false);
        byeCard.SetActive(false);
        //  thankYouCard.SetActive(false);
        //goodCard.SetActive(false);   
        //   badCard.SetActive(false);
        // girlCard.SetActive(false);
        //  boyCard.SetActive(false);

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

    public void Save()
    {
        Debug.Log("saving");
        //  playerName = "testplayer";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        //  data.playerName = playerName;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //  playerName = data.playerName;
            //    print(playerName);
        }
    }
}

[Serializable]
class PlayerData
{
    public string playerName;
}

