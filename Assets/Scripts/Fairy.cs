using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    GameObject helloCard;
    public static GameObject doorCard, fairyText;

    void Start()
    {
        helloCard = GameObject.Find("HelloButton");
        fairyText = GameObject.Find("FairyText");
        doorCard = GameObject.Find("DoorButton");
        helloCard.SetActive(false);
        fairyText.SetActive(false);
        doorCard.SetActive(false);
    }

    void OnMouseDown()
    {
        // if (!helloCard.activeSelf)
        // {
        SoundManager.playHelloSound();
        helloCard.SetActive(true);
        SoundManager.playCardAppearSound();
        // }
        // else
        // {

        // }
    }
}