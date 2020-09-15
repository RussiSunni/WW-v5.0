using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCard : MonoBehaviour
{
    public void pressCard()
    {
        SoundManager.playHelloSound();

        if (Academy.cameraPos.z == -8)
        {
            Fairy.fairyText.SetActive(true);
        }
    }
}

