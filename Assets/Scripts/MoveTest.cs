using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTest : MonoBehaviour
{
    Image viewImage;
    private Sprite view01,
                    view02,
                    view03;

    void Start()
    {
        viewImage = GameObject.Find("View").GetComponent<Image>();

        view01 = Resources.Load<Sprite>("Views/View01");
        view02 = Resources.Load<Sprite>("Views/View02");
        view03 = Resources.Load<Sprite>("Views/View03");

        viewImage.sprite = view01;
    }

    public void MoveForward()
    {
        viewImage.sprite = view02;
    }

    public void MoveBackward()
    {
        viewImage.sprite = view01;
    }

    public void MoveLeft()
    {
        if (viewImage.sprite == view02)
        {
            viewImage.sprite = view03;
        }
    }
}