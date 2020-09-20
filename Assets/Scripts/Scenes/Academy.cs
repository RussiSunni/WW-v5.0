using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Academy : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    float z = -10;
    float y = 0;
    float x = 0;
    string direction, scene;
    Text dialogue;
    int textNumber = 1;
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
        if (scene == "Academy")
        {
            if (direction == "north")
            {
                if (cameraPos.z < 0 || doorClosed == false)
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
                    SoundManager.playDoorClosedSound();
                }
            }

            else if (direction == "west")
            {
                x -= 5.4f;
                camera.transform.position = new Vector3(x, 0, z);
                cameraPos = camera.transform.position;
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
        else if (scene == "Fairy")
        {
            TextScrollForward();
        }
    }

    public void UpOneLevel()
    {
        SoundManager.playHelloSound();

        if (z > -4.7 && z < -4.5)
        {
            scene = "Fairy";
            y = 12f;
            camera.transform.position = new Vector3(0, y, z);
            if (!GameControl.goodbyeCard.activeSelf)
                dialogue.text = "Hello. Welcome to Wild World.";
        }

        if (z > 6.1 && z < 6.3)
        {
            scene = "Secretary";
            y = 12f;
            camera.transform.position = new Vector3(0, y, z);
            dialogue.text = "Hello.";

        }
    }

    public void DownOneLevel()
    {
        SoundManager.playGoodbyeSound();

        scene = "Academy";

        y = 0f;
        camera.transform.position = new Vector3(0, y, z);

        dialogue.text = "";
    }

    public void TextScrollForward()
    {
        textNumber++;
        if (textNumber == 2)
            dialogue.text = "Below is your spellbook.";

        else if (textNumber == 3)
        {
            SoundManager.playDoorSound();
            dialogue.text = "So far, you have a greeting spell. I will give you one to open doors also.";
            GameControl.doorCard.SetActive(true);
            SoundManager.playCardAppearSound();
        }

        else if (textNumber == 4)
            dialogue.text = "You will need to collect and use spells in order to escape the Labyrinth. Be careful, using the wrong spell at the wrong place can result in an early demise.";

        else if (textNumber == 5)
        {
            SoundManager.playGoodbyeSound();
            dialogue.text = "Goodbye.";
            GameControl.goodbyeCard.SetActive(true);
            SoundManager.playCardAppearSound();
        }
    }

    public void doorButton()
    {
        SoundManager.playDoorSound();
        if (z > 0.7 && z < 0.9)
        {
            SoundManager.playDoorOpeningSound();
            academyDoorway.sprite = doorOpen;
            doorClosed = false;
        }
    }
}