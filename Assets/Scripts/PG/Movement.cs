using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
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
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
        direction = "north";

        // --
        // check which are doorways
        Invoke("CheckWalk", 2f);
    }

    void CheckWalk()
    {
        // -- 
        // Teacher character
        teacher = GameObject.FindGameObjectWithTag("Teacher");

        // walls
        openings = GameObject.FindGameObjectsWithTag("CanWalkThrough");
        CheckWalls();
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


        // Vector3 viewPos1 = camera.WorldToViewportPoint(openings[0].transform.position);
        // Vector3 viewPos2 = camera.WorldToViewportPoint(openings[1].transform.position);

        // if (viewPos1.z > 2.6f && viewPos1.z < 2.8f && viewPos1.x > 0.4f && viewPos1.x < 0.6f || viewPos2.z > 2.6f && viewPos2.z < 2.8f && viewPos2.x > 0.4f && viewPos2.x < 0.6f)
        // {
        //     canWalkThroughNextWall = true;
        //     print(canWalkThroughNextWall);
        //     print("x: " + viewPos1.x + "y: " + viewPos1.y + "z: " + viewPos1.z);
        //     print("x: " + viewPos2.x + "y: " + viewPos2.y + "z: " + viewPos2.z);

        // }
        // else
        // {
        //     canWalkThroughNextWall = false;
        //     print(canWalkThroughNextWall);
        //     print("x: " + viewPos1.x + "y: " + viewPos1.y + "z: " + viewPos1.z);
        //     print("x: " + viewPos2.x + "y: " + viewPos2.y + "z: " + viewPos2.z);
        // }
    }

    public void MoveForward()
    {

        SoundManager.playFootstepSound();

        if (canWalkThroughNextWall)
        {
            if (direction == "north")
            {
                z += 5.4f;
                camera.transform.position = new Vector3(x, y, z);
                cameraPos = camera.transform.position;
            }
            else if (direction == "south")
            {
                z += -5.4f;
                camera.transform.position = new Vector3(x, y, z);
                cameraPos = camera.transform.position;
            }
            else if (direction == "east")
            {
                x += 5.4f;
                camera.transform.position = new Vector3(x, y, z);
                cameraPos = camera.transform.position;
            }
            else if (direction == "west")
            {
                x += -5.4f;
                camera.transform.position = new Vector3(x, y, z);
                cameraPos = camera.transform.position;
            }
        }

        CheckWalls();

    }
    public void MoveBackward()
    {
        SoundManager.playFootstepSound();

        if (direction == "north" && cameraPos.z > -10f)
        {
            z -= 5.4f;
            camera.transform.position = new Vector3(x, 0, z);
            cameraPos = camera.transform.position;
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
        CheckWalls();


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
        CheckWalls();
    }

    public void HelloCard()
    {
        Vector3 viewPos = camera.WorldToViewportPoint(teacher.transform.position);
        //    / print("x: " + viewPos.x + "y: " + viewPos.y + "z: " + viewPos.z);

        if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
        {
            cameraPos.y = 12f;
            camera.transform.position = new Vector3(x, y, z);
            cameraPos = camera.transform.position;
        }
    }
}