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
    static Text dialogue;
    int textNumber;
    bool isRoomsDoorClosed = true, tutorial, tutorial1Complete = false;
    public static GameObject speechPages, actionPages, letterPages, numberPages, mapPage1, frontDoor, LaboratoryDoor, page1, page2, page3, page4, page5, letterPage1, letterPage2, playerTabletop;
    static SpriteRenderer frontDoorway, roomsDoorway, secretary, secretaryCloseUp;
    static Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed, secretarySprite, secretarySprite01, secretarySprite02, secretarySprite03, fairyInTreeNoFairy, controlSprite01, controlSprite02, controlSprite03, controlSprite04, fairyNeutralSprite;
    public static bool helloHold, goodHold, oneHold, twoHold, threeHold, fourHold, fiveHold, sixHold, sevenHold, eightHold, nineHold;
    public Transform helloCard, howCard, areCard, youCard, questionMarkCard;
    static string timeOfDay, playerName;
    int playerAge, playerAge0, playerAge10 = 0, controlNumber = 0;

    //--

    public GameObject teacher;
    public GameObject[] openings, solidObjects;

    public bool canWalkThroughNextWall, canWalkThroughPreviousWall;


    GameObject fairy, fairyInTree;
    Animation fairyAnimation;

    public Color black = Color.black;
    public Color night;

    void Start()
    {
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

        playerTabletop = GameObject.Find("PlayerTabletop");

        letterPage1 = GameObject.Find("LetterPage1");
        letterPage2 = GameObject.Find("LetterPage2");

        //page1 = GameObject.Find("Page1");
        //page2 = GameObject.Find("Page2");
        //page3 = GameObject.Find("Page3");
        //page4 = GameObject.Find("Page4");
        //page5 = GameObject.Find("Page5");
        mapPage1 = GameObject.Find("MapPage1");
        frontDoor = GameObject.Find("FrontDoor");
        LaboratoryDoor = GameObject.Find("LaboratoryDoor");
        secretary = GameObject.Find("Secretary").GetComponent<SpriteRenderer>();
        secretaryCloseUp = GameObject.Find("Secretary Close Up").GetComponent<SpriteRenderer>();

        if (GameControl.scene == "Academy")
        {
            // frontDoorway = GameObject.Find("FrontDoor").GetComponent<SpriteRenderer>();
            frontDoorOpen = Resources.Load<Sprite>("Views/Academy/OutsideAcademyView03b");
            //roomsDoorway = GameObject.Find("LaboratoryDoor").GetComponent<SpriteRenderer>();
            roomsDoorOpen = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05b");
            roomsDoorClosed = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05");
            fairyInTreeNoFairy = Resources.Load<Sprite>("Fairy_on_tree-no_Fairy");
            fairyInTree = GameObject.FindWithTag("Fairy in tree");
            fairy = GameObject.FindWithTag("Fairy");
            fairy.SetActive(false);
        }
        //   secretary = GameObject.Find("Secretary Close Up").GetComponent<SpriteRenderer>();
        secretarySprite = Resources.Load<Sprite>("Foyer/Secretary");
        secretarySprite01 = Resources.Load<Sprite>("Foyer/Secretary01");
        secretarySprite02 = Resources.Load<Sprite>("Foyer/Secretary02");
        secretarySprite03 = Resources.Load<Sprite>("Foyer/Secretary03");
        fairyNeutralSprite = Resources.Load<Sprite>("Characters/FairyNeutral");

        controlSprite01 = Resources.Load<Sprite>("UI/boots-icon");
        controlSprite02 = Resources.Load<Sprite>("UI/speak-icon");
        controlSprite03 = Resources.Load<Sprite>("UI/action-icon");
        controlSprite04 = Resources.Load<Sprite>("UI/map-icon");

        //   if (GameControl.scene == "Academy Wild Area")
        if (GameControl.scene == "Academy")
        {
            // check which are doorways
            //Invoke("CheckWalk", 1f);
            CheckWalk();
        }
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
            }

            else if (cameraPos.z == -10.8f && direction == "east" || cameraPos.z == -10.8f && direction == "west")
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
        if (cameraPos.y == 2)
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
                if (!GameControl.readCard.GetComponent<Button>().interactable)
                    GameControl.HideArrows();
                else
                    GameControl.HideUpArrow();

                //   GameControl.ShowCardToggles();
                fairy.transform.localPosition = new Vector3(-0.47f, 0.4f, 1f);
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

                fairy.transform.localPosition = new Vector3(-1f, 0.4f, 1f);
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
        int count = playerTabletop.transform.childCount;
        // print(count);
        // for (int i = 0; i < count; i++)
        // {
        //     Transform child = playerTabletop.transform.GetChild(i);
        //     print(child.gameObject.name);
        // }

        //Fairy interaction -------------------------------
        if (cameraPos.z == -5.4f && cameraPos.x == 0f && direction == "north")
        {
            if (count == 1 && playerTabletop.transform.GetChild(0).gameObject.name == "HelloCard")
            {
                GameControl.ArenaToggle();
                GameControl.characterImage.sprite = fairyNeutralSprite;
                SoundManager.playFairyTalk01Sound();

                ArenaSound.StartArenaSound();

                // cameraPos.y = 50f;
                // camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                // camera.backgroundColor = black;
                // dialogue.text = "Hello.\nHow are you?";

                var characterHelloCard = Instantiate(helloCard, new Vector3(0, 0, 0), Quaternion.identity);
                var characterHowCard = Instantiate(howCard, new Vector3(0, 0, 0), Quaternion.identity);
                var characterAreCard = Instantiate(areCard, new Vector3(0, 0, 0), Quaternion.identity);
                var characterYouCard = Instantiate(youCard, new Vector3(0, 0, 0), Quaternion.identity);
                var characterQuestionMarkCard = Instantiate(questionMarkCard, new Vector3(0, 0, 0), Quaternion.identity);
                characterHelloCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
                characterHowCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
                characterAreCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
                characterYouCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
                characterQuestionMarkCard.transform.SetParent(GameControl.characterTabletopPanel.transform, false);
            }
        }
    }

    public void RunAway()
    {
        GameControl.ArenaToggle();
        ArenaSound.StopArenaSound();
    }

    public void HelloCard()
    {

        //  if (!CardMoveToggle.toggle.isOn)
        //  {
        // GameControl.hasHelloCard = true;
        //  GameControl.helloCard.GetComponent<Image>().color = Color.white;
        //  helloHold = false;

        if (cameraPos.z == -5.4f && cameraPos.x == 0f)
        {

            //&& !fairy.activeSelf
            // first Fairy interaction - sceneOne

            cameraPos.y = 50f;

            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            camera.backgroundColor = black;
            if (!GameControl.goodCard.GetComponent<Button>().interactable)
            {
                if (GameControl.sceneOne == 1)
                {
                    dialogue.text = "Hello.\nHow are you?";
                    SoundManager.playFairyTalk01Sound();
                }
                else
                    dialogue.text = "Ah,\nyou again.";

                GameControl.goodCard.GetComponent<Button>().interactable = true;
                GameControl.goodCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                GameControl.badCard.GetComponent<Button>().interactable = true;
                GameControl.badCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                SoundManager.playCardAppearSound();
            }
        }

        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -5.4f) && cameraPos.y == 2f)
        {
            cameraPos.y = 50f;
            //     camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            //      camera.backgroundColor = black;
            dialogue.text = "You cannot pass.";
            SoundManager.playWolfTalk01Sound();
            if (!GameControl.okCard.GetComponent<Button>().interactable)
            {
                GameControl.okCard.GetComponent<Button>().interactable = true;
                GameControl.okCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                SoundManager.playCardAppearSound();
            }
        }
        else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f) && cameraPos.y == 2f)
        {
            cameraPos.y = 50f;
            //     camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            //      camera.backgroundColor = black;
            dialogue.text = "You cannot pass.";
            SoundManager.playWolfTalk01Sound();
            if (!GameControl.okCard.GetComponent<Button>().interactable)
            {
                GameControl.okCard.GetComponent<Button>().interactable = true;
                GameControl.okCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                SoundManager.playCardAppearSound();
            }
        }
        else if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f) && cameraPos.y == 2f)
        {
            // first Secretary interaction - sceneTwo              
            cameraPos.y = 80f;
            //      camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            //      camera.backgroundColor = black;

            // dialogue.text = "Hello. Sit down please.";


            if (GameControl.sceneTwo == 1)
            {
                dialogue.text = "Good " + timeOfDay;
                if (timeOfDay == "morning")
                    SoundManager.playSecretaryTalk01ASound();
                else if (timeOfDay == "afternoon")
                    SoundManager.playSecretaryTalk01BSound();
                else
                    SoundManager.playSecretaryTalk01CSound();
            }
            else
                //dialogue.text = "Es-tu perdu?";
                dialogue.text = "Are you lost?";

            GameControl.morningCard.GetComponent<Button>().interactable = true;
            GameControl.morningCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.afternoonCard.GetComponent<Button>().interactable = true;
            GameControl.afternoonCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.eveningCard.GetComponent<Button>().interactable = true;
            GameControl.eveningCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            SoundManager.playCardAppearSound();

            GameControl.sitCard.GetComponent<Button>().interactable = true;
            GameControl.sitCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            SoundManager.playCardAppearSound();
            FairyAnimation.CorrectAnswer();
        }
        else if (cameraPos.z == 16.2f && cameraPos.x == 5.4f)
        {
            cameraPos.y = 32f;
            //     camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            FairyAnimation.CorrectAnswer();
        }
        else
        {
            FairyAnimation.IncorrectAnswer();
            //  Restart();
        }
        // }
    }

    public void HelloCardHold()
    {
        helloHold = true;
        GameControl.helloCard.GetComponent<Image>().color = Color.gray;
    }

    public void GoodbyeCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            GameControl.hasGoodbyeCard = true;

            if (cameraPos.z == -5.4f && cameraPos.x == 0f && cameraPos.y == 50f)
            {
                // first Fairy interaction - sceneOne
                GameControl.sceneOne = GameControl.sceneOne + 1;
                GameControl.Save();

                cameraPos.y = 2f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                dialogue.text = "";
                camera.backgroundColor = night;

                //    GameControl.WorldNavigationUIChange();

                fairyInTree.GetComponent<SpriteRenderer>().sprite = fairyInTreeNoFairy;
                fairy.SetActive(true);
            }
            else if (cameraPos.z == 6.2 && y == 12f)
            {
                y = 0f;
                camera.transform.position = new Vector3(x, y, z);
                dialogue.text = "";
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
                //   Restart();
            }

            if (GameControl.scene == "Academy Wild Area")
            {
                Vector3 viewPos = camera.WorldToViewportPoint(teacher.transform.position);

                if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
                {
                    y = 0f;
                    camera.transform.position = new Vector3(x, y, z);
                    dialogue.text = "";
                }
            }
        }
    }

    public void GoodCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (cameraPos.z == -5.4f && cameraPos.x == 0f && cameraPos.y == 50f)
            {
                //dialogue.text = "Es-tu perdu?";

                if (!GameControl.yesCard.GetComponent<Button>().interactable)
                {
                    dialogue.text = "Are you lost?";
                    SoundManager.playFairyTalk02Sound();
                    GameControl.yesCard.GetComponent<Button>().interactable = true;
                    GameControl.yesCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.noCard.GetComponent<Button>().interactable = true;
                    GameControl.noCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    SoundManager.playCardAppearSound();
                    GameControl.hasGoodCard = true;
                }
            }
            else if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f) && cameraPos.y == 12f)
            {

            }
            else
            {
                //    Restart();
                FairyAnimation.IncorrectAnswer();
            }
        }
    }

    // public void GoodCardHold()
    // {
    //     if (!CardMoveToggle.toggle.isOn)
    //     {
    //         goodHold = true;
    //         GameControl.goodCard.GetComponent<Image>().color = Color.gray;
    //         FairyAnimation.CorrectAnswer();
    //     }
    // }

    public void BadCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (cameraPos.z == -5.4f && cameraPos.x == 0f && cameraPos.y == 50f)
            {
                if (!GameControl.yesCard.GetComponent<Button>().interactable)
                {
                    //dialogue.text = "Es-tu perdu?";
                    dialogue.text = "Are you lost?";
                    SoundManager.playFairyTalk02Sound();
                    GameControl.yesCard.GetComponent<Button>().interactable = true;
                    GameControl.yesCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.noCard.GetComponent<Button>().interactable = true;
                    GameControl.noCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    SoundManager.playCardAppearSound();
                }
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
                //   Restart();
            }
        }
    }

    public void OpenCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (Mathf.Approximately(cameraPos.z, 0f))
            {
                SoundManager.playDoorOpeningSound();
                frontDoorway.sprite = frontDoorOpen;

                frontDoor.tag = "CanWalkThrough";
                CheckWalk();
                FairyAnimation.CorrectAnswer();
            }
            else if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 5.4f) && isRoomsDoorClosed)
            {
                // SoundManager.playDoorOpeningSound();
                // roomsDoorway.sprite = roomsDoorOpen;
                // isRoomsDoorClosed = false;
                // LaboratoryDoor.tag = "CanWalkThrough";
                // CheckWalk();
                // FairyAnimation.CorrectAnswer();

                SoundManager.playDoorLockedSound();
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
                //    Restart();
            }
        }
    }

    public void YesCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (cameraPos.z == -5.4f && cameraPos.x == 0f && cameraPos.y == 50f)
            {
                if (!GameControl.thankYouCard.GetComponent<Button>().interactable)
                {
                    GameControl.thankYouCard.GetComponent<Button>().interactable = true;
                    GameControl.thankYouCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.openCard.GetComponent<Button>().interactable = true;
                    GameControl.openCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    dialogue.text = "Go to the Academy.\n I will go with you.";
                    SoundManager.playFairyTalk03Sound();
                    SoundManager.playCardAppearSound();
                    GameControl.hasYesCard = true;
                }
            }
            else if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 0f) && cameraPos.y == 12f && tutorial)
            {
                dialogue.text = "To use 2 words, hold down the one until it is grey, then press the other.";
                SoundManager.playFairyTalk04Sound();
                tutorial1Complete = true;
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
                //  Restart();
            }
        }
    }
    public void NoCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (cameraPos.z == -5.4f && cameraPos.x == 0f && cameraPos.y == 50f)
            {
                GameControl.thankYouCard.GetComponent<Button>().interactable = true;
                GameControl.thankYouCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                GameControl.openCard.GetComponent<Button>().interactable = true;
                GameControl.openCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                dialogue.text = "Go to the Academy.\n I will go with you.";
                SoundManager.playFairyTalk03Sound();
                SoundManager.playCardAppearSound();
                GameControl.hasNoCard = true;
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
                //    Restart();
            }
        }
    }

    public void ThankYouCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (cameraPos.z == -5.4f && cameraPos.x == 0f)
            {
                GameControl.goodbyeCard.GetComponent<Button>().interactable = true;
                GameControl.goodbyeCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            }
            else if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f) && cameraPos.y == 80f)
            {
                if (GameControl.readCard.GetComponent<Button>().interactable)
                {
                    dialogue.text = "";
                    cameraPos.y = 2f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    FairyAnimation.CorrectAnswer();
                    secretary.sprite = secretarySprite;
                }
                else
                    FairyAnimation.IncorrectAnswer();
            }
            else if (tutorial && cameraPos.y == 12 && tutorial1Complete)
            {
                cameraPos.y = 0f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                dialogue.text = "";
                tutorial = false;
                FairyAnimation.CorrectAnswer();
                fairy.transform.localPosition = new Vector3(-2f, 1.4f, 1f);
                fairy.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
                //   Restart();
            }
        }
    }

    public void ReadCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 5.4f))
            {
                cameraPos.y = 12f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                FairyAnimation.CorrectAnswer();
                GameControl.stopCard.GetComponent<Button>().interactable = true;
                GameControl.stopCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                SoundManager.playCardAppearSound();
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
            }
        }
    }

    public void StopCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 5.4f) && cameraPos.y == 12f)
            {
                cameraPos.y = 0f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                FairyAnimation.CorrectAnswer();
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
            }
        }
    }

    public void CloseCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (z > 6.1 && z < 6.3 && !isRoomsDoorClosed)
            {
                SoundManager.playDoorOpeningSound();
                roomsDoorway.sprite = roomsDoorClosed;
                isRoomsDoorClosed = true;
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
            }
        }
    }

    public void HiCard()
    {
        if (cameraPos.z == 17f && cameraPos.x == 5.4f)
        {
            y = 12f;
            camera.transform.position = new Vector3(x, y, z);
            dialogue.text = "Hi. I'm Sue.";
        }

        else
        {
            Restart();
        }
    }

    public void OKCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (!CardMoveToggle.toggle.isOn)
            {
                if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, -5.4f) && cameraPos.y == 50f)
                {
                    cameraPos.y = 2f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    dialogue.text = "";
                    camera.backgroundColor = night;
                }
                else if (Mathf.Approximately(cameraPos.z, -10.8f) && Mathf.Approximately(cameraPos.x, 5.4f) && cameraPos.y == 50f)
                {
                    cameraPos.y = 2f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    dialogue.text = "";
                    camera.backgroundColor = night;
                }
                if (Mathf.Approximately(cameraPos.z, 17f) && Mathf.Approximately(cameraPos.x, 0f) && tutorial)
                {
                    cameraPos.y = 0f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    fairy.transform.localPosition = new Vector3(-2f, 1.4f, 1f);
                    fairy.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                    tutorial = false;
                    dialogue.text = "";
                }
                else if (tutorial && cameraPos.y == 24)
                {
                    cameraPos.y = 0f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    dialogue.text = "";
                    tutorial = false;
                    FairyAnimation.CorrectAnswer();
                    fairy.SetActive(true);
                    fairy.transform.localPosition = new Vector3(-2f, 1.4f, 1f);
                    fairy.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                }
                else
                {
                    FairyAnimation.IncorrectAnswer();
                }
            }
        }
    }
    public void HelloSue()
    {
        if (cameraPos.z == 17f && cameraPos.x == 5.4f && y == 12f)
        {
            if (helloHold)
            {
                if (!GameControl.mayCard.activeSelf)
                {
                    GameControl.mayCard.SetActive(true);
                    SoundManager.playCardAppearSound();
                }
                y = 22f;
                camera.transform.position = new Vector3(x, y, z);
                dialogue.text = "Hi, I'm May.";

                GameControl.helloCard.GetComponent<Image>().color = Color.white;
                helloHold = false;
            }
            else
            {
                Restart();
            }
        }
        else
        {
            Restart();
        }
    }
    public void HelloMay()
    {
        if (cameraPos.z == 17f && cameraPos.x == 5.4f && y == 22f)
        {
            if (helloHold)
            {
                if (!GameControl.theCard.activeSelf)
                {
                    GameControl.theCard.SetActive(true);
                    SoundManager.playCardAppearSound();
                }
                y = 0f;
                camera.transform.position = new Vector3(x, y, z);
                dialogue.text = "";

                GameControl.helloCard.GetComponent<Image>().color = Color.white;
                helloHold = false;
            }
            else
            {
                Restart();
            }
        }
        else
        {
            Restart();
        }
    }

    public void SorryCard()
    {
        dialogue.text = "Return to the Academy immediately.";
        if (!GameControl.theCard.activeSelf)
        {
            GameControl.theCard.SetActive(true);
            SoundManager.playCardAppearSound();
        }
    }

    public void GirlCard()
    {
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f) && Mathf.Approximately(cameraPos.y, 12f))
        {
            dialogue.text = "Et quel âge as-tu?";
            SpellbookButtonRight();
            GameControl.oneCard.GetComponent<Button>().interactable = true;
            GameControl.oneCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.twoCard.GetComponent<Button>().interactable = true;
            GameControl.twoCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.threeCard.GetComponent<Button>().interactable = true;
            GameControl.threeCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.fourCard.GetComponent<Button>().interactable = true;
            GameControl.fourCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.fiveCard.GetComponent<Button>().interactable = true;
            GameControl.fiveCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.sixCard.GetComponent<Button>().interactable = true;
            GameControl.sixCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.sevenCard.GetComponent<Button>().interactable = true;
            GameControl.sevenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.eightCard.GetComponent<Button>().interactable = true;
            GameControl.eightCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.nineCard.GetComponent<Button>().interactable = true;
            GameControl.nineCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.tenCard.GetComponent<Button>().interactable = true;
            GameControl.tenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.elevenCard.GetComponent<Button>().interactable = true;
            GameControl.elevenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.twelveCard.GetComponent<Button>().interactable = true;
            GameControl.twelveCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.thirteenCard.GetComponent<Button>().interactable = true;
            GameControl.thirteenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.fourteenCard.GetComponent<Button>().interactable = true;
            GameControl.fourteenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.fifteenCard.GetComponent<Button>().interactable = true;
            GameControl.fifteenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.sixteenCard.GetComponent<Button>().interactable = true;
            GameControl.sixteenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.seventeenCard.GetComponent<Button>().interactable = true;
            GameControl.seventeenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.eighteenCard.GetComponent<Button>().interactable = true;
            GameControl.eighteenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.nineteenCard.GetComponent<Button>().interactable = true;
            GameControl.nineteenCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.twentyCard.GetComponent<Button>().interactable = true;
            GameControl.twentyCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        }
    }

    public void BoyCard()
    {
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f) && Mathf.Approximately(cameraPos.y, 12f))
        {
            dialogue.text = "Et quel âge as-tu?";
            SpellbookButtonRight();
            // if (!GameControl.noCard.activeSelf)
            // {
            //     GameControl.noCard.SetActive(true);
            //     SoundManager.playCardAppearSound();
            // }
        }
    }

    public void SitCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f) && Mathf.Approximately(cameraPos.y, 80f))
            {
                dialogue.text = "Thank you.\nWhat is your name?";
                SoundManager.playSecretaryTalk03Sound();
            }
            GameControl.sceneTwo = GameControl.sceneTwo + 1;
            GameControl.Save();
            secretaryCloseUp.sprite = secretarySprite02;

            ControlButton();
            ShowLetterCards();
            //  SpellbookButtonRight();

            GameControl.ShowSideArrows();
            GameControl.HideCardToggles();
            FairyAnimation.CorrectAnswer();
        }
    }

    public static void MorningCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f))
            {
                //  if (goodHold)
                //  {
                if (timeOfDay == "morning")
                {
                    dialogue.text = "Sit down please.";
                    SoundManager.playSecretaryTalk02Sound();
                    GameControl.sitCard.GetComponent<Button>().interactable = true;
                    GameControl.sitCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.goodCard.GetComponent<Image>().color = Color.white;
                    SoundManager.playCardAppearSound();

                    secretary.sprite = secretarySprite02;
                    FairyAnimation.CorrectAnswer();
                }
                else
                {
                    FairyAnimation.IncorrectAnswer();
                }
                //  }
                // else
                // {
                //     FairyAnimation.IncorrectAnswer();
                // }
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
            }
        }
    }

    public static void AfternoonCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f))
            {
                // if (goodHold)
                // {
                if (timeOfDay == "afternoon")
                {
                    dialogue.text = "Sit down please.";
                    SoundManager.playSecretaryTalk02Sound();
                    GameControl.sitCard.GetComponent<Button>().interactable = true;
                    GameControl.sitCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.goodCard.GetComponent<Image>().color = Color.white;
                    SoundManager.playCardAppearSound();

                    secretary.sprite = secretarySprite02;
                    FairyAnimation.CorrectAnswer();
                }
                else
                {
                    FairyAnimation.IncorrectAnswer();
                }
                // }
                // else
                // {
                //     FairyAnimation.IncorrectAnswer();
                // }
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
            }
        }
    }
    public static void EveningCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f))
            {
                // if (goodHold)
                // {
                if (timeOfDay == "evening")
                {
                    dialogue.text = "Sit down please.";
                    SoundManager.playSecretaryTalk02Sound();
                    GameControl.sitCard.GetComponent<Button>().interactable = true;
                    GameControl.sitCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.goodCard.GetComponent<Image>().color = Color.white;
                    SoundManager.playCardAppearSound();

                    secretary.sprite = secretarySprite02;
                    FairyAnimation.CorrectAnswer();
                }
                else
                {
                    FairyAnimation.IncorrectAnswer();
                }
                // }
                // else
                // {
                //     FairyAnimation.IncorrectAnswer();
                // }
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
            }
        }
    }


    public void EndCard()
    {
        if (!CardMoveToggle.toggle.isOn)
        {
            var aArray = GameObject.FindGameObjectsWithTag("a");
            foreach (GameObject item in aArray)
            {
                Destroy(item);
            }

            var bArray = GameObject.FindGameObjectsWithTag("b");
            foreach (GameObject item in bArray)
            {
                Destroy(item);
            }

            var cArray = GameObject.FindGameObjectsWithTag("c");
            foreach (GameObject item in cArray)
            {
                Destroy(item);
            }

            var dArray = GameObject.FindGameObjectsWithTag("d");
            foreach (GameObject item in dArray)
            {
                Destroy(item);
            }

            var eArray = GameObject.FindGameObjectsWithTag("e");
            foreach (GameObject item in eArray)
            {
                Destroy(item);
            }

            var fArray = GameObject.FindGameObjectsWithTag("f");
            foreach (GameObject item in fArray)
            {
                Destroy(item);
            }

            var gArray = GameObject.FindGameObjectsWithTag("g");
            foreach (GameObject item in gArray)
            {
                Destroy(item);
            }

            var hArray = GameObject.FindGameObjectsWithTag("h");
            foreach (GameObject item in hArray)
            {
                Destroy(item);
            }

            var iArray = GameObject.FindGameObjectsWithTag("i");
            foreach (GameObject item in iArray)
            {
                Destroy(item);
            }

            var jArray = GameObject.FindGameObjectsWithTag("j");
            foreach (GameObject item in jArray)
            {
                Destroy(item);
            }

            var kArray = GameObject.FindGameObjectsWithTag("k");
            foreach (GameObject item in kArray)
            {
                Destroy(item);
            }

            var lArray = GameObject.FindGameObjectsWithTag("l");
            foreach (GameObject item in lArray)
            {
                Destroy(item);
            }

            var mArray = GameObject.FindGameObjectsWithTag("m");
            foreach (GameObject item in mArray)
            {
                Destroy(item);
            }

            var nArray = GameObject.FindGameObjectsWithTag("n");
            foreach (GameObject item in nArray)
            {
                Destroy(item);
            }

            var oArray = GameObject.FindGameObjectsWithTag("o");
            foreach (GameObject item in oArray)
            {
                Destroy(item);
            }

            var pArray = GameObject.FindGameObjectsWithTag("p");
            foreach (GameObject item in pArray)
            {
                Destroy(item);
            }

            var qArray = GameObject.FindGameObjectsWithTag("q");
            foreach (GameObject item in qArray)
            {
                Destroy(item);
            }

            var rArray = GameObject.FindGameObjectsWithTag("r");
            foreach (GameObject item in rArray)
            {
                Destroy(item);
            }

            var sArray = GameObject.FindGameObjectsWithTag("s");
            foreach (GameObject item in sArray)
            {
                Destroy(item);
            }

            var tArray = GameObject.FindGameObjectsWithTag("t");
            foreach (GameObject item in tArray)
            {
                Destroy(item);
            }

            var uArray = GameObject.FindGameObjectsWithTag("u");
            foreach (GameObject item in uArray)
            {
                Destroy(item);
            }

            var vArray = GameObject.FindGameObjectsWithTag("v");
            foreach (GameObject item in vArray)
            {
                Destroy(item);
            }

            var wArray = GameObject.FindGameObjectsWithTag("w");
            foreach (GameObject item in wArray)
            {
                Destroy(item);
            }

            var xArray = GameObject.FindGameObjectsWithTag("x");
            foreach (GameObject item in xArray)
            {
                Destroy(item);
            }

            var yArray = GameObject.FindGameObjectsWithTag("y");
            foreach (GameObject item in yArray)
            {
                Destroy(item);
            }

            var zArray = GameObject.FindGameObjectsWithTag("z");
            foreach (GameObject item in zArray)
            {
                Destroy(item);
            }

            if (Mathf.Approximately(cameraPos.z, 5.4f) && Mathf.Approximately(cameraPos.x, -5.4f) && Mathf.Approximately(cameraPos.y, 80f))
            {
                if (WriteLetters.playerNameString.Length > 0)
                {
                    string text = "And how old are you, " + WriteLetters.playerNameString + "?";
                    SoundManager.playSecretaryTalk04Sound();
                    dialogue.text = text;
                    GameControl.playerName = WriteLetters.playerNameString;
                    GameControl.cardMoveToggle.SetActive(true);
                    GameControl.ShowCardToggles();
                    // SpellbookButtonRight();
                    ShowNumberCards();
                }
                else
                {
                    dialogue.text = "Sorry, I didn't get that.";
                }
            }
        }
    }

    public void OneCard()
    {
        playerAge0 = 1;
    }
    public void OneCardHold()
    {
        oneHold = true;
        playerAge10 = 10;
        GameControl.oneCard.GetComponent<Image>().color = Color.gray;
    }

    public void TwoCard()
    {
        playerAge0 = 2;
    }
    public void TwoCardHold()
    {
        twoHold = true;
        playerAge10 = 20;
        GameControl.twoCard.GetComponent<Image>().color = Color.gray;
    }
    public void ThreeCard()
    {
        playerAge0 = 3;
    }
    public void ThreeCardHold()
    {
        threeHold = true;
        playerAge10 = 30;
        GameControl.threeCard.GetComponent<Image>().color = Color.gray;
    }
    public void FourCard()
    {
        playerAge0 = 4;
    }
    public void FourCardHold()
    {
        fourHold = true;
        playerAge10 = 40;
        GameControl.fourCard.GetComponent<Image>().color = Color.gray;
    }

    public void FiveCard()
    {
        playerAge0 = 5;
    }
    public void FiveCardHold()
    {
        fiveHold = true;
        playerAge10 = 50;
        GameControl.fiveCard.GetComponent<Image>().color = Color.gray;
    }

    public void SixCard()
    {
        playerAge0 = 6;
    }

    public void SixCardHold()
    {
        sixHold = true;
        playerAge10 = 60;
        GameControl.sixCard.GetComponent<Image>().color = Color.gray;
    }
    public void SevenCard()
    {
        playerAge0 = 7;
    }

    public void SevenCardHold()
    {
        sevenHold = true;
        playerAge10 = 70;
        GameControl.sevenCard.GetComponent<Image>().color = Color.gray;
    }
    public void EightCard()
    {
        playerAge0 = 8;
    }

    public void EightCardHold()
    {
        eightHold = true;
        playerAge10 = 80;
        GameControl.eightCard.GetComponent<Image>().color = Color.gray;
    }
    public void NineCard()
    {
        playerAge0 = 9;
    }

    public void NineCardHold()
    {
        nineHold = true;
        playerAge10 = 90;
        GameControl.nineCard.GetComponent<Image>().color = Color.gray;
    }

    public void ZeroCard()
    {
        playerAge0 = 0;
    }

    public void GiveAge()
    {
        playerAge = playerAge0 + playerAge10;
        dialogue.text = "OK, welcome to the Academy.";
        SoundManager.playSecretaryTalk05Sound();
        GameControl.playerAge = playerAge;
        ShowRegularCards();
        GameControl.readCard.GetComponent<Button>().interactable = true;
        GameControl.readCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        SoundManager.playCardAppearSound();
        secretaryCloseUp.sprite = secretarySprite03;
    }

    public void Restart()
    {
        GameControl.Restart();
        SceneManager.LoadScene("Academy");
    }

    public void Reset()
    {
        GameControl.sceneOne = 1;
        GameControl.sceneTwo = 1;
        GameControl.hasGoodCard = false;
        GameControl.hasYesCard = false;


        GameControl.Save();
    }
}