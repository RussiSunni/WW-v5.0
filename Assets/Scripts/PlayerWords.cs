using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWords : MonoBehaviour
{
    public static bool hasHelloCard;
    public Transform A;
    List<Transform> GridRow = new List<Transform>();

    private void Start()
    {
        GridRow.Add(A);
    }

    public void PlayerGetWord()
    {
        if (A.childCount > 0)
        {
            if (A.GetChild(0).name == "HelloCard(Clone)")
            {
                Destroy(A.GetChild(0).gameObject);
                SoundManager.playSound(SoundManager.effectPop);
                if (!hasHelloCard)
                {
                    hasHelloCard = true;
                    var wordUIScript = GameObject.Find("WordPanel").GetComponent<WordUI>();
                    wordUIScript.TurnOnHelloButton();

                    var gameControlScript = GameObject.Find("GameControl").GetComponent<GameControl>();

                    if (gameControlScript.wordPanel.GetComponent<CanvasGroup>().interactable == false)
                    {
                        gameControlScript.ControlButton();
                    }
                }
            }           
        }
    }

}
