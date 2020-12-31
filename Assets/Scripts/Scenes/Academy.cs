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
    public static int roundNumber;
    public static GameObject speechPages, actionPages, letterPages, numberPages, frontDoor, letterPage1, letterPage2, speechTabletop, actionTabletop;
    static SpriteRenderer secretary, secretaryCloseUp;
    static Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed, secretarySprite, secretarySprite01, secretarySprite02, secretarySprite03, fairyInTreeNoFairy, controlSprite01, controlSprite02, controlSprite03, controlSprite04, fairyNeutralSprite, wolfSprite, dinoSprite, doorCardSprite, youCardSprite, student06Sprite, student01Sprite, hiCardSprite, evaCardSprite;
    public Transform helloCard, howCard, areCard, youCard, questionMarkCard, canCard, notCard, passCard, lostCard, goCard, throughCard, theCard, doorCard, hiCard, whatCard, isCard, yourCard, nameCard, iCard, askedCard, fromCard, hereCard, amCard, evaCard, niceCard, toCard, meetCard, willCard, needCard, thisCard, lookingCard, forCard, myCard, houndCard;
    static string timeOfDay, playerName;
    int controlNumber = 0;
    public GameObject student3, dino;
    public GameObject[] solidObjects;

    public bool canWalkThroughNextWall;
    public static bool inInteraction;

    public static GameObject fairy, fairyInTree;
    Animation fairyAnimation;
    GameControl gameControl;

    public static List<Transform> characterCards = new List<Transform>();

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

        speechPages = GameObject.Find("SpeechPages");
        actionPages = GameObject.Find("ActionPages");
        // letterPages = GameObject.Find("LetterPages");
        // numberPages = GameObject.Find("NumberPages");

        speechTabletop = GameObject.Find("SpeechTabletop");
        actionTabletop = GameObject.Find("ActionTabletop");
        // letterPage1 = GameObject.Find("LetterPage1");
        // letterPage2 = GameObject.Find("LetterPage2");

        frontDoor = GameObject.Find("Front Door");
        //  secretary = GameObject.Find("Secretary").GetComponent<SpriteRenderer>();
        // secretaryCloseUp = GameObject.Find("Secretary Close Up").GetComponent<SpriteRenderer>();
        student3 = GameObject.Find("Student 03");
        dino = GameObject.Find("Dino");

        fairy = GameObject.FindWithTag("Fairy");
        fairy.SetActive(false);


        secretarySprite = Resources.Load<Sprite>("Foyer/Secretary");
        secretarySprite01 = Resources.Load<Sprite>("Foyer/Secretary01");
        secretarySprite02 = Resources.Load<Sprite>("Foyer/Secretary02");
        secretarySprite03 = Resources.Load<Sprite>("Foyer/Secretary03");


        controlSprite01 = Resources.Load<Sprite>("UI/boots-icon");
        controlSprite02 = Resources.Load<Sprite>("UI/speak-icon");
        controlSprite03 = Resources.Load<Sprite>("UI/action-icon");
        controlSprite04 = Resources.Load<Sprite>("UI/map-icon");

        CheckWalk();
    }

    void CheckWalk()
    {
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

        // 3D
        canWalkThroughNextWall = true;

        for (int i = 0; i < solidObjects.Length; i++)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(solidObjects[i].transform.position);
            // Vector3 rearViewPos = camera.WorldToViewportPoint(openings[i].transform.position) + new Vector3(0, 0, -5.4f);
            //  Debug.Log(viewPos);

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
        if (canWalkThroughNextWall == true)
        {
            SoundManager.playFootstepSound();
            //student3.GetComponent<Student03>().Move();

            if (direction == "north")
            {
                cameraPos.z += 5.4f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                cameraPos = camera.transform.position;


                //Fairy --------------------
                if (Mathf.Approximately(cameraPos.z, -5.4f) && Mathf.Approximately(cameraPos.x, 0f))
                {
                    SoundManager.playHeySound();
                    for (int i = 0; i < Fairy.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Fairy.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
                else if (Mathf.Approximately(cameraPos.z, 0f) && Mathf.Approximately(cameraPos.x, 0f))
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }

                //Student06 --------------------
                if (Mathf.Approximately(cameraPos.z, 21.6f) && Mathf.Approximately(cameraPos.x, 5.4f))
                {
                    roundNumber = 0;
                    for (int i = 0; i < Fairy.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Fairy.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }

                    StartCoroutine((Student06Coroutine01()));
                }

                // Fairy
                else if (Mathf.Approximately(cameraPos.z, 0f) && Mathf.Approximately(cameraPos.x, 0f))
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }


                // Go inside
                else if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, 0f))
                {
                    OutdoorsAmbientSound.StopOutdoorAmbientSound();
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

                // Wolf -----------------------
                if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f))
                {
                    // SoundManager.playWordSound(SoundManager.interactionMusic);
                    for (int i = 0; i < Wolf.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Wolf.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }

                //Student 1 -----------------------
                // if (cameraPos.z == 16.2f && cameraPos.x == 5.4f && direction == "east")
                // {
                //     for (int i = 0; i < Student01.cards.Count; ++i)
                //     {
                //         characterCards.Add(Instantiate(Student01.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                //         characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                //         characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                //     }
                // }
            }
            else if (direction == "west")
            {
                cameraPos.x += -5.4f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                cameraPos = camera.transform.position;

                // Dino interaction ----------------
                // if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f))
                // {
                //     Dino();
                // }
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


            // Wolf -----------------------
            if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction != "east")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Wolf.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Wolf.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Fairy --------------------
            if (Mathf.Approximately(cameraPos.z, -5.4f) && Mathf.Approximately(cameraPos.x, 0f))
            {
                if (direction != "north")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Fairy.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Fairy.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Student 1 --------------------
            if (Mathf.Approximately(cameraPos.z, 16.2f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction != "east")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[0] != null)
                        {
                            Destroy(characterCards[0].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Fairy.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student01.cards[0], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[0].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Student 6 --------------------
            if (Mathf.Approximately(cameraPos.z, 21.6f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction != "north")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Student06.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student06.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

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

            // Wolf -----------------------
            if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction != "east")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Wolf.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Wolf.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Fairy --------------------
            if (Mathf.Approximately(cameraPos.z, -5.4f) && Mathf.Approximately(cameraPos.x, 0f))
            {
                if (direction != "north")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Fairy.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Fairy.cards[0], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Student 1 --------------------
            if (Mathf.Approximately(cameraPos.z, 16.2f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction != "east")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[0] != null)
                        {
                            Destroy(characterCards[0].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Fairy.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student01.cards[0], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[0].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Student 6 --------------------
            if (Mathf.Approximately(cameraPos.z, 21.6f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction != "north")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                }
                else
                {
                    for (int i = 0; i < Student06.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student06.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

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

        //Fairy -------------------------------
        if (cameraPos.z == -5.4f && cameraPos.x == 0f && direction == "north")
        {
            inInteraction = true;
            if (roundNumber == 0 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((FairyCoroutine01()));
            }
            else if (roundNumber == 1 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "YesCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((FairyCoroutine02()));
            }
            else if (roundNumber == 1 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "NoCard(Clone)")
            {
                roundNumber = 0;
                StartCoroutine((FairyCoroutine05()));
            }
            else if (roundNumber == 2 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "ThankyouCard(Clone)" || roundNumber == 2 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "OKCard(Clone)" || roundNumber == 2 && speechTableTopCount == 2 && speechTabletop.transform.GetChild(0).gameObject.name == "OKCard(Clone)" && speechTabletop.transform.GetChild(1).gameObject.name == "ThankyouCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((FairyCoroutine03()));
            }
            else
            {
                StartCoroutine((FairyCoroutine04()));
            }
        }

        // Wolf  -------------------------------
        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f) && direction == "east")
        {
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                StartCoroutine((WolfCoroutine01(characterCards[0])));
            }
            else
            {
                //roundNumber++;
                for (int i = 0; i < Wolf.cards.Count; ++i)
                {
                    characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
                }
                StartCoroutine((WolfCoroutine02()));
            }
        }

        //door  ----------------------------------
        else if (cameraPos.z == 0f && cameraPos.x == 0f && direction == "north")
        {
            if (actionTableTopCount == 2 && actionTabletop.transform.GetChild(0).gameObject.name == "OpenCard(Clone)" && actionTabletop.transform.GetChild(1).gameObject.name == "DoorCard(Clone)")
            {
                //   Debug.Log("test");
                OpenFrontDoor();
            }
        }

        //Secretary  -------------------------------------
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

        //Dino  .........................
        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f) && direction == "west")
        {

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

        // Artemis ..............................
        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f) && direction == "west")
        {
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                print("test");
                StartCoroutine((ArtemisCoroutine01()));
            }
        }


        //Student 1  .........................
        else if (cameraPos.z == 16.2f && cameraPos.x == 5.4f && direction == "east")
        {
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((Student01Coroutine01()));
            }
            else
            {
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
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)" && roundNumber == 0 || speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HiCard(Clone)" && roundNumber == 0)
            {
                roundNumber++;
                StartCoroutine((Student06Coroutine02()));
            }
            else if (roundNumber == 1 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "YesCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((Student06Coroutine03()));
            }
            else if (roundNumber == 2 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "ThankyouCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((Student06Coroutine04()));
            }
            else
            {
                StartCoroutine((Student06Coroutine05()));
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
                // GameControl.evaCard.SetActive(true);
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

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.helloCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.areCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.youCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.lostCardSprite;
        characterCards[4].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[4].GetComponent<Image>().sprite = GameControl.questionMarkCardSprite;

        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator FairyCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playFairyTalk07Sound();

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.goCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.throughCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.theCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.doorCardSprite;

        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator FairyCoroutine03()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.fairyTalk08);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.youCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.willCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.needCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.thisCardSprite;

        ControlButton();
        characterCards[8].transform.SetParent(GameControl.actionTabletopPanel.transform, false);
        characterCards[8].GetComponent<Image>().sprite = GameControl.doorCardSprite;

        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator FairyCoroutine04()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.fairyHuh);
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator FairyCoroutine05()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.fairyOK);
        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.okCardSprite;

        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator WolfCoroutine01(Transform characterCard)
    {
        yield return new WaitForSeconds(1.5f);
        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.hiCardSprite;
        SoundManager.playWordSound(SoundManager.wolfHi);

        yield return new WaitForSeconds(2.5f);
        characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator WolfCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWolfGrowlSound();

        yield return new WaitForSeconds(2.5f);
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator Student01Coroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.hiCardSprite;
        SoundManager.playWordSound(SoundManager.Student01Hi);

        yield return new WaitForSeconds(2.5f);
        characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
    }
    IEnumerator Student01Coroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.Student01Huh);
    }
    IEnumerator Student06Coroutine01()
    {
        yield return new WaitForSeconds(0.7f);
        SoundManager.playWordSound(SoundManager.student06Talk01);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.hiCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.iCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.amCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.evaCardSprite;
    }
    IEnumerator Student06Coroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();

        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.student06Talk02);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.areCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.youCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.newCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.hereCardSprite;
        characterCards[4].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[4].GetComponent<Image>().sprite = GameControl.questionMarkCardSprite;
    }

    IEnumerator Student06Coroutine03()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();

        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.student06Talk03);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.haveCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.funCardSprite;
    }
    IEnumerator Student06Coroutine04()
    {
        yield return new WaitForSeconds(1.5f);
        GameControl.speechTabletopScript.SpeechReturnCardsToHand();
        characterCards[8].transform.SetParent(GameControl.speechTabletopPanel.transform, false);
        characterCards[8].GetComponent<Image>().sprite = GameControl.evaCardSprite;

        fairy.SetActive(true);
        dialogue.text = "You learned a new word.";
    }
    IEnumerator Student06Coroutine05()
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
    IEnumerator ArtemisCoroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        var characterICard = Instantiate(iCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterAmCard = Instantiate(amCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterLookingCard = Instantiate(lookingCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterForCard = Instantiate(forCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterMyCard = Instantiate(myCard, new Vector3(0, 0, 0), Quaternion.identity);
        var characterHoundCard = Instantiate(houndCard, new Vector3(0, 0, 0), Quaternion.identity);
        characterICard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterAmCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterLookingCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterForCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterMyCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterHoundCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
    }
    public void OpenFrontDoor()
    {
        frontDoor.transform.Rotate(0, 90f, 0, Space.World);
        frontDoor.transform.localPosition = new Vector3(-0.95f, 0.2079014f, 0.3f);
        frontDoor.tag = "Untagged";
        CheckWalls();
        SoundManager.playDoorOpeningSound();
        GameControl.actionTabletopScript.ReturnActionCardsToHand();
    }

    public void Dino()
    {
        ControlButton();
        GameControl.ArenaToggle();
        MainMusicSound.StopMainMusicSound();
        ArenaSound.StartArenaSound();
        StartCoroutine((DinoCoroutine01()));
    }




    public static void CharacterCardsReturn()
    {
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
    }
}