using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Academy : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    float z = -10;
    float y = 0;
    float x = 0;
    string direction, scene;
    Text dialogue;
    int textNumber;
    bool isFrontDoorClosed = true;
    bool isRoomsDoorClosed = true;
    GameObject page1, page2;

    SpriteRenderer frontDoorway, roomsDoorway;
    Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed;
    public static bool helloHold;

    //--

    public GameObject teacher;
    public GameObject[] openings;
    public bool canWalkThroughNextWall;


    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
        direction = "north";

        dialogue = GameObject.Find("Text").GetComponent<Text>();
        dialogue.text = "";

        page1 = GameObject.Find("Page1");
        page2 = GameObject.Find("Page2");

        if (GameControl.scene == "Academy")
        {
            frontDoorway = GameObject.Find("View03").GetComponent<SpriteRenderer>();
            frontDoorOpen = Resources.Load<Sprite>("Views/Academy/OutsideAcademyView03b");
            roomsDoorway = GameObject.Find("View21").GetComponent<SpriteRenderer>();
            roomsDoorOpen = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05b");
            roomsDoorClosed = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05");
        }

        if (GameControl.scene == "Academy Wild Area")
        {

            // check which are doorways
            Invoke("CheckWalk", 1f);
        }
    }

    void CheckWalk()
    {
        // -- 
        // Teacher character 

        Debug.Log("CheckWalk");
        teacher = GameObject.FindGameObjectWithTag("Teacher");

        // walls
        openings = GameObject.FindGameObjectsWithTag("CanWalkThrough");
        CheckWalls();

        //- move camera also
        camera.transform.position = new Vector3(0, 0, 0);
        cameraPos = camera.transform.position;


    }
    public void CheckWalls()
    {
        canWalkThroughNextWall = false;

        for (int i = 0; i < openings.Length; i++)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(openings[i].transform.position);

            if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalkThroughNextWall = true;
            }
        }
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

        if (GameControl.scene == "Academy")
        {
            SoundManager.playFootstepSound();
            if (direction == "north")
            {
                if (cameraPos.z < -4 && cameraPos.x == 0)
                {
                    z += 5.4f;
                    camera.transform.position = new Vector3(x, 0, z);
                    cameraPos = camera.transform.position;
                }

                else if (cameraPos.z > 6.1f && cameraPos.x == 5.4f)
                {
                    GameControl.scene = "Academy Wild Area";
                    SceneManager.LoadScene("AcademyWildArea");
                    Start();
                }

                else if (cameraPos.z < 18 && cameraPos.x == 0 && !isFrontDoorClosed)
                {
                    z += 5.4f;
                    camera.transform.position = new Vector3(x, 0, z);
                    cameraPos = camera.transform.position;

                    OutdoorsAmbientSound.StopOutdoorAmbientSound();
                }

                else if (!isRoomsDoorClosed && cameraPos.z > 6.1 && cameraPos.z < 6.3 && cameraPos.x > 5.3 && cameraPos.x < 5.5)
                {
                    z += 5.4f;
                    camera.transform.position = new Vector3(x, 0, z);
                    cameraPos = camera.transform.position;
                }
                else
                {
                    SoundManager.playDoorClosedSound();
                }
            }

            if (direction == "south")
            {
                if (cameraPos.z > -9 && x == 0)
                {
                    z -= 5.4f;
                    camera.transform.position = new Vector3(0, 0, z);
                    cameraPos = camera.transform.position;
                }
                else if (cameraPos.z > 6.2 && x == -16.2f)
                {
                    z -= 5.4f;
                    camera.transform.position = new Vector3(x, y, z);
                    cameraPos = camera.transform.position;
                }
                else
                {
                    SoundManager.playBumpSound();
                }
            }

            else if (direction == "west")
            {
                if (cameraPos.x > -5.3 && cameraPos.z == -10 || cameraPos.z > 6.1 && cameraPos.z < 6.3 && cameraPos.x > -5.3 || cameraPos.z == 17)
                {
                    x -= 5.4f;
                    camera.transform.position = new Vector3(x, 0, z);
                    cameraPos = camera.transform.position;
                }
                else if (cameraPos.z == -10)
                {
                    // SoundManager.playHeySound();
                    SoundManager.playWolfGrowlSound();
                }
                else
                {
                    SoundManager.playBumpSound();
                }
            }

            else if (direction == "east")
            {
                if (cameraPos.x < 5.3 && cameraPos.z == -10 || cameraPos.z == 17 && x < 5.3)
                {
                    x += 5.4f;
                    camera.transform.position = new Vector3(x, 0, z);
                    cameraPos = camera.transform.position;
                }
                else if (cameraPos.z > 6.1 && cameraPos.z < 6.3 && cameraPos.x < 5.3)
                {
                    x += 5.4f;
                    camera.transform.position = new Vector3(x, 0, z);
                    cameraPos = camera.transform.position;
                }
                else if (cameraPos.z == -10)
                {
                    SoundManager.playWolfGrowlSound();
                }

                else
                {
                    SoundManager.playBumpSound();
                }
            }
        }
        else if (GameControl.scene == "Academy Wild Area")
        {
            if (canWalkThroughNextWall)
            {
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
            }
            CheckWalls();
        }
    }
    public void MoveBackward()
    {
        if (GameControl.scene == "Academy")
        {
            SoundManager.playFootstepSound();

            if (direction == "north" && cameraPos.z > -10f)
            {
                z -= 5.4f;
                camera.transform.position = new Vector3(x, 0, z);
                cameraPos = camera.transform.position;
            }

            else if (direction == "south")
            {
                z += 5.4f;
                camera.transform.position = new Vector3(x, 0, z);
                cameraPos = camera.transform.position;
            }

            else if (direction == "west")
            {
                x += 5.4f;
                camera.transform.position = new Vector3(x, 0, z);
                cameraPos = camera.transform.position;
            }

            else if (direction == "east")
            {
                x -= 5.4f;
                camera.transform.position = new Vector3(x, 0, z);
                cameraPos = camera.transform.position;
            }

            else
            {
                SoundManager.playBumpSound();
            }
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

        if (GameControl.scene == "Academy Wild Area")
        {
            CheckWalls();
        }
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

        if (GameControl.scene == "Academy Wild Area")
        {
            CheckWalls();
        }
    }

    public void TextScrollForward()
    {
        textNumber++;

        if (scene == "Fairy2")
        {

            if (textNumber == 2)
                dialogue.text = "You are about to enter the lands of Artemis.";

            else if (textNumber == 3)
                dialogue.text = "Wait, here she comes...";

            else if (textNumber == 4)
                SceneManager.LoadScene("Artemis");
        }
    }

    public void SpellbookButton()
    {
        SoundManager.playPageTurnSound();

        if (page1.transform.localPosition.x == 0f)
        {
            page1.transform.localPosition = new Vector3(-800f, 0f, 0f);
            page2.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
        else if (page1.transform.localPosition.x == -800f)
        {
            page1.transform.localPosition = new Vector3(0f, 0f, 0f);
            page2.transform.localPosition = new Vector3(800f, 0f, 0f);
        }
    }

    public void HelloCard()
    {
        GameControl.helloCard.GetComponent<Image>().color = Color.white;
        helloHold = false;
        if (GameControl.scene == "Academy")
        {
            if (cameraPos.z == -4.6f && cameraPos.x == 0f)
            {
                scene = "Fairy";
                SoundManager.playHeySound();
                cameraPos.y = 12f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                dialogue.text = "Bonjour.\nComment ça va?";
                if (!GameControl.goodCard.activeSelf)
                {
                    GameControl.goodCard.SetActive(true);
                    SoundManager.playCardAppearSound();
                }
                if (!GameControl.badCard.activeSelf)
                {
                    GameControl.badCard.SetActive(true);
                    SoundManager.playCardAppearSound();
                }
            }

            else if (Mathf.Approximately(cameraPos.z, 6.2f) && Mathf.Approximately(cameraPos.x, -5.4f))
            {
                scene = "Secretary";
                cameraPos.y = 12f;
                camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
                dialogue.text = "Bonjour.\n\n Quel est votre nom?";
                // if (!GameControl.noCard.activeSelf)
                // {
                //     GameControl.noCard.SetActive(true);
                //     SoundManager.playCardAppearSound();
                // }
            }
            else if (cameraPos.z == 11.6f)
            {
                scene = "Fairy";
                y = 12f;
                camera.transform.position = new Vector3(0, y, z);
                dialogue.text = "To use 2 spells, hold down one, then press the second.\n OK?";
                if (!GameControl.okCard.activeSelf)
                {
                    GameControl.okCard.SetActive(true);
                    SoundManager.playCardAppearSound();
                    SpellbookButton();
                }
            }
            else
            {
                Restart();
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
                SpellbookButton();
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
        if (cameraPos.z == -4.6f && cameraPos.x == 0f && cameraPos.y == 12f)
        {
            scene = "Academy";
            cameraPos.y = 0f;
            camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
            dialogue.text = "";
        }
        else if (cameraPos.z == 6.2 && y == 12f)
        {
            scene = "Academy";
            y = 0f;
            camera.transform.position = new Vector3(x, y, z);
            dialogue.text = "";
        }
        else
        {
            Restart();
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
        if (cameraPos.z == -4.6f && cameraPos.x == 0f)
        {
            dialogue.text = "tu sembles perdu";
            if (!GameControl.yesCard.activeSelf)
            {
                GameControl.yesCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
            if (!GameControl.noCard.activeSelf)
            {
                GameControl.noCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
        }

    }
    public void BadCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f)
        {
            dialogue.text = "tu sembles perdu";
            if (!GameControl.noCard.activeSelf)
            {
                GameControl.noCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
            if (!GameControl.yesCard.activeSelf)
            {
                GameControl.yesCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
        }
    }

    public void OpenCard()
    {
        if (Mathf.Approximately(cameraPos.z, 0.8f))
        {
            SoundManager.playDoorOpeningSound();
            frontDoorway.sprite = frontDoorOpen;
            isFrontDoorClosed = false;
            if (!GameControl.yesCard.activeSelf)
            {
                GameControl.yesCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else if (z > 6.1 && z < 6.3 && isRoomsDoorClosed)
        {
            SoundManager.playDoorOpeningSound();
            roomsDoorway.sprite = roomsDoorOpen;
            isRoomsDoorClosed = false;
            if (!GameControl.closeCard.activeSelf)
            {
                GameControl.closeCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
        }
    }

    public void YesCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f)
        {
            if (!GameControl.thankYouCard.activeSelf)
            {
                GameControl.thankYouCard.SetActive(true);
                SoundManager.playCardAppearSound();

                dialogue.text = "Allez voir le professeur, droit et à gauche.";
            }
            if (!GameControl.openCard.activeSelf)
            {
                GameControl.openCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
        }
    }
    public void NoCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f)
        {
            if (!GameControl.thankYouCard.activeSelf)
            {
                GameControl.thankYouCard.SetActive(true);
                SoundManager.playCardAppearSound();

                dialogue.text = "Allez voir le professeur, droit et à gauche.";
            }
            if (!GameControl.openCard.activeSelf)
            {
                GameControl.openCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
        }
    }

    public void ThankYouCard()
    {
        if (cameraPos.z == -4.6f && cameraPos.x == 0f)
        {
            if (!GameControl.goodbyeCard.activeSelf)
            {
                GameControl.goodbyeCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else if (z > 6.1 && z < 6.3 && y == 21.5f)
        {
            y = 0f;
            camera.transform.position = new Vector3(x, y, z);

            // if (!GameControl.readCard.activeSelf)
            // {
            //     GameControl.readCard.SetActive(true);
            //     SoundManager.playCardAppearSound();
            // }
        }
        else
        {
            Restart();
        }
    }


    public void ReadCard()
    {
        if (z > 6.1 && z < 6.3)
        {
            scene = "Scroll";

            y = 12f;
            camera.transform.position = new Vector3(x, y, z);
            if (!GameControl.stopCard.activeSelf)
            {
                GameControl.stopCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
        }
    }

    public void StopCard()
    {
        if (z > 6.1 && z < 6.3)
        {
            scene = "Academy";

            y = 0f;
            camera.transform.position = new Vector3(x, y, z);
            if (!GameControl.byeCard.activeSelf)
            {
                GameControl.byeCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else
        {
            Restart();
        }
    }

    public void CloseCard()
    {
        if (z > 6.1 && z < 6.3 && !isRoomsDoorClosed)
        {
            SoundManager.playDoorOpeningSound();
            roomsDoorway.sprite = roomsDoorClosed;
            isRoomsDoorClosed = true;
            if (!GameControl.hiCard.activeSelf)
            {
                GameControl.hiCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
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
            scene = "Students";

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
            scene = "Academy";
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
                scene = "Academy";

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


    public void Restart()
    {
        GameControl.Restart();
        SceneManager.LoadScene("Academy");
    }

}