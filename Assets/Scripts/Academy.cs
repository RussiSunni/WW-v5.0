using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Academy : MonoBehaviour
{
    Camera camera;
    public static Vector3 cameraPos;
    float z = -10;
    private Sprite OutsideAcademyView01,
                    OutsideAcademyView02,
                    OutsideAcademyView03,
                    OutsideAcademyView04;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        cameraPos = camera.transform.position;

        OutsideAcademyView01 = Resources.Load<Sprite>("OutsideAcademyView01");
        OutsideAcademyView02 = Resources.Load<Sprite>("OutsideAcademyView02");
        OutsideAcademyView03 = Resources.Load<Sprite>("OutsideAcademyView03");
        OutsideAcademyView04 = Resources.Load<Sprite>("OutsideAcademyView04");
    }

    public void MoveForward()
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

    public void MoveBackward()
    {
        z -= 2f;

        camera.transform.position = new Vector3(0, 0, z);
        cameraPos = camera.transform.position;
    }

    public void MoveLeft()
    {
        // if (viewImage.sprite == OutsideAcademyView02)
        // {
        //     viewImage.sprite = view03;
        // }
    }
}