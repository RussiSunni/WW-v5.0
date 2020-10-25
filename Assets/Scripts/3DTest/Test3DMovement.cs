using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3DMovement : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    string direction;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
    }

    public void MoveForward()
    {
        SoundManager.playFootstepSound();
        cameraPos.z += 5f;
        camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    }

    public void MoveBackward()
    {
        SoundManager.playFootstepSound();
        cameraPos.z -= 5f;
        camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
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
    }
}
