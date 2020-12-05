using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3DMovement : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    string direction = "north";

    public bool canWalkThroughNextWall, canWalkThroughPreviousWall;
    public GameObject[] solidObjects;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;

        CheckWalk();
    }

    // public void MoveForward()
    // {
    //     SoundManager.playFootstepSound();
    //     if (direction == "north")
    //     {
    //         cameraPos.z += 5.4f;
    //         camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    //     }
    //     else if (direction == "south")
    //     {
    //         cameraPos.z += -5.4f;
    //         camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    //         cameraPos = camera.transform.position;
    //     }
    //     else if (direction == "east")
    //     {
    //         cameraPos.x += 5.4f;
    //         camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    //         cameraPos = camera.transform.position;
    //     }
    //     else if (direction == "west")
    //     {
    //         cameraPos.x += -5.4f;
    //         camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    //         cameraPos = camera.transform.position;
    //     }
    // }

    // public void MoveBackward()
    // {
    //     SoundManager.playFootstepSound();
    //     cameraPos.z -= 5.4f;
    //     camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
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
    // }



    void CheckWalk()
    {
        solidObjects = GameObject.FindGameObjectsWithTag("CantWalkThrough");

        CheckWalls();
    }

    public void CheckWalls()
    {
        canWalkThroughNextWall = true;

        for (int i = 0; i < solidObjects.Length; i++)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(solidObjects[i].transform.position);
            Debug.Log(viewPos.z);
            Debug.Log(viewPos.x);

            if (viewPos.z > 5.3f && viewPos.z < 5.5f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalkThroughNextWall = false;
            }
            else if (viewPos.z > 2.6f && viewPos.z < 2.8f && viewPos.x > 0.4f && viewPos.x < 0.6f)
            {
                canWalkThroughNextWall = false;
            }

        }
        Debug.Log(canWalkThroughNextWall);
    }
    public void MoveForward()
    {
        if (canWalkThroughNextWall)
        {
            SoundManager.playFootstepSound();
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

        else if (cameraPos.z == -10f && direction == "east" || cameraPos.z == -10f && direction == "west")
        {
            SoundManager.playWolfGrowlSound();
        }
        else
            SoundManager.playBumpSound();

        CheckWalls();

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

}
