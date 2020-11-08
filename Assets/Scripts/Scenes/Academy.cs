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
    string direction;
    Text dialogue;
    int textNumber;
    bool isRoomsDoorClosed = true;
    public static GameObject page1, page2, page3, page4, frontDoor, LaboratoryDoor;
    SpriteRenderer frontDoorway, roomsDoorway, secretary;
    Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed, secretarySprite02, secretarySprite03, fairyInTreeNoFairy;
    public static bool helloHold, goodHold, oneHold, twoHold, threeHold, fourHold, fiveHold, sixHold, sevenHold, eightHold, nineHold;

    string timeOfDay, playerName;
    int playerAge, playerAge0, playerAge10 = 0;

    //--

    public GameObject teacher;
    public GameObject[] openings;
    public bool canWalkThroughNextWall, canWalkThroughPreviousWall;


    GameObject fairy, fairyInTree;
    Animation fairyAnimation;
    void Start()
    {
        DateTime time = System.DateTime.Now;
        string dateAndTimeVar = time.ToString("yyyy/MM/dd HH:mm:ss");
        print(dateAndTimeVar);
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

        page1 = GameObject.Find("Page1");
        page2 = GameObject.Find("Page2");
        page3 = GameObject.Find("Page3");
        page4 = GameObject.Find("Page4");
        frontDoor = GameObject.Find("FrontDoor");
        LaboratoryDoor = GameObject.Find("LaboratoryDoor");

        if (GameControl.scene == "Academy")
        {
            frontDoorway = GameObject.Find("FrontDoor").GetComponent<SpriteRenderer>();
            frontDoorOpen = Resources.Load<Sprite>("Views/Academy/OutsideAcademyView03b");
            roomsDoorway = GameObject.Find("LaboratoryDoor").GetComponent<SpriteRenderer>();
            roomsDoorOpen = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05b");
            roomsDoorClosed = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05");
            fairyInTreeNoFairy = Resources.Load<Sprite>("Fairy_on_tree-no_Fairy");
            fairyInTree = GameObject.FindWithTag("Fairy in tree");
            fairy = GameObject.FindWithTag("Fairy");
            fairy.SetActive(false);
        }

        secretary = GameObject.Find("Secretary02").GetComponent<SpriteRenderer>();
        secretarySprite02 = Resources.Load<Sprite>("Foyer/Secretary02");
        secretarySprite03 = Resources.Load<Sprite>("Foyer/Secretary03");

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
        openings = GameObject.FindGameObjectsWithTag("CanWalkThrough");
        CheckWalls();

        //- move camera also
        //  camera.transform.position = new Vector3(0, 0, 0);
        //  cameraPos = camera.transform.position;


    }
    public void CheckWalls()
    {
        canWalkThroughNextWall = false;
        canWalkThroughPreviousWall = false;

        for (int i = 0; i < openings.Length; i++)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(openings[i].transform.position);
            // Vector3 rearViewPos = camera.WorldToViewportPoint(openings[i].transform.position) + new Vector3(0, 0, -5.4f);
            // Debug.Log(viewPos);

            if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalkThroughNextWall = true;
            }

            // if (rearViewPos.z < -2.6f && rearViewPos.z > -2.8f && rearViewPos.x > 0.4f && rearViewPos.x < 0.6f)
            // {
            //     canWalkThroughPreviousWall = true;
            // }
        }
        //  Debug.Log(canWalkThroughNextWall);
        // Debug.Log(canWalkThroughPreviousWall);
    }
    public void MoveForward()
    {
        // Debug.Log(cameraPos.x);
        // Debug.Log(cameraPos.y);
        // Debug.Log(cameraPos.z);
        // Debug.Log(x);
        // Debug.Log(y);
        // Debug.Log(z);        
        // Debug.Log(GameControl.scene);

        // if (GameControl.scene == "Academy")
        // {
        //     SoundManager.playFootstepSound();
        //     if (direction == "north")
        //     {
        //         if (cameraPos.z < -4 && cameraPos.x == 0)
        //         {
        //             z += 5.4f;
        //             camera.transform.position = new Vector3(x, 0, z);
        //             cameraPos = camera.transform.position;
        //         }

        //         else if (cameraPos.z > 6.1f && cameraPos.z < 11.6f && cameraPos.x == 5.4f)
        //         {
        //             GameControl.scene = "Academy Wild Area";
        //             SceneManager.LoadScene("AcademyWildArea");
        //             Start();
        //         }

        //         else if (cameraPos.z < 18 && cameraPos.x == 0 && !isFrontDoorClosed)
        //         {
        //             z += 5.4f;
        //             camera.transform.position = new Vector3(x, 0, z);
        //             cameraPos = camera.transform.position;

        //             OutdoorsAmbientSound.StopOutdoorAmbientSound();
        //         }

        //         else if (cameraPos.z < 18f && cameraPos.x < 5.5f && cameraPos.x > -16.3f)
        //         {
        //             cameraPos.z += 5.4f;
        //             camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        //             cameraPos = camera.transform.position;
        //         }
        //         else
        //         {
        //             SoundManager.playDoorClosedSound();
        //         }
        //     }

        //     if (direction == "south")
        //     {
        //         if (cameraPos.z > -9 && x == 0)
        //         {
        //             z -= 5.4f;
        //             camera.transform.position = new Vector3(0, 0, z);
        //             cameraPos = camera.transform.position;
        //         }
        //         else if (cameraPos.z > 6.2 && x == -16.2f)
        //         {
        //             z -= 5.4f;
        //             camera.transform.position = new Vector3(x, y, z);
        //             cameraPos = camera.transform.position;
        //         }
        //         else
        //         {
        //             SoundManager.playBumpSound();
        //         }
        //     }

        //     else if (direction == "west")
        //     {
        //         if (cameraPos.x > -5.3f && cameraPos.z == -10f || cameraPos.z == 6.2f && cameraPos.x > -5.3f || cameraPos.z == 17f && cameraPos.x > -10.9f || cameraPos.z == 22.4f && cameraPos.x > -10.9f)
        //         {
        //             cameraPos.x -= 5.4f;
        //             camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        //             cameraPos = camera.transform.position;
        //         }
        //         else if (cameraPos.z == -10)
        //         {
        //             // SoundManager.playHeySound();
        //             SoundManager.playWolfGrowlSound();
        //         }
        //         else
        //         {
        //             SoundManager.playBumpSound();
        //         }
        //     }

        //     else if (direction == "east")
        //     {
        //         if (cameraPos.x < 5.3f && cameraPos.z == -10f || cameraPos.z == 17f && x < 5.3f || cameraPos.z == 22.4f && x < 5.3f)
        //         {
        //             cameraPos.x += 5.4f;
        //             camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        //             cameraPos = camera.transform.position;
        //         }
        //         else if (cameraPos.z > 6.1 && cameraPos.z < 6.3 && cameraPos.x < 5.3)
        //         {
        //             x += 5.4f;
        //             camera.transform.position = new Vector3(x, 0, z);
        //             cameraPos = camera.transform.position;
        //         }
        //         else if (cameraPos.z == -10)
        //         {
        //             SoundManager.playWolfGrowlSound();
        //         }

        //         else
        //         {
        //             SoundManager.playBumpSound();
        //         }
        //     }
        // }
        // else if (GameControl.scene == "Academy Wild Area")
        if (GameControl.scene == "Academy")
        {
            if (canWalkThroughNextWall)
            {
                SoundManager.playFootstepSound();
                if (direction == "north")
                {
                    cameraPos.z += 5.4f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    cameraPos = camera.transform.position;

                    if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 0f))
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
                }
                else if (direction == "west")
                {
                    cameraPos.x += -5.4f;
                    camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                    cameraPos = camera.transform.position;
                }
            }

            else if (cameraPos.z == -10f && direction == "east" || cameraPos.z == -10f && direction == "west")
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

        //  if (GameControl.scene == "Academy Wild Area")
        //  {
        CheckWalls();
        //  }
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

        //    if (GameControl.scene == "Academy Wild Area")
        //     {
        CheckWalls();
        //     }
    }


    public void SpellbookButtonRight()
    {
        SoundManager.playPageTurnSound();

        // if (page1.transform.localPosition.x == 0f)
        // {
        //     page1.transform.localPosition = new Vector3(-800f, 0f, 0f);
        //     page2.transform.localPosition = new Vector3(0f, 0f, 0f);
        //     page3.transform.localPosition = new Vector3(800f, 0f, 0f);
        //     page4.transform.localPosition = new Vector3(1600f, 0f, 0f);
        // }
        // else if (page1.transform.localPosition.x == -800f)
        // {
        //     page1.transform.localPosition = new Vector3(-1600f, 0f, 0f);
        //     page2.transform.localPosition = new Vector3(-800f, 0f, 0f);
        //     page3.transform.localPosition = new Vector3(0f, 0f, 0f);
        //     page4.transform.localPosition = new Vector3(800f, 0f, 0f);
        // }
        // else if (page1.transform.localPosition.x == -1600f)
        // {
        //     page1.transform.localPosition = new Vector3(-2400f, 0f, 0f);
        //     page2.transform.localPosition = new Vector3(-1600f, 0f, 0f);
        //     page3.transform.localPosition = new Vector3(-800f, 0f, 0f);
        //     page4.transform.localPosition = new Vector3(0f, 0f, 0f);
        // }
        // else if (page1.transform.localPosition.x == -2400f)
        // {
        //     page1.transform.localPosition = new Vector3(-3200f, 0f, 0f);
        //     page2.transform.localPosition = new Vector3(-2400f, 0f, 0f);
        //     page3.transform.localPosition = new Vector3(-1600f, 0f, 0f);
        //     page4.transform.localPosition = new Vector3(-800f, 0f, 0f);
        // }
        page1.transform.localPosition = new Vector3(-540, 0f, 0f) + page1.transform.localPosition;
        page2.transform.localPosition = new Vector3(-540f, 0f, 0f) + page2.transform.localPosition;
        page3.transform.localPosition = new Vector3(-540f, 0f, 0f) + page3.transform.localPosition;
        page4.transform.localPosition = new Vector3(-540f, 0f, 0f) + page4.transform.localPosition;
    }

    public void SpellbookButtonLeft()
    {
        SoundManager.playPageTurnSound();

        page1.transform.localPosition = new Vector3(540f, 0f, 0f) + page1.transform.localPosition;
        page2.transform.localPosition = new Vector3(540f, 0f, 0f) + page2.transform.localPosition;
        page3.transform.localPosition = new Vector3(540f, 0f, 0f) + page3.transform.localPosition;
        page4.transform.localPosition = new Vector3(540f, 0f, 0f) + page4.transform.localPosition;
    }

    public void HelloCard()
    {
        GameControl.hasHelloCard = true;

        GameControl.helloCard.GetComponent<Image>().color = Color.white;
        helloHold = false;
        if (GameControl.scene == "Academy")
        {
            if (cameraPos.z == -4.6f && cameraPos.x == 0f && !fairy.activeSelf)
            {
                GameControl.CharacterSpeakUIChange();

                // first Fairy interaction - sceneOne
                SoundManager.playHeySound();
                cameraPos.y = 12f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                if (GameControl.sceneOne == 1)
                    dialogue.text = "Bonjour.\nComment ça va?";
                else
                    dialogue.text = "Ah,\nvous encore.";

                GameControl.goodCard.GetComponent<Button>().interactable = true;
                GameControl.goodCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                GameControl.badCard.GetComponent<Button>().interactable = true;
                GameControl.badCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                SoundManager.playCardAppearSound();
            }

            else if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f) && cameraPos.y == 0f)
            {
                GameControl.upArrow.GetComponent<Button>().interactable = false;
                GameControl.rightArrow.GetComponent<Button>().interactable = false;
                GameControl.leftArrow.GetComponent<Button>().interactable = false;

                // first Secretary interaction - sceneTwo              
                cameraPos.y = 12f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                if (GameControl.sceneTwo == 1)
                    dialogue.text = "Good " + timeOfDay;
                else
                    dialogue.text = "Es-tu perdu?";

                GameControl.morningCard.GetComponent<Button>().interactable = true;
                GameControl.morningCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                GameControl.afternoonCard.GetComponent<Button>().interactable = true;
                GameControl.afternoonCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                GameControl.eveningCard.GetComponent<Button>().interactable = true;
                GameControl.eveningCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                GameControl.CharacterSpeakUIChange();
                SoundManager.playCardAppearSound();
                FairyAnimation.CorrectAnswer();
            }
            else if (cameraPos.z == 11.6f)
            {
                y = 12f;
                camera.transform.position = new Vector3(0, y, z);
                dialogue.text = "To use 2 spells, hold down one, then press the second.\n OK?";
                if (!GameControl.okCard.activeSelf)
                {
                    GameControl.okCard.SetActive(true);
                    SoundManager.playCardAppearSound();
                    SpellbookButtonRight();
                }
            }
            else
            {
                FairyAnimation.IncorrectAnswer();
                //  Restart();
            }
        }

        else if (GameControl.scene == "Academy Wild Area")
        {
            Vector3 viewPos = camera.WorldToViewportPoint(teacher.transform.position);
            //    / print("x: " + viewPos.x + "y: " + viewPos.y + "z: " + viewPos.z);

            if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                cameraPos.y = 12f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                dialogue.text = "What are you doing here?";

                GameControl.sorryCard.SetActive(true);
                SoundManager.playCardAppearSound();
                SpellbookButtonRight();
            }
        }
    }

    public void HelloCardHold()
    {
        helloHold = true;
        GameControl.helloCard.GetComponent<Image>().color = Color.gray;
    }

    public void GoodbyeCard()
    {
        GameControl.hasGoodbyeCard = true;

        if (cameraPos.z == -4.6f && cameraPos.x == 0f && cameraPos.y == 12f)
        {
            // first Fairy interaction - sceneOne
            GameControl.sceneOne = GameControl.sceneOne + 1;
            GameControl.Save();

            cameraPos.y = 0f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            dialogue.text = "";

            GameControl.WorldNavigationUIChange();

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

    public void GoodCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f && cameraPos.y == 12f)
        {
            dialogue.text = "Es-tu perdu?";
            GameControl.yesCard.GetComponent<Button>().interactable = true;
            GameControl.yesCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.noCard.GetComponent<Button>().interactable = true;
            GameControl.noCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            SoundManager.playCardAppearSound();
            GameControl.hasGoodCard = true;
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

    public void GoodCardHold()
    {
        goodHold = true;
        GameControl.goodCard.GetComponent<Image>().color = Color.gray;
    }

    public void BadCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f && cameraPos.y == 12f)
        {
            dialogue.text = "Es-tu perdu?";
            GameControl.yesCard.GetComponent<Button>().interactable = true;
            GameControl.yesCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.noCard.GetComponent<Button>().interactable = true;
            GameControl.noCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            SoundManager.playCardAppearSound();
        }
        else
        {
            FairyAnimation.IncorrectAnswer();
            //   Restart();
        }
    }

    public void OpenCard()
    {
        if (Mathf.Approximately(cameraPos.z, 0.8f))
        {
            SoundManager.playDoorOpeningSound();
            frontDoorway.sprite = frontDoorOpen;

            frontDoor.tag = "CanWalkThrough";
            CheckWalk();
            FairyAnimation.CorrectAnswer();
        }
        else if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 5.4f) && isRoomsDoorClosed)
        {
            SoundManager.playDoorOpeningSound();
            roomsDoorway.sprite = roomsDoorOpen;
            isRoomsDoorClosed = false;
            LaboratoryDoor.tag = "CanWalkThrough";
            CheckWalk();
            FairyAnimation.CorrectAnswer();
        }
        else
        {
            FairyAnimation.IncorrectAnswer();
            //    Restart();
        }
    }

    public void YesCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f && cameraPos.y == 12f)
        {
            GameControl.thankYouCard.GetComponent<Button>().interactable = true;
            GameControl.thankYouCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.openCard.GetComponent<Button>().interactable = true;
            GameControl.openCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            dialogue.text = "Allez voir le professeur, droit et à gauche.";
            SoundManager.playCardAppearSound();
            GameControl.hasYesCard = true;
        }
        else
        {
            FairyAnimation.IncorrectAnswer();
            //  Restart();
        }
    }
    public void NoCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f && cameraPos.y == 12f)
        {
            GameControl.thankYouCard.GetComponent<Button>().interactable = true;
            GameControl.thankYouCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            GameControl.openCard.GetComponent<Button>().interactable = true;
            GameControl.openCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        }
        else
        {
            FairyAnimation.IncorrectAnswer();
            //    Restart();
        }
    }

    public void ThankYouCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f)
        {
            GameControl.goodbyeCard.GetComponent<Button>().interactable = true;
            GameControl.goodbyeCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        }
        else if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f) && cameraPos.y == 12f)
        {
            dialogue.text = "";
            cameraPos.y = 0f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);

            GameControl.WorldNavigationUIChange();
            FairyAnimation.CorrectAnswer();
        }
        else
        {
            FairyAnimation.IncorrectAnswer();
            //   Restart();
        }
    }

    public void ReadCard()
    {
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 5.4f))
        {
            cameraPos.y = 12f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);

            GameControl.stopCard.GetComponent<Button>().interactable = true;
            GameControl.stopCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
            SoundManager.playCardAppearSound();
        }
        else
        {
            // Restart();
        }
    }

    public void StopCard()
    {
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, 5.4f) && cameraPos.y == 12f)
        {
            cameraPos.y = 0f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        }
        else
        {
            //  Restart();
        }
    }

    public void CloseCard()
    {
        if (z > 6.1 && z < 6.3 && !isRoomsDoorClosed)
        {
            SoundManager.playDoorOpeningSound();
            roomsDoorway.sprite = roomsDoorClosed;
            isRoomsDoorClosed = true;
        }
        else
        {
            Restart();
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
        if (cameraPos.z == 11.6f && cameraPos.x == 0f && y == 12f)
        {
            y = 0f;
            camera.transform.position = new Vector3(x, y, z);
            dialogue.text = "";

            if (!GameControl.sueCard.activeSelf)
            {
                GameControl.sueCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
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
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f) && Mathf.Approximately(cameraPos.y, 12f))
        {
            dialogue.text = "Thank you.\nWhat is your name?";
        }
        GameControl.sceneTwo = GameControl.sceneTwo + 1;
        GameControl.Save();
        secretary.sprite = secretarySprite03;

        SpellbookButtonRight();
        FairyAnimation.CorrectAnswer();
    }

    public void MorningCard()
    {
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f))
        {
            if (goodHold)
            {
                if (timeOfDay == "morning")
                {
                    dialogue.text = "Sit down please.";
                    GameControl.sitCard.GetComponent<Button>().interactable = true;
                    GameControl.sitCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.goodCard.GetComponent<Image>().color = Color.white;
                    SoundManager.playCardAppearSound();

                    secretary.sprite = secretarySprite02;
                    FairyAnimation.CorrectAnswer();
                }
                else
                {
                    Restart();
                }
            }
        }
        else
        {
            Restart();
        }
    }

    public void AfternoonCard()
    {
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f))
        {
            if (goodHold)
            {
                if (timeOfDay == "afternoon")
                {
                    dialogue.text = "Sit down please.";
                    GameControl.sitCard.GetComponent<Button>().interactable = true;
                    GameControl.sitCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.goodCard.GetComponent<Image>().color = Color.white;
                    SoundManager.playCardAppearSound();

                    secretary.sprite = secretarySprite02;
                    FairyAnimation.CorrectAnswer();
                }
                else
                {
                    Restart();
                }
            }
        }
        else
        {
            Restart();
        }
    }
    public void EveningCard()
    {
        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f))
        {
            if (goodHold)
            {
                if (timeOfDay == "evening")
                {
                    dialogue.text = "Sit down please.";
                    GameControl.sitCard.GetComponent<Button>().interactable = true;
                    GameControl.sitCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
                    GameControl.goodCard.GetComponent<Image>().color = Color.white;
                    SoundManager.playCardAppearSound();

                    secretary.sprite = secretarySprite02;
                    FairyAnimation.CorrectAnswer();
                }
                else
                {
                    Restart();
                }
            }
        }
        else
        {
            Restart();
        }
    }


    public void EndCard()
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

        if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f) && Mathf.Approximately(cameraPos.y, 12f))
        {
            if (WriteLetters.playerNameString.Length > 0)
            {
                string text = "And how old are you, " + WriteLetters.playerNameString + "?";
                dialogue.text = text;
                GameControl.playerName = WriteLetters.playerNameString;
                SpellbookButtonRight();
            }
            else
            {
                dialogue.text = "Sorry, I didn't get that.";
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
        SpellbookButtonLeft();
        SpellbookButtonLeft();
        SpellbookButtonLeft();
        GameControl.playerAge = playerAge;

        GameControl.readCard.GetComponent<Button>().interactable = true;
        GameControl.readCard.GetComponent<Image>().CrossFadeAlpha(1, 2.0f, false);
        SoundManager.playCardAppearSound();
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