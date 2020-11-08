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
    public static GameObject helloCard, goodbyeCard, openCard, yesCard, noCard, readCard, hiCard, stopCard, closeCard, byeCard, thankYouCard, okCard, sueCard, mayCard, theCard, sorryCard, goodCard, badCard, girlCard, boyCard, sitCard, morningCard, afternoonCard, eveningCard;
    public static GameObject oneCard, twoCard, threeCard, fourCard, fiveCard, sixCard, sevenCard, eightCard, nineCard, tenCard, elevenCard, twelveCard, thirteenCard, fourteenCard, fifteenCard, sixteenCard, seventeenCard, eighteenCard, nineteenCard, twentyCard;
    public static GameObject upArrow, rightArrow, leftArrow, spellbookButtonLeft, spellbookButtonRight;
    public static string scene;
    public GameObject UICanvas, dictionaryCanvas;
    public static string playerName;
    public static int playerAge;
    public static int sceneOne = 1;
    public static int sceneTwo = 1;
    public static bool hasHelloCard, hasGoodbyeCard, hasOpenCard, hasYesCard, hasNoCard, hasGoodCard, hasBadCard;

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
        Load();

        UICanvas = GameObject.Find("UICanvas");
        upArrow = GameObject.Find("Up Arrow");
        rightArrow = GameObject.Find("Right Arrow");
        leftArrow = GameObject.Find("Left Arrow");
        spellbookButtonLeft = GameObject.Find("SpellbookButton Left");
        spellbookButtonRight = GameObject.Find("SpellbookButton Right");

        // dictionaryCanvas = GameObject.Find("DictionaryCanvas");
        // dictionaryCanvas.SetActive(false);

        helloCard = GameObject.Find("HelloButton");
        goodCard = GameObject.Find("GoodButton");

        //  if (hasGoodCard)
        //      GameControl.goodCard.GetComponent<Button>().interactable = true;

        badCard = GameObject.Find("BadButton");

        goodbyeCard = GameObject.Find("GoodbyeButton");
        openCard = GameObject.Find("OpenButton");
        yesCard = GameObject.Find("YesButton");

        //   if (hasYesCard)
        //       GameControl.yesCard.GetComponent<Button>().interactable = true;

        noCard = GameObject.Find("NoButton");
        readCard = GameObject.Find("ReadButton");
        hiCard = GameObject.Find("HiButton");
        stopCard = GameObject.Find("StopButton");
        closeCard = GameObject.Find("CloseButton");
        byeCard = GameObject.Find("ByeButton");
        thankYouCard = GameObject.Find("ThankYouButton");

        okCard = GameObject.Find("OKButton");
        girlCard = GameObject.Find("GirlButton");
        boyCard = GameObject.Find("BoyButton");
        sitCard = GameObject.Find("SitButton");
        morningCard = GameObject.Find("MorningButton");
        afternoonCard = GameObject.Find("AfternoonButton");
        eveningCard = GameObject.Find("EveningButton");


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


        scene = "Academy";
    }


    public static void CharacterSpeakUIChange()
    {
        GameControl.upArrow.GetComponent<Button>().interactable = false;
        GameControl.rightArrow.GetComponent<Button>().interactable = false;
        GameControl.leftArrow.GetComponent<Button>().interactable = false;
        GameControl.spellbookButtonLeft.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
        GameControl.spellbookButtonLeft.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 35);
        GameControl.spellbookButtonLeft.GetComponent<RectTransform>().anchoredPosition = new Vector3(-17.5f, 0f, 0f);
        GameControl.spellbookButtonRight.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
        GameControl.spellbookButtonRight.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 35);
        GameControl.spellbookButtonRight.GetComponent<RectTransform>().anchoredPosition = new Vector3(17.5f, 0f, 0f);
    }

    public static void WorldNavigationUIChange()
    {
        GameControl.upArrow.GetComponent<Button>().interactable = true;
        GameControl.rightArrow.GetComponent<Button>().interactable = true;
        GameControl.leftArrow.GetComponent<Button>().interactable = true;
        GameControl.spellbookButtonLeft.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140);
        GameControl.spellbookButtonLeft.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
        GameControl.spellbookButtonLeft.GetComponent<RectTransform>().anchoredPosition = new Vector3(-35f, 0f, 0f);
        GameControl.spellbookButtonRight.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140);
        GameControl.spellbookButtonRight.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
        GameControl.spellbookButtonRight.GetComponent<RectTransform>().anchoredPosition = new Vector3(35f, 0f, 0f);
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

    public static void Save()
    {
        Debug.Log("saving");
        Debug.Log(hasGoodCard);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.playerName = playerName;
        data.playerAge = playerAge;
        //   data.sceneOne = sceneOne;
        //data.sceneTwo = sceneTwo;

        data.hasGoodCard = hasGoodCard;
        data.hasYesCard = hasYesCard;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            playerName = data.playerName;
            playerAge = data.playerAge;
            //    sceneOne = data.sceneOne;
            //     sceneTwo = data.sceneTwo;
            hasGoodCard = data.hasGoodCard;
            hasYesCard = data.hasYesCard;
            print(sceneOne);
        }
    }
}

[Serializable]
class PlayerData
{
    public string playerName;
    public int playerAge;
    public int sceneOne;
    public int sceneTwo;
    public bool hasHelloCard, hasGoodbyeCard, hasOpenCard, hasYesCard, hasNoCard, hasGoodCard, hasBadCard;
}

