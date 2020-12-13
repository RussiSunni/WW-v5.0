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
    public static GameObject oneCard, twoCard, threeCard, fourCard, fiveCard, sixCard, sevenCard, eightCard, nineCard, tenCard, elevenCard, twelveCard, thirteenCard, fourteenCard, fifteenCard, sixteenCard, seventeenCard, eighteenCard, nineteenCard, twentyCard, doorCard, youCard, evaCard;
    public static GameObject upArrow, rightArrow, leftArrow, spellbookButtonLeft, spellbookButtonRight, controlButton, cardMoveToggle, cardPhraseToggle, actionHandPanel, canvasCode;
    public static string scene;
    public GameObject UICanvas;
    public static string playerName;
    public static int playerAge;
    public static int sceneOne = 1;
    public static int sceneTwo = 1;
    public static bool hasHelloCard, hasGoodbyeCard, hasOpenCard, hasYesCard, hasNoCard, hasGoodCard, hasBadCard, canMoveCards, arenaToggle;
    public static Image characterTabletopPanel, blackBGPanel, characterImage, newCardImage, actionHand;
    public static Text newCardText;
    public static Button runAwayButton;
    public static Image playerBGPanel, characterBGPanel;


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
        canvasCode = GameObject.Find("CanvasCode");


        UICanvas = GameObject.Find("UICanvas");
        upArrow = GameObject.Find("Up Arrow");
        rightArrow = GameObject.Find("Right Arrow");
        leftArrow = GameObject.Find("Left Arrow");
        spellbookButtonLeft = GameObject.Find("SpellbookButton Left");
        spellbookButtonRight = GameObject.Find("SpellbookButton Right");
        controlButton = GameObject.Find("ControlButton");
        //  cardMoveToggle = GameObject.Find("CardMoveToggle");
        //  cardPhraseToggle = GameObject.Find("CardPhraseToggle");
        characterTabletopPanel = GameObject.Find("CharacterTabletop").GetComponent<Image>();
        actionHand = GameObject.Find("ActionHand").GetComponent<Image>();
        blackBGPanel = GameObject.Find("BlackBGPanel").GetComponent<Image>();
        characterImage = GameObject.Find("CharacterImage").GetComponent<Image>();
        newCardImage = GameObject.Find("NewCardImage").GetComponent<Image>();
        newCardText = GameObject.Find("NewCardText").GetComponent<Text>();
        actionHandPanel = GameObject.Find("ActionHand");
        doorCard = GameObject.Find("DoorCard");
        doorCard.SetActive(false);
        youCard = GameObject.Find("YouCard");
        youCard.SetActive(false);
        hiCard = GameObject.Find("HiCard");
        hiCard.SetActive(false);
        evaCard = GameObject.Find("EvaCard");
        evaCard.SetActive(false);

        //  HideCardToggles();


        // dictionaryCanvas = GameObject.Find("DictionaryCanvas");
        // dictionaryCanvas.SetActive(false);

        // helloCard = GameObject.Find("HelloButton");
        // goodCard = GameObject.Find("GoodButton");

        //  if (hasGoodCard)
        //      GameControl.goodCard.GetComponent<Button>().interactable = true;

        // badCard = GameObject.Find("BadButton");

        // goodbyeCard = GameObject.Find("GoodbyeButton");
        // openCard = GameObject.Find("OpenButton");
        // yesCard = GameObject.Find("YesButton");

        //   if (hasYesCard)
        //       GameControl.yesCard.GetComponent<Button>().interactable = true;

        // noCard = GameObject.Find("NoButton");
        // readCard = GameObject.Find("ReadButton");
        // // hiCard = GameObject.Find("HiButton");
        // stopCard = GameObject.Find("StopButton");
        // closeCard = GameObject.Find("CloseButton");
        // byeCard = GameObject.Find("ByeButton");
        // thankYouCard = GameObject.Find("ThankYouButton");

        // okCard = GameObject.Find("OKButton");
        // girlCard = GameObject.Find("GirlButton");
        // boyCard = GameObject.Find("BoyButton");
        // sitCard = GameObject.Find("SitButton");
        // morningCard = GameObject.Find("MorningButton");
        // afternoonCard = GameObject.Find("AfternoonButton");
        // eveningCard = GameObject.Find("EveningButton");


        // oneCard = GameObject.Find("1Button");
        // twoCard = GameObject.Find("2Button");
        // threeCard = GameObject.Find("3Button");
        // fourCard = GameObject.Find("4Button");
        // fiveCard = GameObject.Find("5Button");
        // sixCard = GameObject.Find("6Button");
        // sevenCard = GameObject.Find("7Button");
        // eightCard = GameObject.Find("8Button");
        // nineCard = GameObject.Find("9Button");
        // tenCard = GameObject.Find("10Button");
        // elevenCard = GameObject.Find("11Button");
        // twelveCard = GameObject.Find("12Button");
        // thirteenCard = GameObject.Find("13Button");
        // fourteenCard = GameObject.Find("14Button");
        // fifteenCard = GameObject.Find("15Button");
        // sixteenCard = GameObject.Find("16Button");
        // seventeenCard = GameObject.Find("17Button");
        // eighteenCard = GameObject.Find("18Button");
        // nineteenCard = GameObject.Find("19Button");
        // twentyCard = GameObject.Find("20Button");


        // sueCard = GameObject.Find("SueButton");
        // mayCard = GameObject.Find("MayButton");
        // theCard = GameObject.Find("TheButton");
        // sorryCard = GameObject.Find("SorryButton");
        runAwayButton = GameObject.Find("RunAwayButton").GetComponent<Button>();
        playerBGPanel = GameObject.Find("PlayerBGPanel").GetComponent<Image>();
        characterBGPanel = GameObject.Find("CharacterBGPanel").GetComponent<Image>();

        scene = "Academy";
    }

    public static void ArenaToggle()
    {

        if (arenaToggle == false)
        {
            arenaToggle = true;
            runAwayButton.interactable = true;
        }
        else
        {
            arenaToggle = false;
            runAwayButton.interactable = false;
        }

        //  var tempColor1 = blackBGPanel.color;
        //  var tempColor2 = characterImage.color;
        //  var tempColor3 = characterTabletopPanel.color;

        //   if (tempColor3.a == 0f)
        //    {
        //   tempColor1.a = 1f;
        //   tempColor2.a = 1f;
        //      tempColor3.a = 0.4f;
        //   }
        //   else
        //   {
        //  tempColor1.a = 0f;
        //  tempColor2.a = 0f;
        //   tempColor3.a = 0f;
        //  }

        //   blackBGPanel.color = tempColor1;
        //  characterImage.color = tempColor2;
        //   characterTabletopPanel.color = tempColor3;

        int count = characterTabletopPanel.transform.childCount;
        if (count > 0)
        {
            foreach (Transform child in characterTabletopPanel.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        Academy.roundNumber = 0;
    }

    public static void RedBG()
    {
        var tempColor = blackBGPanel.color;
        tempColor = Color.red;
        tempColor.a = 0.4f;
        blackBGPanel.color = tempColor;
    }

    public static void BlackBG()
    {
        var tempColor = blackBGPanel.color;
        tempColor = Color.black;
        tempColor.a = 0;
        blackBGPanel.color = tempColor;
    }

    public static void DestroyCharacterCards()
    {
        int count = characterTabletopPanel.transform.childCount;
        if (count > 0)
        {
            foreach (Transform child in characterTabletopPanel.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }
    }

    public static void NewCardOn(Sprite newCard)
    {
        // var tempColor1 = blackBGPanel.color;
        var tempColor2 = newCardText.color;
        var tempColor3 = newCardImage.color;
        //    var tempColor4 = characterImage.color;
        var tempColor5 = characterTabletopPanel.color;
        // tempColor1.a = 1f;
        tempColor2.a = 1f;
        tempColor3.a = 1f;
        //   tempColor4.a = 0f;
        tempColor5.a = 0f;
        //    blackBGPanel.color = tempColor1;
        newCardText.color = tempColor2;
        newCardImage.color = tempColor3;
        //    characterImage.color = tempColor4;
        characterTabletopPanel.color = tempColor5;

        newCardImage.sprite = newCard;
        SoundManager.playCorrectSound();
    }

    public static void NewCardOff()
    {
        var tempColor1 = blackBGPanel.color;
        var tempColor2 = newCardText.color;
        var tempColor3 = newCardImage.color;
        tempColor1.a = 0f;
        tempColor2.a = 0f;
        tempColor3.a = 0f;
        blackBGPanel.color = tempColor1;
        newCardText.color = tempColor2;
        newCardImage.color = tempColor3;
        arenaToggle = false;
        Academy.roundNumber = 0;
    }

    public static void PlayerBGFlash()
    {
        var tempColor = playerBGPanel.color;
        if (tempColor.a == 0f)
            tempColor.a = 0.3f;
        else
            tempColor.a = 0.0f;
        playerBGPanel.color = tempColor;
    }

    public static void CharacterBGFlash()
    {
        var tempColor = characterBGPanel.color;
        if (tempColor.a == 0f)
            tempColor.a = 0.3f;
        else
            tempColor.a = 0.0f;
        characterBGPanel.color = tempColor;
    }


    public static void HideArrows()
    {
        GameControl.upArrow.GetComponent<Button>().interactable = false;
        GameControl.rightArrow.GetComponent<Button>().interactable = false;
        GameControl.leftArrow.GetComponent<Button>().interactable = false;
    }

    public static void ShowArrows()
    {
        GameControl.upArrow.GetComponent<Button>().interactable = true;
        GameControl.rightArrow.GetComponent<Button>().interactable = true;
        GameControl.leftArrow.GetComponent<Button>().interactable = true;
    }
    public static void HideSideArrows()
    {
        GameControl.rightArrow.GetComponent<Button>().interactable = false;
        GameControl.leftArrow.GetComponent<Button>().interactable = false;
    }
    public static void ShowUpArrow()
    {
        GameControl.upArrow.GetComponent<Button>().interactable = true;
    }
    public static void HideUpArrow()
    {
        GameControl.upArrow.GetComponent<Button>().interactable = false;
    }
    public static void ShowSideArrows()
    {
        GameControl.rightArrow.GetComponent<Button>().interactable = true;
        GameControl.leftArrow.GetComponent<Button>().interactable = true;
    }
    public static void HideCardToggles()
    {
        cardMoveToggle.SetActive(false);
        cardPhraseToggle.SetActive(false);
    }
    public static void ShowCardToggles()
    {
        cardMoveToggle.SetActive(true);
        cardPhraseToggle.SetActive(true);
    }

    // public void Dictionary()
    // {
    //     if (dictionaryCanvas.activeSelf)
    //     {
    //         dictionaryCanvas.SetActive(false);
    //         UICanvas.SetActive(true);
    //     }
    //     else if (UICanvas.activeSelf)
    //     {
    //         dictionaryCanvas.SetActive(true);
    //         UICanvas.SetActive(false);
    //     }
    // }
    public static void CanMoveCards()
    {
        canMoveCards = true;
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
            // print(sceneOne);
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

