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
    public static GameObject speechPages, actionPages, letterPages, numberPages, letterPage1, letterPage2, speechTabletop, actionTabletop, cardTabletop;
    static SpriteRenderer secretary, secretaryCloseUp;
    static Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed, secretarySprite, secretarySprite01, secretarySprite02, secretarySprite03, fairyInTreeNoFairy, controlSprite01, controlSprite02, controlSprite03, controlSprite04, fairyNeutralSprite, wolfSprite, dinoSprite, doorCardSprite, youCardSprite, student06Sprite, student01Sprite, hiCardSprite, evaCardSprite;
    public Transform helloCard, howCard, areCard, youCard, questionMarkCard, canCard, notCard, passCard, lostCard, goCard, throughCard, theCard, doorCard, hiCard, whatCard, isCard, yourCard, nameCard, iCard, askedCard, fromCard, hereCard, amCard, evaCard, niceCard, toCard, meetCard, willCard, needCard, thisCard, lookingCard, forCard, myCard, houndCard, closeCard, pleaseCard;
    static string timeOfDay;
    int controlNumber = 0;
    public GameObject student3, dino, frontDoor;
    public GameObject[] solidObjects;

    public bool canWalkThroughNextWall;
    public static bool inInteraction;

    public static GameObject fairy, fairyInTree;
   // Animation fairyAnimation;
    GameControl gameControl;
    public static List<Transform> characterCards = new List<Transform>();
    public Button controlButton;

    public static int sceneNumber = 0;

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

    //    dialogue = GameObject.Find("Fairy Text").GetComponent<Text>();
    //    dialogue.text = "";

        // cardPages = GameObject.Find("CardPages");
        // blockUI = GameObject.Find("BlockUI");

        cardTabletop = GameObject.Find("WordTabletop");

        frontDoor = GameObject.Find("Front Door");
        //  secretary = GameObject.Find("Secretary").GetComponent<SpriteRenderer>();
        // secretaryCloseUp = GameObject.Find("Secretary Close Up").GetComponent<SpriteRenderer>();
        student3 = GameObject.Find("Student 03");
        dino = GameObject.Find("Dino");

        //fairy = GameObject.FindWithTag("Fairy");
        //fairy.SetActive(false);


        secretarySprite = Resources.Load<Sprite>("Foyer/Secretary");
        secretarySprite01 = Resources.Load<Sprite>("Foyer/Secretary01");
        secretarySprite02 = Resources.Load<Sprite>("Foyer/Secretary02");
        secretarySprite03 = Resources.Load<Sprite>("Foyer/Secretary03");


        //controlSprite01 = Resources.Load<Sprite>("UI/boots-icon");
        //controlSprite02 = Resources.Load<Sprite>("UI/speak-icon");
        //controlSprite03 = Resources.Load<Sprite>("UI/action-icon");
        //controlSprite04 = Resources.Load<Sprite>("UI/map-icon");

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
        Debug.Log(canWalkThroughNextWall);
        // 3D
        canWalkThroughNextWall = true;

        for (int i = 0; i < solidObjects.Length; i++)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(solidObjects[i].transform.position);
            // Vector3 rearViewPos = camera.WorldToViewportPoint(openings[i].transform.position) + new Vector3(0, 0, -5.4f);
            Debug.Log(viewPos);

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
        Debug.Log(canWalkThroughNextWall);
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
                    //for (int i = 0; i < Fairy.cards.Count; ++i)
                    //{
                    //    characterCards.Add(Instantiate(Fairy.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                    //    characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                    //    characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    //}
                    
                    var fairyScript = GameObject.Find("Fairy").GetComponent<Fairy>();
                    fairyScript.SayHello();
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
                    for (int i = 0; i < Student06.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student06.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
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

                //Door --------------------
                if (Mathf.Approximately(cameraPos.z, 0f) && Mathf.Approximately(cameraPos.x, 0f))
                {
                    //for (int i = 0; i < Door.cards.Count; ++i)
                    //{
                    //    characterCards.Add(Instantiate(Door.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                    //    characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                    //    characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    //}
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
                    //for (int i = 0; i < Wolf.cards.Count; ++i)
                    //{
                    //    characterCards.Add(Instantiate(Wolf.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                    //    characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                    //    characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    //}
                }

                //Student 1 -----------------------
                if (cameraPos.z == 16.2f && cameraPos.x == 5.4f && direction == "east")
                {
                    for (int i = 0; i < Student01.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student01.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }
            else if (direction == "west")
            {
                cameraPos.x += -5.4f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                cameraPos = camera.transform.position;

                // Dino interaction ----------------
                if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f))
                {
                    //for (int i = 0; i < Dino.cards.Count; ++i)
                    //{
                    //    characterCards.Add(Instantiate(Dino.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                    //    characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                    //    characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    //}
                    roundNumber = 0;
                    //  DinoMethod();
                }

                // Secretary interaction ----------------
                if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f))
                {
                    for (int i = 0; i < Secretary.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Secretary.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }

                    roundNumber = 0;
                }

                // To Forest stage ----------------
                if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -48.6f))
                {
                    RightButton();
                    cameraPos.z = -10.8f;
                    cameraPos.x = 0f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    cameraPos = camera.transform.position;

                    SceneManager.LoadScene("Forest");
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
                    roundNumber = 0;
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
                    for (int i = 0; i < Student01.cards.Count; ++i)
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
                if (direction == "west" || direction == "south")
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

            //Student06 --------------------
            if (Mathf.Approximately(cameraPos.z, 21.6f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction == "north")
                {
                    roundNumber = 0;
                    for (int i = 0; i < Student06.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student06.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }

                    StartCoroutine((Student06Coroutine01()));
                }
            }

            // Dino --------------------------
            if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f))
            {
                if (direction != "west")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                    roundNumber = 0;
                }
                else
                {
                    for (int i = 0; i < Dino.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Dino.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Secretary --------------------
            if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f))
            {
                if (direction != "west")
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
                    for (int i = 0; i < Secretary.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Secretary.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[0].GetComponent<Image>().sprite = GameControl.cardBackSprite;
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
                    roundNumber = 0;
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

            //Student06 --------------------
            if (Mathf.Approximately(cameraPos.z, 21.6f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                if (direction == "north")
                {
                    roundNumber = 0;
                    for (int i = 0; i < Student06.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Student06.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }

                    StartCoroutine((Student06Coroutine01()));
                }
            }

            // Dino --------------------------
            if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f))
            {
                if (direction != "west")
                {
                    for (int i = 0; i < characterCards.Count; ++i)
                    {
                        if (characterCards[i] != null)
                        {
                            Destroy(characterCards[i].gameObject);
                        }
                    }
                    characterCards.Clear();
                    roundNumber = 0;
                }
                else
                {
                    for (int i = 0; i < Dino.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Dino.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            //Secretary --------------------
            if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f))
            {
                if (direction != "west")
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
                    for (int i = 0; i < Secretary.cards.Count; ++i)
                    {
                        characterCards.Add(Instantiate(Secretary.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                        characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
                        characterCards[0].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                    }
                }
            }

            CheckWalls();
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
        int cardTabletopCount = cardTabletop.transform.childCount;

        //Fairy -------------------------------
        // if (cameraPos.z == -5.4f && cameraPos.x == 0f && direction == "north")
        // {
        //     inInteraction = true;
        //     if (roundNumber == 0 && cardTabletopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
        //     {
        //         roundNumber++;
        //         StartCoroutine((FairyCoroutine01()));
        //     }
        //     else if (roundNumber == 1 && cardTabletopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "YesCard(Clone)")
        //     {
        //         roundNumber++;
        //         StartCoroutine((FairyCoroutine02()));
        //     }
        //     else if (roundNumber == 1 && cardTabletopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "NoCard(Clone)")
        //     {
        //         roundNumber = 0;
        //         StartCoroutine((FairyCoroutine05()));
        //     }
        //     else if (roundNumber == 2 && cardTabletopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "ThankyouCard(Clone)")
        //     {
        //         roundNumber++;
        //         StartCoroutine((FairyCoroutine03()));
        //     }
        //     else
        //     {
        //         StartCoroutine((FairyCoroutine04()));
        //     }
        // }

        if (cameraPos.z == -5.4f && cameraPos.x == 0f && direction == "north")
        {
            if (roundNumber == 0 && cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                roundNumber = 1;
                StartCoroutine((FairyCoroutine01()));
            }
            else if (roundNumber == 1)
            {
                roundNumber = 2;
                NPCCardsAway();
            }
            else if (roundNumber == 2 && cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "YesCard(Clone)")
            {
                roundNumber = 3;
                StartCoroutine((FairyCoroutine02()));
            }
            else if (roundNumber == 3)
            {
                roundNumber = 4;
                NPCCardsAway();
            }

            else if (roundNumber == 4 && cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "NoCard(Clone)")
            {
                roundNumber = 0;
                StartCoroutine((FairyCoroutine05()));
            }
            // else if (roundNumber == 4 && cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "ThankyouCard(Clone)")
            // {
            //     roundNumber++;
            //     StartCoroutine((FairyCoroutine03()));
            // }
            else
            {
                StartCoroutine((FairyCoroutine04()));
            }
        }

        // Wolf  -------------------------------
        // else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f) && direction == "east")
        // {
        //     inInteraction = true;
        //     if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
        //     {
        //         StartCoroutine((WolfCoroutine01(characterCards[0])));
        //     }
        //     else
        //     {
        //         //roundNumber++;
        //         for (int i = 0; i < Wolf.cards.Count; ++i)
        //         {
        //             characterCards[0].transform.SetParent(GameControl.characterHand.transform, false);
        //         }
        //         StartCoroutine((WolfCoroutine02()));
        //     }
        // }

        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f) && direction == "east")
        {
            if (cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
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

        // else if (cameraPos.z == 0f && cameraPos.x == 0f && direction == "north")
        // {
        //     if (actionTableTopCount == 2 && actionTabletop.transform.GetChild(0).gameObject.name == "OpenCard(Clone)" && actionTabletop.transform.GetChild(1).gameObject.name == "DoorCard(Clone)")
        //     {
        //         //   Debug.Log("test");
        //         OpenFrontDoor();
        //     }
        // }


        else if (cameraPos.z == 0f && cameraPos.x == 0f && direction == "north" || cameraPos.z == 5.4f && cameraPos.x == 0f && direction == "south")
        {
            if (cardTabletopCount == 2 && cardTabletop.transform.GetChild(0).gameObject.name == "OpenCard(Clone)" && cardTabletop.transform.GetChild(1).gameObject.name == "DoorCard(Clone)" && frontDoor.tag == "CantWalkThrough")
            {
                OpenFrontDoor();
            }

            else if (cardTabletopCount == 2 && cardTabletop.transform.GetChild(0).gameObject.name == "CloseCard(Clone)" && cardTabletop.transform.GetChild(1).gameObject.name == "DoorCard(Clone)" && frontDoor.tag == "Untagged")
            {
                CloseFrontDoor();
            }
        }


        //Secretary  -------------------------------------

        // else if (cameraPos.z == 5.4f && cameraPos.x == -5.4f && direction == "west")
        // {
        //     if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0)
        //     {
        //         GameControl.ArenaToggle();
        //         roundNumber++;
        //         GameControl.characterImage.sprite = secretarySprite01;
        //         GameControl.characterImage.rectTransform.sizeDelta = new Vector2(300, 700);
        //         SoundManager.playSecretaryTalk01ASound();
        //     }
        // }

        else if (cameraPos.z == 5.4f && cameraPos.x == -5.4f && direction == "west")
        {
            roundNumber = 0;
            if (roundNumber == 0 & cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                roundNumber = 1;
                if (frontDoor.tag == "Untagged")
                    StartCoroutine(SecretaryCoroutine01());
                //else
                //     //     StartCoroutine(SecretaryCoroutine02());
            }
            else if (roundNumber == 1)
            {
                roundNumber = 2;
                StartCoroutine(SecretaryCoroutine02());
                NPCCardsAway();
                GameControl.tabletopScript.ReturnPlayerCardsToHand();
            }
            // else if (roundNumber == 2)
            // {
            //     roundNumber = 3;
            // }
        }

        //Dino  .........................

        // else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f) && direction == "west")
        // {
        //     if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "EvaCard(Clone)")
        //     {
        //         roundNumber++;
        //         StartCoroutine((DinoCoroutine04()));
        //     }
        //     else if (roundNumber == 0)
        //     {
        //         roundNumber++;

        //         StartCoroutine((DinoCoroutine02()));
        //     }
        //     else if (roundNumber == 1)
        //     {
        //         roundNumber++;

        //         StartCoroutine((DinoCoroutine03()));
        //     }
        //     else if (roundNumber == 2)
        //     {
        //         SceneManager.LoadScene("GameOver");
        //         gameControl = FindObjectOfType<GameControl>();
        //         Destroy(gameControl.gameObject);
        //     }
        // }

        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f) && direction == "west")
        {
            if (cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "EvaCard(Clone)")
            {
                StartCoroutine((DinoCoroutine04()));
            }
            else if (roundNumber == 0)
            {
                roundNumber = 1;

                StartCoroutine((DinoCoroutine02()));
            }
            else if (roundNumber == 1)
            {
                roundNumber = 2;

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

        // else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f) && direction == "west")
        // {
        //     if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
        //     {
        //         StartCoroutine((ArtemisCoroutine01()));
        //     }
        // }

        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -10.8f) && direction == "west")
        {
            if (cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                StartCoroutine((ArtemisCoroutine01()));
            }
        }


        //Student 1  .........................

        // else if (cameraPos.z == 16.2f && cameraPos.x == 5.4f && direction == "east")
        // {
        //     inInteraction = true;
        //     if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
        //     {
        //         roundNumber++;
        //         StartCoroutine((Student01Coroutine01()));
        //     }
        //     else
        //     {
        //         StartCoroutine((Student01Coroutine02()));
        //     }
        // }

        else if (cameraPos.z == 16.2f && cameraPos.x == 5.4f && direction == "east")
        {
            //   inInteraction = true;
            if (cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((Student01Coroutine01()));
            }
            else
            {
                StartCoroutine((Student01Coroutine02()));
            }
        }

        //Student 2 .........................

        // else if (cameraPos.z == 21.6f && cameraPos.x == -5.4f && direction == "north")
        // {
        //     inInteraction = true;
        //     if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0 || speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HiCard" && roundNumber == 0)
        //     {
        //         GameControl.ArenaToggle();
        //         roundNumber++;
        //         StartCoroutine((Student02Coroutine01()));
        //     }
        // }

        //Student 6 .........................

        // else if (cameraPos.z == 21.6f && cameraPos.x == 5.4f && direction == "north")
        // {
        //     if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)" && roundNumber == 0 || speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HiCard(Clone)" && roundNumber == 0)
        //     {
        //         roundNumber++;
        //         StartCoroutine((Student06Coroutine02()));
        //     }
        //     else if (roundNumber == 1 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "YesCard(Clone)")
        //     {
        //         roundNumber++;
        //         StartCoroutine((Student06Coroutine03()));
        //     }
        //     else if (roundNumber == 2 && speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "ThankyouCard(Clone)")
        //     {
        //         roundNumber++;
        //         StartCoroutine((Student06Coroutine04()));
        //     }
        //     else
        //     {
        //         StartCoroutine((Student06Coroutine05()));
        //     }
        // }

        else if (cameraPos.z == 21.6f && cameraPos.x == 5.4f && direction == "north")
        {
            if (cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "HelloCard(Clone)" && roundNumber == 0)
            {
                roundNumber++;
                StartCoroutine((Student06Coroutine02()));
            }
            else if (roundNumber == 1 && cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "YesCard(Clone)")
            {
                roundNumber++;
                StartCoroutine((Student06Coroutine03()));
            }
            else if (roundNumber == 2 && cardTabletopCount == 1 && cardTabletop.transform.GetChild(0).gameObject.name == "ThankyouCard(Clone)")
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

            ArenaSound.StopArenaSound();
            MainMusicSound.PlayMainMusicSound();
            roundNumber = 0;
        }
        GameControl.BlackBG();
    }

    void NPCCardsAway()
    {
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.tabletopScript.ReturnPlayerCardsToHand();
    }

    IEnumerator FairyCoroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.fairyTalk06);

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

        // yield return new WaitForSeconds(2.5f);
        // NPCCardsAway();


        //--------------- dark background and they grab all words -----------------------
        // var tempColor = GameControl.arenaPanel.color;
        // tempColor.a = 0.8f;
        // GameControl.arenaPanel.color = tempColor;
        // GameControl.HideControls();

        // characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        // characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        // characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);

        // characterCards[1].GetComponent<Image>().sprite = GameControl.openCardSprite;
        // characterCards[2].GetComponent<Image>().sprite = GameControl.theCardSprite;
        // characterCards[3].GetComponent<Image>().sprite = GameControl.doorCardSprite;

        // -----------------------------------------------------------    


        //--------------- to take cards away -----------------------
        // yield return new WaitForSeconds(3.5f);
        // for (int i = 0; i < characterCards.Count; ++i)
        // {
        //     characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
        //     characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        // }
        // GameControl.tabletopScript.ReturnPlayerCardsToHand();
        // -----------------------------------------------------------    
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

        GameControl.tabletopScript.ReturnPlayerCardsToHand();

        // ControlButton();
        controlButton.interactable = false;
        // characterCards[8].transform.SetParent(GameControl.actionTabletopPanel.transform, false);
        characterCards[8].transform.SetParent(GameControl.wordTabletopPanel.transform, false);
        characterCards[8].GetComponent<Image>().sprite = GameControl.doorCardSprite;

        roundNumber = 0;

        //GameControl.speechTabletopScript.ReturnPlayerCardsToHand();
    }
    IEnumerator FairyCoroutine04()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.fairyHuh);

        GameControl.tabletopScript.ReturnPlayerCardsToHand();
        //  GameControl.speechTabletopScript.ReturnPlayerCardsToHand();
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
        GameControl.tabletopScript.ReturnPlayerCardsToHand();

        roundNumber = 0;
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
        GameControl.tabletopScript.ReturnPlayerCardsToHand();
    }
    IEnumerator WolfCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWolfGrowlSound();

        yield return new WaitForSeconds(2.5f);
        GameControl.tabletopScript.ReturnPlayerCardsToHand();
    }

    IEnumerator SecretaryCoroutine01()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playWordSound(SoundManager.SecretaryTalk01);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.helloCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.pleaseCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.closeCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.theCardSprite;
        characterCards[4].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[4].GetComponent<Image>().sprite = GameControl.doorCardSprite;
    }

    IEnumerator SecretaryCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        characterCards[2].transform.SetParent(GameControl.cardTabletop.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.closeCardSprite;
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
        GameControl.tabletopScript.ReturnPlayerCardsToHand();
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
        GameControl.tabletopScript.ReturnPlayerCardsToHand();

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
        //GameControl.speechTabletopScript.ReturnPlayerCardsToHand();
        GameControl.tabletopScript.ReturnPlayerCardsToHand();

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
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }

        GameControl.tabletopScript.ReturnPlayerCardsToHand();

        characterCards[3].transform.SetParent(GameControl.cardTabletop.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.evaCardSprite;

        // fairy.SetActive(true);
        // dialogue.text = "You learned a new word.";
        controlButton.interactable = false;
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
        yield return new WaitForSeconds(0.5f);
        SoundManager.playSound(SoundManager.dinoTalk01);
        GameControl.characterTabletopPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 220);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.hiCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.whatCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.isCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.yourCardSprite;
        characterCards[4].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[4].GetComponent<Image>().sprite = GameControl.nameCardSprite;
        characterCards[5].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[5].GetComponent<Image>().sprite = GameControl.questionMarkCardSprite;
    }
    IEnumerator DinoCoroutine02()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.tabletopScript.ReturnPlayerCardsToHand();

        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.dinoTalk02);
        GameControl.characterTabletopPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 220);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.iCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.askedCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.whatCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.yourCardSprite;
        characterCards[4].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[4].GetComponent<Image>().sprite = GameControl.nameCardSprite;
        characterCards[5].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[5].GetComponent<Image>().sprite = GameControl.isCardSprite;
    }
    IEnumerator DinoCoroutine03()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.tabletopScript.ReturnPlayerCardsToHand();
        SoundManager.playSound(SoundManager.dinoTalk03);
        GameControl.characterTabletopPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(540, 110);
        GameControl.RedBG();

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.youCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.areCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.notCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.fromCardSprite;
        characterCards[4].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[4].GetComponent<Image>().sprite = GameControl.hereCardSprite;
    }
    IEnumerator DinoCoroutine04()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.dinoTalk04);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.tabletopScript.ReturnPlayerCardsToHand();

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.hiCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.evaCardSprite;

        // ArenaSound.StopArenaSound();
        // MainMusicSound.PlayMainMusicSound();
        StartCoroutine((DinoCoroutine05()));
    }
    IEnumerator DinoCoroutine05()
    {
        controlButton.interactable = false;

        yield return new WaitForSeconds(1.5f);
        SoundManager.playSound(SoundManager.dinoTalk05);

        characterCards[0].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[0].GetComponent<Image>().sprite = GameControl.niceCardSprite;
        characterCards[1].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[1].GetComponent<Image>().sprite = GameControl.toCardSprite;
        characterCards[2].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[2].GetComponent<Image>().sprite = GameControl.meetCardSprite;
        characterCards[3].transform.SetParent(GameControl.characterTabletopPanel.transform, false);
        characterCards[3].GetComponent<Image>().sprite = GameControl.youCardSprite;


        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
        GameControl.tabletopScript.ReturnPlayerCardsToHand();



        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);
        dino.GetComponent<Dino>().Move();
        yield return new WaitForSeconds(1.5f);

        // fairy.SetActive(true);
        // dialogue.text = "You got a new card";
        characterCards[16].transform.SetParent(GameControl.wordTabletopPanel.transform, false);
        characterCards[16].GetComponent<Image>().sprite = GameControl.meetCardSprite;

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
        dino.SetActive(false);
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
        frontDoor.transform.localPosition = new Vector3(-0.95f, 2.3f, 0.3f);
        frontDoor.tag = "Untagged";
        CheckWalls();
        SoundManager.playDoorOpeningSound();
        // GameControl.tabletopScript.ReturnPlayerCardsToHand();

        //  GameObject gameControl = GameObject.Find("GameControl");
        //  GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        // if (Player.playerCards.Count == 6)
        // {
        //     var playerCloseCard = Instantiate(closeCard, new Vector3(0, 0, 0), Quaternion.identity);
        //     playerCloseCard.transform.SetParent(GameControl.cardTabletop.transform, false);

        //     controlButton.interactable = false;
        // }

        // fairy.SetActive(true);
        // dialogue.text = "You learned a new word.";

    }

    public void CloseFrontDoor()
    {
        frontDoor.transform.Rotate(0, -90f, 0, Space.World);
        frontDoor.transform.localPosition = new Vector3(0f, 2.3f, 2.7f);
        frontDoor.tag = "CantWalkThrough";
        CheckWalls();
        SoundManager.playDoorOpeningSound();
        GameControl.tabletopScript.ReturnPlayerCardsToHand();

        // if (Player.playerCards.Count == 7)
        // {
        //     var playerTheCard = Instantiate(theCard, new Vector3(0, 0, 0), Quaternion.identity);
        //     playerTheCard.transform.SetParent(GameControl.cardTabletop.transform, false);

        //     controlButton.interactable = false;
        // }
    }

    public void DinoMethod()
    {
        //ControlButton();
        //MainMusicSound.StopMainMusicSound();
        //ArenaSound.StartArenaSound();
        StartCoroutine((DinoCoroutine01()));
    }

    public static void DinoCardsDisappear()
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


    public static void CharacterCardsReturn()
    {
        for (int i = 0; i < characterCards.Count; ++i)
        {
            characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
            characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
        }
    }

    public void Craft()
    {
        // Fairy ------------------------------
        if (Mathf.Approximately(cameraPos.z, -5.4f) && Mathf.Approximately(cameraPos.x, 0f) && direction == "north")
        {
            int letterTabletopCount = GameControl.letterTabletop.transform.childCount;
            print(letterTabletopCount);

            if (letterTabletopCount == 5 && GameControl.letterTabletop.transform.GetChild(0).gameObject.name == "FCard" && GameControl.letterTabletop.transform.GetChild(1).gameObject.name == "ACard" && GameControl.letterTabletop.transform.GetChild(2).gameObject.name == "ICard" && GameControl.letterTabletop.transform.GetChild(3).gameObject.name == "RCard" && GameControl.letterTabletop.transform.GetChild(4).gameObject.name == "YCard")
            {
                GameObject gameControl = GameObject.Find("GameControl");
                GameControl gameControlScript = gameControl.GetComponent<GameControl>();

                gameControlScript.ControlButton();
                characterCards[10].transform.SetParent(GameControl.wordTabletopPanel.transform, false);
                characterCards[10].GetComponent<Image>().sprite = GameControl.fairyCardSprite;
                SoundManager.playWordSound(SoundManager.fairyCraftSound);
                // var frontDoorPart = frontDoor.GetComponent<ParticleSystem>();
                // frontDoorPart.Play();

            }
        }


        // Door ------------------------------
        if (Mathf.Approximately(cameraPos.z, 0f) && Mathf.Approximately(cameraPos.x, 0f) && direction == "north")
        {
            int letterTabletopCount = GameControl.letterTabletop.transform.childCount;
            print(letterTabletopCount);

            if (letterTabletopCount == 4 && GameControl.letterTabletop.transform.GetChild(0).gameObject.name == "DCard" && GameControl.letterTabletop.transform.GetChild(1).gameObject.name == "OCard" && GameControl.letterTabletop.transform.GetChild(2).gameObject.name == "ACard" && GameControl.letterTabletop.transform.GetChild(3).gameObject.name == "RCard")
            {
                GameObject gameControl = GameObject.Find("GameControl");
                GameControl gameControlScript = gameControl.GetComponent<GameControl>();
                gameControlScript.ControlButton();
                characterCards[0].transform.SetParent(GameControl.wordTabletopPanel.transform, false);
                characterCards[0].GetComponent<Image>().sprite = GameControl.doorCardSprite;

                var frontDoorPart = frontDoor.GetComponent<ParticleSystem>();
                frontDoorPart.Play();
                SoundManager.playWordSound(SoundManager.doorCraftSound);
            }
        }

        GameControl.tabletopScript.ReturnPlayerCardsToHand();

    }


    public void CheckTile(List<string> currentWords)
    {
        GameObject gameControl = GameObject.Find("GameControl");
        NPCUI NPCUIScript = gameControl.GetComponent<NPCUI>();
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();     

        //Tile Academy A2 "Fairy outside Academy, on tree"
        if (cameraPos.z == -5.4f && cameraPos.x == 0f && direction == "north")
        {
            if (sceneNumber == 0)
            {
                if (currentWords[0] == "HELLO")
                {
                    sceneNumber = 1;
                    NPCUIScript.UpdateNPCText("Hello");
                    if (PuzzleCompletionRecord.A2 == false)
                    {
                        PuzzleCompletionRecord.A2 = true;                       
                        gameControlScript.helloSpellButton.sprite = Resources.Load<Sprite>("Cards/HelloCard");
                    }
                }
            }
        }
        //Tile Academy A3 "Academy door"
        if (cameraPos.z == 0f && cameraPos.x == 0f && direction == "north")
        {

            if (sceneNumber == 0)
            {
                if (currentWords[0] == "OPEN")
                {
                    OpenFrontDoor();

                    sceneNumber = 1;
                    if (PuzzleCompletionRecord.A3 == false)
                    {
                        PuzzleCompletionRecord.A3 = true;
                        gameControlScript.helloSpellButton.sprite = Resources.Load<Sprite>("Cards/OpenCard");
                    }
                }
            }
        }
    }


    public void NPCTextCont()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        NPCUI NPCUIScript = gameControl.GetComponent<NPCUI>();
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //Tile Academy A2 "Fairy outside Academy, on tree"
        if (cameraPos.z == -5.4f && cameraPos.x == 0f && direction == "north")
        {
            if (sceneNumber == 1)
            {
                NPCUIScript.UpdateNPCText("Welcome to the Academy.");
                sceneNumber = 2;
            }
            else if (sceneNumber == 2)
            {
                NPCUIScript.UpdateNPCText("");
                sceneNumber = 3;
              
                SoundManager.playSound(SoundManager.correctSound);
            }         
        }
    }
}