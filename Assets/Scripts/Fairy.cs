using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{


    void Start()
    {

    }

    void OnMouseDown()
    {
        if (!GameControl.helloCard.activeSelf)
        {
            GameControl.helloCard.SetActive(true);
            SoundManager.playCardAppearSound();
        }
        SoundManager.playHelloSound();
    }
}