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
    string direction, scene;
    Text fairyText;
    int textNumber = 1;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
        direction = "north";

        fairyText = GameObject.Find("FairyText").GetComponent<Text>();
        fairyText.text = "";

        scene = "Academy";
    }

    public void MoveForward()
    {
        if (scene == "Academy")
        {
            if (direction == "north" || direction == "south")
            {
                if (cameraPos.z < -6)
                {
                    z += 2f;
                    camera.transform.position = new Vector3(0, 0, z);
                    cameraPos = camera.transform.position;
                }
                else
                {
                    SoundManager.playDoorClosedSound();
                }
            }
        }
    }

    public void MoveBackward()
    {
        if (scene == "Academy")
        {
            if (direction == "north" || direction == "south")
            {
                z -= 2f;
                camera.transform.position = new Vector3(0, 0, z);
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
        if (z == -8)
        {
            scene = "Fairy";
            y = 12f;
            camera.transform.position = new Vector3(0, y, z);
            if (!GameControl.goodbyeCard.activeSelf)
                fairyText.text = "Hello. Welcome to Wild World.";
        }
    }

    public void DownOneLevel()
    {
        scene = "Academy";

        y = 0f;
        camera.transform.position = new Vector3(0, y, z);

        fairyText.text = "";
    }

    public void TextScrollForward()
    {
        textNumber++;
        if (textNumber == 2)
            fairyText.text = "Below is your spellbook.";

        else if (textNumber == 3)
        {
            fairyText.text = "So far, you have a greeting spell. I will give you one to open doors also.";
            GameControl.doorCard.SetActive(true);
            SoundManager.playCardAppearSound();
        }

        else if (textNumber == 4)
            fairyText.text = "You will need to collect and use spells in order to escape the Labyrinth. Be careful, using the wrong spell at the wrong place can result in an early demise.";

        else if (textNumber == 5)
        {
            fairyText.text = "Goodbye.";
            GameControl.goodbyeCard.SetActive(true);
            SoundManager.playCardAppearSound();
        }
    }

    public void doorButton()
    {
        SoundManager.playDoorOpeningSound();
    }
}