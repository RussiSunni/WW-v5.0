using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Academy : MonoBehaviour
{
    Image viewImage;
    Camera camera;
    float z = -10;
    private Sprite OutsideAcademyView01,
                    OutsideAcademyView02,
                    OutsideAcademyView03,
                    OutsideAcademyView04;

    void Start()
    {
        viewImage = GameObject.Find("View").GetComponent<Image>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();

        OutsideAcademyView01 = Resources.Load<Sprite>("OutsideAcademyView01");
        OutsideAcademyView02 = Resources.Load<Sprite>("OutsideAcademyView02");
        OutsideAcademyView03 = Resources.Load<Sprite>("OutsideAcademyView03");
        OutsideAcademyView04 = Resources.Load<Sprite>("OutsideAcademyView04");

        viewImage.sprite = OutsideAcademyView01;
    }

    public void MoveForward()
    {
        z += 1.54f;

        camera.transform.position = new Vector3(0, 0, z);

        // if (viewImage.sprite == OutsideAcademyView01)
        // {
        //     viewImage.sprite = OutsideAcademyView02;
        // }
        // else if (viewImage.sprite == OutsideAcademyView02)
        // {
        //     viewImage.sprite = OutsideAcademyView03;
        // }
        // else if (viewImage.sprite == OutsideAcademyView03)
        // {
        //     viewImage.sprite = OutsideAcademyView04;
        // }
    }

    public void MoveBackward()
    {
        z -= 1.54f;

        camera.transform.position = new Vector3(0, 0, z);

        // if (viewImage.sprite == OutsideAcademyView02)
        // {
        //     viewImage.sprite = OutsideAcademyView01;
        // }
        // else if (viewImage.sprite == OutsideAcademyView03)
        // {
        //     viewImage.sprite = OutsideAcademyView02;
        // }
        // else if (viewImage.sprite == OutsideAcademyView04)
        // {
        //     viewImage.sprite = OutsideAcademyView03;
        // }
    }

    public void MoveLeft()
    {
        // if (viewImage.sprite == OutsideAcademyView02)
        // {
        //     viewImage.sprite = view03;
        // }
    }
}