using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AcademyWildArea : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    float z = 0;
    float y = 0;
    float x = 0;
    string scene;
    public static string direction;
    Text dialogue;
    int textNumber;
    bool isFrontDoorClosed = true;
    bool isRoomsDoorClosed = true;
    GameObject page1, page2;

    SpriteRenderer frontDoorway, roomsDoorway;
    Sprite frontDoorOpen, roomsDoorOpen, roomsDoorClosed;
    public static bool helloHold;

    // --

    public GameObject[] openings;
    public GameObject teacher;
    public bool canWalkThroughNextWall;
    public static bool canWalk;

    void Start()
    {
        GameControl.scene = "Academy Wild Area";

        // camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        // cameraPos = camera.transform.position;
        // direction = "north";

        // dialogue = GameObject.Find("Text").GetComponent<Text>();
        // dialogue.text = "";

        // page1 = GameObject.Find("Page1");
        // page2 = GameObject.Find("Page2");

        // if (!GameControl.goodbyeCardActive)
        //     GameControl.goodbyeCard.SetActive(false);

        // if (!GameControl.openCardActive)
        //     GameControl.openCard.SetActive(false);

        // if (!GameControl.readCardActive)
        //     GameControl.readCard.SetActive(false);

        // --
        // check which are doorways
        // Invoke("CheckWalk", 2f);
    }

    // void CheckWalk()
    // {
    //     // -- 
    //     // Teacher character
    //     teacher = GameObject.FindGameObjectWithTag("Teacher");

    //     // walls
    //     openings = GameObject.FindGameObjectsWithTag("CanWalkThrough");
    //     CheckWalls();
    // }

    // public void CheckWalls()
    // {
    //     canWalkThroughNextWall = false;

    //     for (int i = 0; i < openings.Length; i++)
    //     {
    //         Vector3 viewPos = camera.WorldToViewportPoint(openings[i].transform.position);

    //         if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
    //         {
    //             canWalkThroughNextWall = true;
    //         }
    //     }
    // }

    // public void MoveForward()
    // {
    //     SoundManager.playFootstepSound();

    //     if (canWalkThroughNextWall)
    //     {
    //         if (direction == "north")
    //         {
    //             z += 5.4f;
    //             camera.transform.position = new Vector3(x, y, z);
    //             cameraPos = camera.transform.position;
    //         }
    //         else if (direction == "south")
    //         {
    //             z += -5.4f;
    //             camera.transform.position = new Vector3(x, y, z);
    //             cameraPos = camera.transform.position;
    //         }
    //         else if (direction == "east")
    //         {
    //             x += 5.4f;
    //             camera.transform.position = new Vector3(x, y, z);
    //             cameraPos = camera.transform.position;
    //         }
    //         else if (direction == "west")
    //         {
    //             x += -5.4f;
    //             camera.transform.position = new Vector3(x, y, z);
    //             cameraPos = camera.transform.position;
    //         }
    //     }

    //     CheckWalls();

    // }
    // public void MoveBackward()
    // {
    //     SoundManager.playFootstepSound();

    //     if (direction == "north" && cameraPos.z > -10f)
    //     {
    //         z -= 5.4f;
    //         camera.transform.position = new Vector3(x, 0, z);
    //         cameraPos = camera.transform.position;
    //     }
    // }
    // public void LeftButton()
    // {

    //     if (direction == "north")
    //     {
    //         direction = "west";
    //     }
    //     else if (direction == "west")
    //     {
    //         direction = "south";
    //     }
    //     else if (direction == "south")
    //     {
    //         direction = "east";
    //     }
    //     else if (direction == "east")
    //     {
    //         direction = "north";
    //     }

    //     camera.transform.Rotate(0, -90, 0);
    //     CheckWalls();
    // }
    // public void RightButton()
    // {

    //     if (direction == "north")
    //     {
    //         direction = "east";
    //     }
    //     else if (direction == "east")
    //     {
    //         direction = "south";
    //     }
    //     else if (direction == "south")
    //     {
    //         direction = "west";
    //     }
    //     else if (direction == "west")
    //     {
    //         direction = "north";
    //     }
    //     camera.transform.Rotate(0, 90, 0);
    //     CheckWalls();
    // }

    // public void HelloCard()
    // {
    //     Vector3 viewPos = camera.WorldToViewportPoint(teacher.transform.position);
    //     //    / print("x: " + viewPos.x + "y: " + viewPos.y + "z: " + viewPos.z);

    //     if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
    //     {
    //         y = 12f;
    //         camera.transform.position = new Vector3(x, y, z);
    //         dialogue.text = "What are you doing here?";

    //         GameControl.sorryCard.SetActive(true);
    //         SoundManager.playCardAppearSound();
    //         SpellbookButton();
    //     }
    // }

    // public void GoodbyeCard()
    // {
    //     Vector3 viewPos = camera.WorldToViewportPoint(teacher.transform.position);

    //     if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
    //     {
    //         y = 0f;
    //         camera.transform.position = new Vector3(x, y, z);
    //         dialogue.text = "";
    //     }
    // }

    // public void SpellbookButton()
    // {
    //     SoundManager.playPageTurnSound();

    //     if (page1.transform.localPosition.x == 0f)
    //     {
    //         page1.transform.localPosition = new Vector3(-800f, 0f, 0f);
    //         page2.transform.localPosition = new Vector3(0f, 0f, 0f);
    //     }
    //     else if (page1.transform.localPosition.x == -800f)
    //     {
    //         page1.transform.localPosition = new Vector3(0f, 0f, 0f);
    //         page2.transform.localPosition = new Vector3(800f, 0f, 0f);
    //     }
    // }
}