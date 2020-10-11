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

    void Start()
    {

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
        direction = "north";

        dialogue = GameObject.Find("Text").GetComponent<Text>();
        dialogue.text = "";

        page1 = GameObject.Find("Page1");
        page2 = GameObject.Find("Page2");

        scene = "Academy";

        frontDoorway = GameObject.Find("View03").GetComponent<SpriteRenderer>();
        frontDoorOpen = Resources.Load<Sprite>("Views/Academy/OutsideAcademyView03b");
        roomsDoorway = GameObject.Find("View21").GetComponent<SpriteRenderer>();
        roomsDoorOpen = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05b");
        roomsDoorClosed = Resources.Load<Sprite>("Views/Academy/InsideAcademyView05");

    }

    public void MoveForward()
    {

        // Debug.Log(cameraPos.x);
        // Debug.Log(cameraPos.y);
        // Debug.Log(cameraPos.z);
        // Debug.Log(x);
        // Debug.Log(y);
        // Debug.Log(z);

        if (scene == "Academy")
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
    }
    public void MoveBackward()
    {
        if (scene == "Academy")
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
        if (scene == "Academy")
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
        }
        else if (scene == "Fairy")
        {

        }
    }
    public void RightButton()
    {
        if (scene == "Academy")
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
        }
        // else if (scene == "Fairy" || scene == "Artemis" || scene == "Fairy2")
        // {
        //     TextScrollForward();
        // }
    }

    public void TextScrollForward()
    {
        textNumber++;

        // if (scene == "Fairy")
        // {
        //     if (textNumber == 2)
        //         dialogue.text = "Below is your spellbook.";

        //     else if (textNumber == 3)
        //     {
        //         SoundManager.playDoorSound();
        //         dialogue.text = "So far, you have a greeting spell. I will give you one to open doors also.";
        //         GameControl.doorCard.SetActive(true);
        //         SoundManager.playCardAppearSound();
        //     }

        //     else if (textNumber == 4)
        //         dialogue.text = "You will need to collect and use spells in order to escape the Labyrinth. Be careful, using the wrong spell at the wrong place can result in an early demise.";

        //     else if (textNumber == 5)
        //     {
        //         SoundManager.playGoodbyeSound();
        //         dialogue.text = "Goodbye.";
        //         GameControl.goodbyeCard.SetActive(true);
        //         SoundManager.playCardAppearSound();
        //     }
        // }
        //else 
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
        if (z > -4.7 && z < -4.5 && y == 0f)
        {
            textNumber = 1;

            scene = "Fairy";
            SoundManager.playHeySound();
            y = 12f;
            camera.transform.position = new Vector3(0, y, z);
            if (!GameControl.goodbyeCard.activeSelf)
                dialogue.text = "Hello.";
            if (!GameControl.goodbyeCard.activeSelf)
            {
                GameControl.goodbyeCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }

        else if (z > 6.1 && z < 6.3 && x < -5.3 && x > -5.5)
        {
            textNumber = 1;

            scene = "Secretary";
            y = 12f;
            camera.transform.position = new Vector3(x, y, z);
            dialogue.text = "Hello.\n Are you lost?";
            if (!GameControl.noCard.activeSelf)
            {
                GameControl.noCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else if (cameraPos.z == 11.6f)
        {
            scene = "Fairy";
            y = 12f;
            camera.transform.position = new Vector3(0, y, z);
            dialogue.text = "Turn the page to access new spells.\n OK?";
            if (!GameControl.okCard.activeSelf)
            {
                GameControl.okCard.SetActive(true);
                SoundManager.playCardAppearSound();
                SpellbookButton();
            }
        }

        // else if (x < -16.1 && x > -16.3)
        // {
        //     textNumber = 1;

        //     scene = "Artemis";
        //     y = 12f;
        //     camera.transform.position = new Vector3(0, y, z);
        //     dialogue.text = "Hello, I am Artemis, Queen of the Animals.";
        // }

        else
        {
            Restart();
        }
    }

    public void GoodbyeCard()
    {
        if (z > -4.7 && z < -4.5 && y == 12f)
        {
            scene = "Academy";

            y = 0f;
            camera.transform.position = new Vector3(x, y, z);

            dialogue.text = "";

            if (!GameControl.openCard.activeSelf)
            {
                GameControl.openCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }
        }
        else if (z > 6.1 && z < 6.3 && y == 12f)
        {
            scene = "Academy";
            y = 0f;
            camera.transform.position = new Vector3(x, y, z);
            dialogue.text = "";

            // if (!GameControl.hiCard.activeSelf)
            // {
            //     SpellbookButton();
            //     GameControl.hiCard.SetActive(true);
            //     SoundManager.playCardAppearSound();

            //     y = 21.5f;
            //     camera.transform.position = new Vector3(x, y, z);
            //     dialogue.text = "Hey! You can turn the pages of your spellbook with the book button.";
            //     SoundManager.playHeySound();
            // }
        }
        else
        {
            Restart();
        }
    }

    public void OpenCard()
    {
        if (z > 0.7 && z < 0.9)
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
        if (z > 6.1 && z < 6.3)
        {
            if (!GameControl.thankYouCard.activeSelf)
            {
                GameControl.thankYouCard.SetActive(true);
                SoundManager.playCardAppearSound();

                dialogue.text = "Well, read the sign.";
            }
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

    public void ThankYouCard()
    {
        if (z > 6.1 && z < 6.3 && y == 12f)
        {
            if (!GameControl.readCard.activeSelf)
            {
                GameControl.readCard.SetActive(true);
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
    public void HiCard()
    {
        if (cameraPos.z == 17f && cameraPos.x == 5.4f)
        {
            scene = "Students";

            y = 12f;
            camera.transform.position = new Vector3(x, y, z);
            dialogue.text = "Hi. I'm Sue.";

            if (!GameControl.niceToMeetYouTooCard.activeSelf)
            {
                GameControl.niceToMeetYouTooCard.SetActive(true);
                SoundManager.playCardAppearSound();
            }

            // if (!GameControl.niceCard.activeSelf)
            // {
            //     GameControl.niceCard.SetActive(true);
            //     SoundManager.playCardAppearSound();
            // }
            // if (!GameControl.toCard.activeSelf)
            // {
            //     GameControl.toCard.SetActive(true);
            //     SoundManager.playCardAppearSound();
            // }
            // if (!GameControl.meetCard.activeSelf)
            // {
            //     GameControl.meetCard.SetActive(true);
            //     SoundManager.playCardAppearSound();
            // }
            // if (!GameControl.youCard.activeSelf)
            // {
            //     GameControl.youCard.SetActive(true);
            //     SoundManager.playCardAppearSound();
            // }
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
    public void NiceToMeetYouCard()
    {
        if (cameraPos.z == 17f && cameraPos.x == 5.4f && y == 12f)
        {
            Debug.Log("test");
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


    public void Restart()
    {
        GameControl.Restart();
        SceneManager.LoadScene("Academy");
    }
}