using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TheWilds : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    public static string direction;
    static Text dialogue;
    public static int roundNumber;
    public static GameObject speechPages, actionPages, letterPages, numberPages, speechTabletop, actionTabletop;
    static Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed, secretarySprite, secretarySprite01, secretarySprite02, secretarySprite03, fairyInTreeNoFairy, controlSprite01, controlSprite02, controlSprite03, controlSprite04, fairyNeutralSprite, wolfSprite, dinoSprite, doorCardSprite, youCardSprite, student06Sprite, student01Sprite, hiCardSprite, evaCardSprite;
    public Transform helloCard, howCard, areCard, youCard, questionMarkCard, canCard, notCard, passCard, lostCard, goCard, throughCard, theCard, doorCard, hiCard, whatCard, isCard, yourCard, nameCard, iCard, askedCard, fromCard, hereCard, amCard, evaCard, niceCard, toCard, meetCard;
    static string timeOfDay, playerName;
    int playerAge, controlNumber = 0;
    public GameObject[] openings, solidObjects;
    public bool canWalk;
    public static bool inInteraction;
    GameObject fairy;
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

        speechPages = GameObject.Find("SpeechPages");
        actionPages = GameObject.Find("ActionPages");
        letterPages = GameObject.Find("LetterPages");
        numberPages = GameObject.Find("NumberPages");

        speechTabletop = GameObject.Find("SpeechTabletop");
        actionTabletop = GameObject.Find("ActionTabletop");

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
        //  Debug.Log("CheckWalk");
        solidObjects = GameObject.FindGameObjectsWithTag("CantWalkThrough");
        CheckWalls();
    }
    public void CheckWalls()
    {
        canWalk = false;

        for (int i = 0; i < solidObjects.Length; i++)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(solidObjects[i].transform.position);
            //        Debug.Log(viewPos);

            if (viewPos.z > 5.3f && viewPos.z < 5.5f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalk = true;
            }
            else if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalk = true;
            }
        }
        //    Debug.Log(canWalk);
    }
    public void MoveForward()
    {
        print(direction);
        //    if (canWalk == true)
        //    {
        SoundManager.playFootstepSound();

        if (direction == "north")
        {
            cameraPos.z += 5.4f;
            camera.transform.localPosition = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            cameraPos = camera.transform.localPosition;
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
        //    }
        //    else
        //       SoundManager.playBumpSound();

        CheckWalls();
    }

    public void LeftButton()
    {
        if (controlNumber == 0)
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
        if (controlNumber == 0)
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
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, 0f, 0f);
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, -500f, 0f);
            }
            if (controlNumber == 2)
            {
                GameControl.HideArrows();
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, 0f, 0f);
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, -550f, 0f);
            }
            if (controlNumber == 0)
            {
                GameControl.ShowArrows();
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
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, 0f, 0f);
                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, -500f, 0f);
            }
            if (controlNumber == 2)
            {
                GameControl.HideArrows();

                actionPages.transform.localPosition = new Vector3(actionPages.transform.localPosition.x, 0f, 0f);
                speechPages.transform.localPosition = new Vector3(speechPages.transform.localPosition.x, -550f, 0f);
            }
        }
    }

    public void Go()
    {
        int speechTableTopCount = speechTabletop.transform.childCount;
        int actionTableTopCount = actionTabletop.transform.childCount;

        if (cameraPos.z == -10.8f && cameraPos.x == -10.8f && direction == "west")
        {
            inInteraction = true;
            if (speechTableTopCount == 1 && speechTabletop.transform.GetChild(0).gameObject.name == "HelloCard" && roundNumber == 0)
            {
                print("test");
                roundNumber++;
            }
        }
    }

    public void RunAway()
    {
        GameControl.BlackBG();
    }
}