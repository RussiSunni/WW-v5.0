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
    bool doorClosed = true;

    SpriteRenderer academyDoorway;
    Sprite doorOpen;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
        direction = "north";

        dialogue = GameObject.Find("Text").GetComponent<Text>();
        dialogue.text = "";

        scene = "Academy";

        academyDoorway = GameObject.Find("View03").GetComponent<SpriteRenderer>();
        doorOpen = Resources.Load<Sprite>("Views/Academy/OutsideAcademyView03b");
    }

    public void MoveForward()
    {
        Debug.Log(cameraPos.x);
        Debug.Log(cameraPos.y);
        Debug.Log(cameraPos.z);
        Debug.Log(x);
        Debug.Log(y);
        Debug.Log(z);

        if (scene == "Academy")
        {
            if (direction == "north")
            {
                if (cameraPos.z < 0 && cameraPos.x == 0 || doorClosed == false)
                {
                    z += 5.4f;
                    camera.transform.position = new Vector3(0, 0, z);
                    cameraPos = camera.transform.position;
                }
                else
                {
                    SoundManager.playDoorClosedSound();
                }
            }

            if (direction == "south")
            {
                if (cameraPos.z > -9)
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
                if (cameraPos.x > -5.3 && cameraPos.z == -10)
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
                if (cameraPos.x < 5.3 && cameraPos.z == -10)
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
            if (direction == "north")
            {
                z -= 5.4f;
                camera.transform.position = new Vector3(0, 0, z);
                cameraPos = camera.transform.position;
            }

            if (direction == "south")
            {
                z += 5.4f;
                camera.transform.position = new Vector3(0, 0, z);
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
        else if (scene == "Fairy" || scene == "Artemis" || scene == "Fairy2")
        {
            TextScrollForward();
        }
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


    public void HelloCard()
    {
        if (z > -4.7 && z < -4.5)
        {
            textNumber = 1;

            scene = "Fairy";
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

        else if (z > 6.1 && z < 6.3)
        {
            textNumber = 1;

            scene = "Secretary";
            y = 12f;
            camera.transform.position = new Vector3(0, y, z);
            dialogue.text = "Hello.";
        }

        else if (x < -10.7 && x > -10.9)
        {
            textNumber = 1;

            scene = "Fairy2";
            y = 21f;
            camera.transform.position = new Vector3(0, y, z);
            dialogue.text = "Wait.";
        }

        else if (x < -16.1 && x > -16.3)
        {
            textNumber = 1;

            scene = "Artemis";
            y = 12f;
            camera.transform.position = new Vector3(0, y, z);
            dialogue.text = "Hello, I am Artemis, Queen of the Animals.";
        }

        else
        {
            GameControl.Restart();
        }
    }

    public void GoodbyeCard()
    {
        if (z > -4.7 && z < -4.5)
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
        else
        {
            GameControl.Restart();
        }
    }

    public void OpenCard()
    {
        if (z > 0.7 && z < 0.9)
        {
            SoundManager.playDoorOpeningSound();
            academyDoorway.sprite = doorOpen;
            doorClosed = false;
        }
        else
        {
            GameControl.Restart();
        }
    }
}