using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Academy : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    float z = -10;
    float y = 0;
    float x = 0;
    public static string direction;
    public static Text dialogue;
    public static int textNumber, roundNumber;
    bool isRoomsDoorClosed = true, tutorial, tutorial1Complete = false;
    public static GameObject speechPages, actionPages, letterPages, numberPages, mapPage1, frontDoor, LaboratoryDoor, page1, page2, page3, page4, page5, letterPage1, letterPage2, speechTabletop, actionTabletop;
    static SpriteRenderer frontDoorway, roomsDoorway, secretary, secretaryCloseUp;
    static Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed, secretarySprite, secretarySprite01, secretarySprite02, secretarySprite03, fairyInTreeNoFairy, controlSprite01, controlSprite02, controlSprite03, controlSprite04, fairyNeutralSprite, wolfSprite, dinoSprite, doorCardSprite, youCardSprite, student06Sprite, student01Sprite, hiCardSprite, evaCardSprite;
    public static bool helloHold, goodHold, oneHold, twoHold, threeHold, fourHold, fiveHold, sixHold, sevenHold, eightHold, nineHold;
    public Transform helloCard, howCard, areCard, youCard, questionMarkCard, canCard, notCard, passCard, lostCard, goCard, throughCard, theCard, doorCard, hiCard, whatCard, isCard, yourCard, nameCard, iCard, askedCard, fromCard, hereCard, amCard, evaCard, niceCard, toCard, meetCard, willCard, needCard, thisCard;
    static string timeOfDay, playerName;
    int playerAge, playerAge0, playerAge10 = 0, controlNumber = 0;

    //--

    public GameObject teacher, student3, dino;
    public GameObject[] openings, solidObjects;

    public bool canWalkThroughNextWall, canWalkThroughPreviousWall;
    public static bool inInteraction;

    public static GameObject fairy, fairyInTree;
    Animation fairyAnimation;

    public Color black = Color.black;
    public Color night;



    GameControl gameControl;

    void Start()
    {
        roundNumber = 0;

        DateTime time = System.DateTime.Now;
        string dateAndTimeVar = time.ToString("yyyy/MM/dd HH:mm:ss");

        if (time.Hour >= 04 && time.Hour < 12)
            timeOfDay = "morning";
        else if (time.Hour >= 12 && time.Hour < 18)
            timeOfDay = "afternoon";
        else if (time.Hour >= 18 || time.Hour < 4)
            timeOfDay = "evening";

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;

        direction = "north";

        dialogue = GameObject.Find("Text").GetComponent<Text>();
        dialogue.text = "";

        //GameControl.helloCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);

        speechPages = GameObject.Find("SpeechPages");
        actionPages = GameObject.Find("ActionPages");
        letterPages = GameObject.Find("LetterPages");
        numberPages = GameObject.Find("NumberPages");

        speechTabletop = GameObject.Find("SpeechTabletop");
        actionTabletop = GameObject.Find("ActionTabletop");
        letterPage1 = GameObject.Find("LetterPage1");
        letterPage2 = GameObject.Find("LetterPage2");

        //page1 = GameObject.Find("Page1");
        //page2 = GameObject.Find("Page2");
        //page3 = GameObject.Find("Page3");
        //page4 = GameObject.Find("Page4");
        //page5 = GameObject.Find("Page5");
        //   mapPage1 = GameObject.Find("MapPage1");
        frontDoor = GameObject.Find("Front Door");
        LaboratoryDoor = GameObject.Find("LaboratoryDoor");
        secretary = GameObject.Find("Secretary").GetComponent<SpriteRenderer>();
        secretaryCloseUp = GameObject.Find("Secretary Close Up").GetComponent<SpriteRenderer>();
        student3 = GameObject.Find("Student 03");
        dino = GameObject.Find("Dino");

        // // frontDoorway = GameObject.Find("FrontDoor").GetComponent<SpriteRenderer>();
        // frontDoorOpen = Resources.Load<Sprite>("Views/Academy/OutsideAcademyView03b");
        // //roomsDoorway = GameObject.Find("LaboratoryDoor").GetComponent<SpriteRenderer>();
        // roomsDoorOpen = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05b");
        // roomsDoorClosed = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05");
        //   fairyInTreeNoFairy = Resources.Load<Sprite>("Fairy_on_tree-no_Fairy");
        //    fairyInTree = GameObject.FindWithTag("Fairy in tree");
        fairy = GameObject.FindWithTag("Fairy");
        fairy.SetActive(false);

        //   secretary = GameObject.Find("Secretary Close Up").GetComponent<SpriteRenderer>();
        secretarySprite = Resources.Load<Sprite>("Foyer/Secretary");
        secretarySprite01 = Resources.Load<Sprite>("Foyer/Secretary01");
        secretarySprite02 = Resources.Load<Sprite>("Foyer/Secretary02");
        secretarySprite03 = Resources.Load<Sprite>("Foyer/Secretary03");
        fairyNeutralSprite = Resources.Load<Sprite>("Characters/FairyNeutral");
        wolfSprite = Resources.Load<Sprite>("Characters/Wolf");
        dinoSprite = Resources.Load<Sprite>("Characters/Dino");
        // student06Sprite = Resources.Load<Sprite>("Library/Student06_headAndShoulders");
        // student01Sprite = Resources.Load<Sprite>("Library/Student01_headAndShoulders");

        controlSprite01 = Resources.Load<Sprite>("UI/boots-icon");
        controlSprite02 = Resources.Load<Sprite>("UI/speak-icon");
        controlSprite03 = Resources.Load<Sprite>("UI/action-icon");
        controlSprite04 = Resources.Load<Sprite>("UI/map-icon");

        doorCardSprite = Resources.Load<Sprite>("Cards/DoorCard");
        youCardSprite = Resources.Load<Sprite>("Cards/YouCard");
        hiCardSprite = Resources.Load<Sprite>("Cards/HiCard");
        evaCardSprite = Resources.Load<Sprite>("Cards/EvaCard");
        youCardSprite = Resources.Load<Sprite>("Cards/YouCard");
        hiCardSprite = Resources.Load<Sprite>("Cards/HiCard");
        evaCardSprite = Resources.Load<Sprite>("Cards/EvaCard");

        CheckWalk();
    }

    void CheckWalk()
    {
        // -- 
        // Teacher character 

        //  Debug.Log("CheckWalk");
        //   teacher = GameObject.FindGameObjectWithTag("Teacher");

        // walls
        //  openings = GameObject.FindGameObjectsWithTag("CanWalkThrough");
        solidObjects = GameObject.FindGameObjectsWithTag("CantWalkThrough");
        CheckWalls();

        //- move camera also
        //  camera.transform.position = new Vector3(0, 0, 0);
        //  cameraPos = camera.transform.position;


    }
    public void CheckWalls()
    {
        // 2.5D
        //  canWalkThroughNextWall = false;
        //  canWalkThroughPreviousWall = false;

        // 3D
        canWalkThroughNextWall = true;

        for (int i = 0; i < solidObjects.Length; i++)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(solidObjects[i].transform.position);
            // Vector3 rearViewPos = camera.WorldToViewportPoint(openings[i].transform.position) + new Vector3(0, 0, -5.4f);
            // Debug.Log(viewPos);

            //2.5D
            // if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            // {
            //     canWalkThroughNextWall = true;
            // }

            // if (rearViewPos.z < -2.6f && rearViewPos.z > -2.8f && rearViewPos.x > 0.4f && rearViewPos.x < 0.6f)
            // {
            //     canWalkThroughPreviousWall = true;
            // }

            //3D
            if (viewPos.z > 5.3f && viewPos.z < 5.5f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalkThroughNextWall = false;
            }
            else if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalkThroughNextWall = false;
            }
        }
        //Debug.Log(canWalkThroughNextWall);
        // Debug.Log(canWalkThroughPreviousWall);
    }
    public void MoveForward()
    {
        if (GameControl.scene == "Academy")
        {
            if (canWalkThroughNextWall && tutorial == false)
            {
                SoundManager.playFootstepSound();

                student3.GetComponent<Student03>().Move();


                if (direction == "north")
                {
                    cameraPos.z += 5.4f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    cameraPos = camera.transform.position;

                    if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, 0f))
                    {
                        OutdoorsAmbientSound.StopOutdoorAmbientSound();

                        // if (!tutorial1Complete)
                        // {
                        //     controlNumber = 0;
                        //     ControlButton();
                        //     FairyAnimation.Tutorial();
                        //     cameraPos.y += 12f;
                        //     camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                        //     fairy.transform.localPosition = new Vector3(1.5f, 2.4f, 1f);
                        //     fairy.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                        //     SoundManager.playHeySound();
                        //     tutorial = true;
                        // }
                    }
                    if (Mathf.Approximately(cameraPos.z, 17f) && Mathf.Approximately(cameraPos.x, 0f))
                    {
                        controlNumber = 0;
                        ControlButton();
                        cameraPos.y += 12f;
                        camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                        fairy.transform.localPosition = new Vector3(1.4f, 2.2f, 1f);
                        fairy.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                        tutorial = true;
                        dialogue.text = "Introduce yourself to the other students. Try not to sound like a dork.";
                        SoundManager.playFairyTalk05Sound();
                    }
                    else if (Mathf.Approximately(cameraPos.z, -4.6f) && Mathf.Approximately(cameraPos.x, 0f) && fairy.activeSelf == false)
                    {
                        SoundManager.playHeySound();
                    }
                    // Student 2 interaction -----------
                    else if (Mathf.Approximately(cameraPos.z, 21.6f) && Mathf.Approximately(cameraPos.x, 5.4f))
                    {
                        Student06();
                    }
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

                    // Dino interaction ----------------
                    if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f))
                    {
                        Dino();
                    }
                }
            }

            else if (cameraPos.z == -10.8f && direction == "east")
            {
                SoundManager.playWolfGrowlSound();
            }
            else
                SoundManager.playBumpSound();

            CheckWalls();
        }
    }

    public void LeftButton()
    {

        if (controlNumber == 1 || controlNumber == 2)
        {
            SpellbookButtonLeft();
        }
        else if (controlNumber == 0)
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

            CheckWalls();
        }

    }
    public void RightButton()
    {

        if (controlNumber == 1 || controlNumber == 2)
        {
            SpellbookButtonRight();
        }
        else if (controlNumber == 0)
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

            CheckWalls();
        }

    }

    public void ControlButton()
    {
        // if (cameraPos.y == 2)
        if (GameControl.arenaToggle == false)
        {
            controlNumber++;
            if (controlNumber > 2)
                controlNumber = 0;

            switch (controlNumber)
            {
                case 0:
                    GameControl.controlButton.GetComponent<Image>().sprite = controlSprite01;
                    break;
                case 1:
                    GameControl.controlButton.GetComponent<Image>().sprite = controlSprite02;
                    break;
                case 2:
                    GameControl.controlButton.GetComponent<Image>().sprite = controlSprite03;
                    break;
            }

            if (controlNumber == 1)
            {
                GameControl.HideArrows();
                //   GameControl.ShowCardToggles();
                //  fairy.transform.localPosition = new Vector3(-0.47f, 0.4f, 1f);
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, 0f, 0f);
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, -500f, 0f);
            }
            if (controlNumber == 2)
            {
                GameControl.HideArrows();
                //  GameControl.HideCardToggles();
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, 0f, 0f);
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, -550f, 0f);
            }
            if (controlNumber == 0)
            {
                GameControl.ShowArrows();

                //   fairy.transform.localPosition = new Vector3(-1f, 0.4f, 1f);
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, -550f, 0f);
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, -1000f, 0f);
            }
        }
        else
        {
            controlNumber++;
            if (controlNumber > 2)
                controlNumber = 1;

            switch (controlNumber)
            {
                case 1:
                    GameControl.controlButton.GetComponent<Image>().sprite = controlSprite02;
                    break;
                case 2:
                    GameControl.controlButton.GetComponent<Image>().sprite = controlSprite03;
                    break;
            }

            if (controlNumber == 1)
            {
                GameControl.HideArrows();
                //   mapPage1.transform.localPosition = new Vector3(0f, -500f, 0f);
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, 0f, 0f);
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, -500f, 0f);
            }
            if (controlNumber == 2)
            {
                GameControl.HideArrows();
                //   mapPage1.transform.localPosition = new Vector3(0f, -500f, 0f);
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, 0f, 0f);
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, -550f, 0f);
            }
        }
    }


    public void SpellbookButtonRight()
    {
        SoundManager.playPageTurnSound();
        letterPage1.transform.localPosition = new Vector3(-540f, 0f, 0f);
        letterPage2.transform.localPosition = new Vector3(0f, 0f, 0f);
        // page3.transform.localPosition = new Vector3(-540f, 0f, 0f) + page3.transform.localPosition;
        // page4.transform.localPosition = new Vector3(-540f, 0f, 0f) + page4.transform.localPosition;
    }

    public void SpellbookButtonLeft()
    {
        SoundManager.playPageTurnSound();
        letterPage1.transform.localPosition = new Vector3(0f, 0f, 0f);
        letterPage2.transform.localPosition = new Vector3(540f, 0f, 0f);
        // page1.transform.localPosition = new Vector3(540f, 0f, 0f) + page1.transform.localPosition;
        // page2.transform.localPosition = new Vector3(540f, 0f, 0f) + page2.transform.localPosition;
        // page3.transform.localPosition = new Vector3(540f, 0f, 0f) + page3.transform.localPosition;
        // page4.transform.localPosition = new Vector3(540f, 0f, 0f) + page4.transform.localPosition;
    }

    public void ShowLetterCards()
    {
        letterPages.transform.localPosition = new Vector3(0f, 0f, 0f);
        speechPages.transform.localPosition = new Vector3(0f, -500f, 0f);
        actionPages.transform.localPosition = new Vector3(0f, -1000f, 0f);
    }

    public void ShowNumberCards()
    {
        numberPages.transform.localPosition = new Vector3(0f, 0f, 0f);
        speechPages.transform.localPosition = new Vector3(0f, -500f, 0f);
        actionPages.transform.localPosition = new Vector3(0f, -1000f, 0f);
        letterPages.transform.localPosition = new Vector3(0f, -1500f, 0f);
    }

    public void ShowRegularCards()
    {
        speechPages.transform.localPosition = new Vector3(0f, 0f, 0f);
        actionPages.transform.localPosition = new Vector3(0f, -500f, 0f);
        letterPages.transform.localPosition = new Vector3(0f, -1000f, 0f);
        numberPages.transform.localPosition = new Vector3(0f, -1500f, 0f);
    }

    public void Go()
    {
        int speechTableTopCount = speechTabletop.transform.childCount;
        int actionTableTopCount = actionTabletop.transform.childCount;
        // print(actionTableTopCount);
        // print(roundNumber);
        // for (int i = 0; i < actionTableTopCount; i++)
        // {
        //     Transform child = actionTabletop.transform.GetChild(i);
        //     print(child.gameObject.name);
        // }

        //Fairy interaction -------------------------------
        if (cameraPos.z == -5.4f && cameraPos.x == 0f && direction == "north")
        {
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0)
            {
                GameControl.ArenaToggle();
                roundNumber++;
                StartCoroutine((FairyCoroutine01()));
            }
            else if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "YesCard" && roundNumber == 1)
            {
                roundNumber++;
                GameControl.DestroyCharacterCards();
                StartCoroutine((FairyCoroutine02()));
            }
            else if (roundNumber == 2 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "ThankyouCard" || roundNumber == 2 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "OKCard" || roundNumber == 2 && speechTableTopCount == 2 && speechTabletop.transform.GetChild(0).gameObject.name == "OKCard" && speechTabletop.transform.GetChild(1).gameObject.name == "ThankyouCard")
            {
                roundNumber++;
                GameControl.DestroyCharacterCards();
                StartCoroutine((FairyCoroutine03()));
                // GameControl.NewCardOn(doorCardSprite);
                //  GameControl.doorCard.SetActive(true);
                inInteraction = false;
                GameControl.runAwayButton.interactable = false;
                GameControl.ArenaToggle();
            }
            else if (roundNumber == 3)
            {
                GameControl.NewCardOff();
            }
        }

        // Wolf interactions -------------------------------
        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f) && direction == "east")
        {
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0)
            {
                StartCoroutine((WolfCoroutine01()));
                GameControl.ArenaToggle();
                roundNumber++;
                SoundManager.playHelloSound();
            }
            else
            {
                roundNumber++;
                StartCoroutine((WolfCoroutine02()));
            }
        }

        //door interaction ----------------------------------
        else if (cameraPos.z == 0f && cameraPos.x == 0f && direction == "north")
        {
            if (actionTableTopCount == 2 && actionTabletop.transform.GetChild(0).gameObject.name == "OpenCard" && actionTabletop.transform.GetChild(1).gameObject.name == "DoorCard" && roundNumber == 0)
            {
                //   Debug.Log("test");
                OpenFrontDoor();
            }
        }

        //Secretary interaction -------------------------------------
        else if (cameraPos.z == 5.4f && cameraPos.x == -5.4f && direction == "west")
        {
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0)
            {
                GameControl.ArenaToggle();
                roundNumber++;
                GameControl.characterImage.sprite = secretarySprite01;
                GameControl.characterImage.rectTransform.sizeDelta = new Vector2(300, 700);
                SoundManager.playSecretaryTalk01ASound();
            }
        }

        //Dino interaction .........................
        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f) && direction == "west")
        {
            print(roundNumber);
            print("roundNumber");
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "EvaCard")
            {
                GameControl.ArenaToggle();
                roundNumber++;
                StartCoroutine((DinoCoroutine04()));
            }
            else if (roundNumber == 0)
            {
                roundNumber++;
                GameControl.DestroyCharacterCards();
                StartCoroutine((DinoCoroutine02()));
            }
            else if (roundNumber == 1)
            {
                roundNumber++;
                GameControl.DestroyCharacterCards();
                StartCoroutine((DinoCoroutine03()));
            }
            else if (roundNumber == 2)
            {
                SceneManager.LoadScene("GameOver");
                gameControl = FindObjectOfType<GameControl>();
                Destroy(gameControl.gameObject);
            }
        }

        //Student 1 interaction .........................
        else if (cameraPos.z == 16.2f && cameraPos.x == 5.4f && direction == "east")
        {
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0)
            {
                GameControl.ArenaToggle();
                roundNumber++;
                StartCoroutine((Student01Coroutine01()));
            }
            else if (roundNumber == 2)
            {
                GameControl.NewCardOff();
            }
            else
            {
                GameControl.DestroyCharacterCards();
                StartCoroutine((Student01Coroutine02()));
            }
        }

        //Student 2 interaction .........................
        else if (cameraPos.z == 21.6f && cameraPos.x == -5.4f && direction == "north")
        {
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0 || speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HiCard" && roundNumber == 0)
            {
                GameControl.ArenaToggle();
                roundNumber++;
                StartCoroutine((Student02Coroutine01()));
            }
        }

        //Student 6 interaction .........................
        else if (cameraPos.z == 21.6f && cameraPos.x == 5.4f && direction == "north")
        {
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0 || speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HiCard" && roundNumber == 0)
            {

                roundNumber++;
                GameControl.DestroyCharacterCards();
                StartCoroutine((Student06Coroutine02()));
            }
            else if (roundNumber == 2)
            {
                GameControl.NewCardOff();
            }
            else
            {
                GameControl.DestroyCharacterCards();
                StartCoroutine((Student06Coroutine03()));
            }
        }
    }


    public void RunAway()
    {
        if (cameraPos.z == 16.2f && cameraPos.x == 5.4f && direction == "east")
        {
            // if (roundNumber == 1)
            // {
            //     roundNumber++;
            //     GameControl.DestroyCharacterCards();
            //     GameControl.NewCardOn(hiCardSprite);
            //     GameControl.hiCard.SetActive(true);
            //     GameControl.runAwayButton.interactable = false;
            // }
            if (roundNumber == 1)
            {
                GameControl.NewCardOff();
            }
        }
        else if (cameraPos.z == 21.6f && cameraPos.x == 5.4f && direction == "north")
        {
            if (roundNumber == 1)
            {
                roundNumber++;
                GameControl.DestroyCharacterCards();
                GameControl.NewCardOn(evaCardSprite);
                GameControl.evaCard.SetActive(true);
                GameControl.runAwayButton.interactable = false;
            }
            else if (roundNumber == 2)
            {
                GameControl.NewCardOff();
            }
        }
        else
        {
            GameControl.ArenaToggle();
            ArenaSound.StopArenaSound();
            MainMusicSound.PlayMainMusicSound();
            roundNumber = 0;
        }
        GameControl.BlackBG();
    }


    IEnumerator FairyCoroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playFairyTalk06Sound();

        var characterHelloCard = Instantiate(helloCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterAreCard = Instantiate(areCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterYouCard = Instantiate(youCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterLostCard = Instantiate(lostCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterQuestionMarkCard = Instantiate(questionMarkCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHelloCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterAreCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterYouCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterLostCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterQuestionMarkCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    IEnumerator FairyCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playFairyTalk07Sound();
        var characterGoCard = Instantiate(goCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterThroughCard = Instantiate(throughCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterTheCard = Instantiate(theCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterDoorCard = Instantiate(doorCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterGoCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterThroughCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterTheCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterDoorCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    IEnumerator FairyCoroutine03()
    {
        yield return new WaitForSeconds(1.5f);
        var characterYouCard = Instantiate(youCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterWillCard = Instantiate(willCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterNeedCard = Instantiate(needCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterThisCard = Instantiate(thisCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterYouCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterWillCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterNeedCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterThisCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);

        ControlButton();

        var characterDoorCard = Instantiate(doorCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterDoorCard.transform.SetParent(GameControl.actionTabletopPanel.transform, false);
        characterDoorCard.gameObject.AddComponent<Draggable>();
        SoundManager.playSound(SoundManager.fairyTalk08);
    }
    IEnumerator WolfCoroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWolfHelloSound();
        var characterHelloCard = Instantiate(helloCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHelloCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);

        yield return new WaitForSeconds(1.5f);
        fairy.SetActive(true);
        dialogue.text = "You can choose a card.";
        FairyAnimation.CorrectAnswer();
        characterHelloCard.gameObject.AddComponent<Draggable>();
    }
    IEnumerator WolfCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWolfGrowlSound();

        //yield return new WaitForSeconds(1.5f);
        fairy.SetActive(true);
        dialogue.text = "You lose a card.";
        FairyAnimation.IncorrectAnswer();
        GameControl.noCard.SetActive(false);
    }
    IEnumerator Student01Coroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playStudent01HiSound();
        var characterHiCard = Instantiate(hiCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHiCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);

        yield return new WaitForSeconds(1.5f);
        fairy.SetActive(true);
        dialogue.text = "You can choose a card.";
        FairyAnimation.CorrectAnswer();
        characterHiCard.gameObject.AddComponent<Draggable>();
        //    GameObject hiCardClone = GameObject.Find("hiCard(Clone)");
        // hiCardClone.transform.SetParent(GameControl.speechTabletopPanel.transform, false);

    }
    IEnumerator Student01Coroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playStudent01HuhSound();
    }
    IEnumerator Student06Coroutine01()
    {
        yield return new WaitForSeconds(0.7f);
        SoundManager.playStudent06Talk01Sound();
        var characterHiCard = Instantiate(hiCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterICard = Instantiate(iCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterAmCard = Instantiate(amCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterEvaCard = Instantiate(evaCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHiCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterICard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterAmCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterEvaCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    IEnumerator Student06Coroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playStudent06Talk02Sound();
        var characterWhatCard = Instantiate(whatCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterIsCard = Instantiate(isCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterYourCard = Instantiate(yourCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterNameCard = Instantiate(nameCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterQuestionMarkCard = Instantiate(questionMarkCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterWhatCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterIsCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterYourCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterNameCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterQuestionMarkCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    IEnumerator Student06Coroutine03()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playStudent06HuhSound();
    }

    IEnumerator Student02Coroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playStudent02HiSound();
        var characterHiCard = Instantiate(hiCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHiCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        StartCoroutine((Student02Coroutine02()));
    }
    IEnumerator Student02Coroutine02()
    {
        yield return new WaitForSeconds(1.5f);

        var characterHowCard = Instantiate(howCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterAreCard = Instantiate(areCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterYouCard = Instantiate(youCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterQuestionMarkCard = Instantiate(questionMarkCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHowCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterAreCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterYouCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterQuestionMarkCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }

    IEnumerator DinoCoroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.dinoTalk01);
        GameControl.characterTabletopPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 220);
        var characterHiCard = Instantiate(hiCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterWhatCard = Instantiate(whatCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterIsCard = Instantiate(isCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterYourCard = Instantiate(yourCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterName = Instantiate(nameCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterQuestionMark = Instantiate(questionMarkCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHiCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterWhatCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterIsCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterYourCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterName.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterQuestionMark.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    IEnumerator DinoCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.dinoTalk02);
        GameControl.characterTabletopPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 220);
        var characterICard = Instantiate(iCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterAskedCard = Instantiate(askedCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterWhatCard = Instantiate(whatCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterYourCard = Instantiate(yourCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterNameCard = Instantiate(nameCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterIsCard = Instantiate(isCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterICard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterAskedCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterWhatCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterYourCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterNameCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterIsCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    IEnumerator DinoCoroutine03()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.dinoTalk03);
        GameControl.characterTabletopPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(540, 110);
        GameControl.RedBG();
        var characterYouCard = Instantiate(youCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterAreCard = Instantiate(areCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterNotCard = Instantiate(notCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterFromCard = Instantiate(fromCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterHereCard = Instantiate(hereCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterYouCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterAreCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterNotCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterFromCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterHereCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    IEnumerator DinoCoroutine04()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.dinoTalk04);
        var characterHiCard = Instantiate(hiCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterEvaCard = Instantiate(evaCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterHiCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterEvaCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        ArenaSound.StopArenaSound();
        MainMusicSound.PlayMainMusicSound();
        StartCoroutine((DinoCoroutine05()));
    }
    IEnumerator DinoCoroutine05()
    {
        yield return new WaitForSeconds(1.5f);
        GameControl.DestroyCharacterCards();
        SoundManager.playSound(SoundManager.dinoTalk05);
        var characterNiceCard = Instantiate(niceCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterToCard = Instantiate(toCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterMeetCard = Instantiate(meetCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterYouCard = Instantiate(youCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterNiceCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterToCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterMeetCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterYouCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        yield return new WaitForSeconds(1.5f);
        GameControl.DestroyCharacterCards();
        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);
        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);
        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);
        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);
        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);
        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);
        dino.GetComponent<Dino>().Move();
    }
    public void OpenFrontDoor()
    {
        frontDoor.transform.Rotate(0, 90f, 0, Space.World);
        frontDoor.transform.localPosition = new Vector3(-0.95f, 0.2079014f, 0.3f);
        frontDoor.tag = "Untagged";
        CheckWalls();
        SoundManager.playDoorOpeningSound();
    }

    public void Dino()
    {
        ControlButton();
        GameControl.ArenaToggle();
        MainMusicSound.StopMainMusicSound();
        ArenaSound.StartArenaSound();
        StartCoroutine((DinoCoroutine01()));
    }

    public void Student06()
    {
        ControlButton();
        GameControl.ArenaToggle();
        StartCoroutine((Student06Coroutine01()));
    }
}