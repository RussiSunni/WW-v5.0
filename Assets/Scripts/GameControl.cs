using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public static GameObject goodbyeCard, readCard, stopCard, byeCard, sueCard, mayCard, sorryCard, goodCard, badCard, girlCard, boyCard, sitCard;
    //public static GameObject oneCard, twoCard, threeCard, fourCard, fiveCard, sixCard, sevenCard, eightCard, nineCard, tenCard, elevenCard, twelveCard, thirteenCard, fourteenCard, fifteenCard, sixteenCard, seventeenCard, eighteenCard, nineteenCard, twentyCard;
    public static GameObject upArrow, rightArrow, leftArrow, controlButton, actionHandPanel, canvasCode;
    public static GameObject UICanvas, speechTabletop, actionTabletop, cardTabletop, controls, letterTabletop;
    public static string playerName;
    public static int playerAge;
    public static bool arenaToggle;
    public static Image characterTabletopPanel, blackBGPanel, characterImage, newCardImage, speechHand, actionHand, actionTabletopPanel, speechTabletopPanel, characterHand, wordHandPanel, wordTabletopPanel, letterHandPanel;
    public static Text newCardText;
    public static Button runAwayButton;
    public static Image playerBGPanel, characterBGPanel, arenaPanel;
    public Transform helloCard, okCard, noCard, yesCard, thankyouCard, howCard, areCard, youCard, questionMarkCard, canCard, notCard, passCard, lostCard, goCard, throughCard, theCard, doorCard, hiCard, whatCard, isCard, yourCard, nameCard, iCard, askedCard, fromCard, hereCard, amCard, evaCard, niceCard, toCard, meetCard, willCard, needCard, thisCard, openCard, newCard, haveCard, funCard, closeCard, pleaseCard, fairyCard;
    public static Sprite questionMarkCardSprite, areCardSprite, youCardSprite, lostCardSprite, hiCardSprite, helloCardSprite, goCardSprite, throughCardSprite, theCardSprite, doorCardSprite, willCardSprite, needCardSprite, thisCardSprite, okCardSprite, iCardSprite, amCardSprite, evaCardSprite, whatCardSprite, isCardSprite, yourCardSprite, nameCardSprite, cardBackSprite, newCardSprite, hereCardSprite, haveCardSprite, funCardSprite, niceCardSprite, toCardSprite, meetCardSprite, askedCardSprite, notCardSprite, fromCardSprite, pleaseCardSprite, openCardSprite, fairyCardSprite, closeCardSprite;
  //  public static Sprite spanishHelloCardSprite, spanishAreYouCardSprite, spanishLostCardSprite, spanishQuestionMarkCardSprite, spanishTheCardSprite, spanishDoorCardSprite, spanishGoThroughCardSprite, ;
    public static DropZone tabletopScript;
    public static bool cont = false;
    int controlNumber = 0;
    public Sprite controlSprite00, controlSprite01, controlSprite02;
    public static string direction;
    Camera camera;
    public static Vector3 cameraPos;
    private Scene scene;
    public Image controlButtonImage, helloSpellButton;


    public GameObject wordUI, arrows, gameMenuPanel, wordPanel, movementPanel;

    void Awake()
    {
        // if (control == null)
        // {
        //     DontDestroyOnLoad(gameObject);
        //     control = this;
        // }
        // else if (control != this)
        // {
        //     Destroy(gameObject);
        // }
    }

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
        direction = "north";
        scene = SceneManager.GetActiveScene();

        Load();
        canvasCode = GameObject.Find("AcademyCode");

        UICanvas = GameObject.Find("UICanvas");
        upArrow = GameObject.Find("Up Arrow");
        rightArrow = GameObject.Find("Right Arrow");
        leftArrow = GameObject.Find("Left Arrow");
        controlButton = GameObject.Find("ControlButton");
        if (scene.name == "Academy")
        {
            // arenaPanel = GameObject.Find("Arena").GetComponent<Image>();
         //   characterTabletopPanel = GameObject.Find("CharacterTabletop").GetComponent<Image>();
         //   characterHand = GameObject.Find("CharacterHand").GetComponent<Image>();
         //   wordTabletopPanel = GameObject.Find("WordTabletop").GetComponent<Image>();
            //   actionHand = GameObject.Find("ActionHand").GetComponent<Image>();
            //   speechHand = GameObject.Find("SpeechHand").GetComponent<Image>();
        //    wordHandPanel = GameObject.Find("WordHand").GetComponent<Image>();
         //   letterHandPanel = GameObject.Find("LetterHand").GetComponent<Image>();
            //  speechTabletop = GameObject.Find("SpeechTabletop");
            //  actionTabletop = GameObject.Find("ActionTabletop");
         //   cardTabletop = GameObject.Find("WordTabletop");
            //  actionTabletopPanel = GameObject.Find("ActionTabletop").GetComponent<Image>();
            //   speechTabletopPanel = GameObject.Find("SpeechTabletop").GetComponent<Image>();
            //   speechTabletopScript = speechTabletop.GetComponent<DropZone>();
            //   actionTabletopScript = actionTabletop.GetComponent<DropZone>();
         //   tabletopScript = cardTabletop.GetComponent<DropZone>();
        }

    //    controls = GameObject.Find("Controls");
     //   letterTabletop = GameObject.Find("LetterTabletop");

        //  blackBGPanel = GameObject.Find("BlackBGPanel").GetComponent<Image>();     

        // runAwayButton = GameObject.Find("RunAwayButton").GetComponent<Button>();
        //  playerBGPanel = GameObject.Find("PlayerBGPanel").GetComponent<Image>();
        // characterBGPanel = GameObject.Find("CharacterBGPanel").GetComponent<Image>();


        cardBackSprite = Resources.Load<Sprite>("Cards/CardBack");
        hiCardSprite = Resources.Load<Sprite>("Cards/HiCard");
        helloCardSprite = Resources.Load<Sprite>("Cards/HelloCard");
        areCardSprite = Resources.Load<Sprite>("Cards/AreCard");
        youCardSprite = Resources.Load<Sprite>("Cards/YouCard");
        lostCardSprite = Resources.Load<Sprite>("Cards/LostCard");
        goCardSprite = Resources.Load<Sprite>("Cards/GoCard");
        throughCardSprite = Resources.Load<Sprite>("Cards/ThroughCard");
        theCardSprite = Resources.Load<Sprite>("Cards/TheCard");
        doorCardSprite = Resources.Load<Sprite>("Cards/DoorCard");
        needCardSprite = Resources.Load<Sprite>("Cards/NeedCard");
        willCardSprite = Resources.Load<Sprite>("Cards/WillCard");
        thisCardSprite = Resources.Load<Sprite>("Cards/ThisCard");
        okCardSprite = Resources.Load<Sprite>("Cards/OKCard");
        questionMarkCardSprite = Resources.Load<Sprite>("Cards/QuestionMarkCard");
        iCardSprite = Resources.Load<Sprite>("Cards/ICard");
        amCardSprite = Resources.Load<Sprite>("Cards/AmCard");
        evaCardSprite = Resources.Load<Sprite>("Cards/EvaCard");
        whatCardSprite = Resources.Load<Sprite>("Cards/WhatCard");
        isCardSprite = Resources.Load<Sprite>("Cards/IsCard");
        yourCardSprite = Resources.Load<Sprite>("Cards/YourCard");
        nameCardSprite = Resources.Load<Sprite>("Cards/NameCard");
        newCardSprite = Resources.Load<Sprite>("Cards/NewCard");
        hereCardSprite = Resources.Load<Sprite>("Cards/HereCard");
        haveCardSprite = Resources.Load<Sprite>("Cards/HaveCard");
        funCardSprite = Resources.Load<Sprite>("Cards/FunCard");
        niceCardSprite = Resources.Load<Sprite>("Cards/NiceCard");
        toCardSprite = Resources.Load<Sprite>("Cards/ToCard");
        meetCardSprite = Resources.Load<Sprite>("Cards/MeetCard");
        askedCardSprite = Resources.Load<Sprite>("Cards/AskedCard");
        notCardSprite = Resources.Load<Sprite>("Cards/NotCard");
        fromCardSprite = Resources.Load<Sprite>("Cards/FromCard");
        closeCardSprite = Resources.Load<Sprite>("Cards/CloseCard");
        pleaseCardSprite = Resources.Load<Sprite>("Cards/PleaseCard");
        openCardSprite = Resources.Load<Sprite>("Cards/OpenCard");
        fairyCardSprite = Resources.Load<Sprite>("Cards/FairyCard");


        //spanishHelloCardSprite = Resources.Load<Sprite>("Cards/Spanish Cards/Spanish-Hello");
        //spanishAreYouCardSprite = Resources.Load<Sprite>("Cards/Spanish Cards/Spanish-AreYou");
        //spanishLostCardSprite = Resources.Load<Sprite>("Cards/Spanish Cards/Spanish-Lost");
        //spanishQuestionMarkCardSprite = Resources.Load<Sprite>("Cards/Spanish Cards/Spanish-¿");
        //spanishTheCardSprite = Resources.Load<Sprite>("Cards/Spanish Cards/Spanish-The");
        //spanishDoorCardSprite = Resources.Load<Sprite>("Cards/Spanish Cards/Spanish-Door");
        //spanishGoThroughCardSprite = Resources.Load<Sprite>("Cards/Spanish Cards/Spanish-GoThrough");

    }

    public void ControlButton()
    {
        controlNumber++;
        if (controlNumber > 1)
            controlNumber = 0;

        switch (controlNumber)
        {
            case 0:
                movementPanel.GetComponent<CanvasGroup>().interactable = true;
                movementPanel.GetComponent<CanvasGroup>().alpha = 1f;
                movementPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                wordPanel.GetComponent<CanvasGroup>().interactable = false;
                wordPanel.GetComponent<CanvasGroup>().alpha = 0f;
                wordPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
                break;    

            case 1:
                movementPanel.GetComponent<CanvasGroup>().interactable = false;
                movementPanel.GetComponent<CanvasGroup>().alpha = 0f;
                movementPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
                wordPanel.GetComponent<CanvasGroup>().interactable = true;
                wordPanel.GetComponent<CanvasGroup>().alpha = 1f;
                wordPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                break;
        }
    }

    public void GameMenuButton()
    {
        if (gameMenuPanel.GetComponent<CanvasGroup>().interactable == false)
        {
            gameMenuPanel.GetComponent<CanvasGroup>().interactable = true;
            gameMenuPanel.GetComponent<CanvasGroup>().alpha = 1f;
            gameMenuPanel.transform.SetSiblingIndex(6);
        }
        else
        {
            gameMenuPanel.GetComponent<CanvasGroup>().interactable = false;
            gameMenuPanel.GetComponent<CanvasGroup>().alpha = 0f;
            gameMenuPanel.transform.SetSiblingIndex(0);
        }
    }
    
   
    public void MoveForward()
    {
        //  if (canWalkThroughNextWall == true)
        //  {   

        SoundManager.playFootstepSound();

        if (direction == "north")
        {
            cameraPos.z += 5.4f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            cameraPos = camera.transform.position;

        }
        else if (direction == "south")
        {
            cameraPos.z += -5.4f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            cameraPos = camera.transform.position;
        }
        else if (direction == "east")
        {
            cameraPos.x += 5.4f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            cameraPos = camera.transform.position;

        }
        else if (direction == "west")
        {
            cameraPos.x += -5.4f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            cameraPos = camera.transform.position;
        }
        // }    

        // CheckWalls();

    }
    public void LeftButton()
    {

        if (direction == "north")
        {
            direction = "west";
        }
        else if (direction == "west")
        {
            direction = "south";
        }
        else if (direction == "south")
        {
            direction = "east";
        }
        else if (direction == "east")
        {
            direction = "north";
        }

        camera.transform.Rotate(0, -90, 0);

        //  CheckWalls();

    }
    public void RightButton()
    {

        if (direction == "north")
        {
            direction = "east";
        }
        else if (direction == "east")
        {
            direction = "south";
        }
        else if (direction == "south")
        {
            direction = "west";
        }
        else if (direction == "west")
        {
            direction = "north";
        }
        camera.transform.Rotate(0, 90, 0);

        // CheckWalls();

    }

    public static void RedBG()
    {
        //  var tempColor = blackBGPanel.color;
        // tempColor = Color.red;
        // tempColor.a = 0.4f;
        // blackBGPanel.color = tempColor;
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

    public static void Restart()
    {
        Destroy(control);
    }

    public static void Save()
    {
        Debug.Log("saving");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.playerName = playerName;
        data.playerAge = playerAge;
        //   data.sceneOne = sceneOne;
        //data.sceneTwo = sceneTwo;

        //  data.hasGoodCard = hasGoodCard;
        //  data.hasYesCard = hasYesCard;

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
            //   hasGoodCard = data.hasGoodCard;
            //    hasYesCard = data.hasYesCard;
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

