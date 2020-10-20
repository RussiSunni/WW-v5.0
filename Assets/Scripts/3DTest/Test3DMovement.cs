using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3DMovement : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        cameraPos = camera.transform.position;
    }

    public void MoveForward()
    {
        SoundManager.playFootstepSound();
        cameraPos.z += 1f;
        camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    }

    public void MoveBackward()
    {
        SoundManager.playFootstepSound();
        cameraPos.z -= 1f;
        camera.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
    }
}
