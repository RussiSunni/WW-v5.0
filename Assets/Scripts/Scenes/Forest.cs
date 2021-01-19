using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Forest : MonoBehaviour
{
    public static List<Transform> characterCards = new List<Transform>();

    private void Start()
    {
    }

    public void MoveForward()
    {
        if (GameControl.direction == "north")
        {



        }
        else if (GameControl.direction == "south")
        {

        }
        else if (GameControl.direction == "east")
        {



        }
        else if (GameControl.direction == "west")
        {
            if (Mathf.Approximately(GameControl.cameraPos.z, 0f) && Mathf.Approximately(GameControl.cameraPos.x, -5.4f) && GameControl.direction == "west")
            {
                for (int i = 0; i < Wolf.cards.Count; ++i)
                {
                    characterCards.Add(Instantiate(Wolf.cards[i], new Vector3(0, 0, 0), Quaternion.identity));
                    characterCards[i].transform.SetParent(GameControl.characterHand.transform, false);
                    characterCards[i].GetComponent<Image>().sprite = GameControl.cardBackSprite;
                }
            }
        }
    }


    public void Craft()
    {
        // Wolf ------------------------------
        if (Mathf.Approximately(GameControl.cameraPos.z, 0f) && Mathf.Approximately(GameControl.cameraPos.x, -5.4f) && GameControl.direction == "west")
        {
            int letterTabletopCount = GameControl.letterTabletop.transform.childCount;
            print(letterTabletopCount);

            if (letterTabletopCount == 4 && GameControl.letterTabletop.transform.GetChild(0).gameObject.name == "WCard" && GameControl.letterTabletop.transform.GetChild(1).gameObject.name == "OCard" && GameControl.letterTabletop.transform.GetChild(2).gameObject.name == "LCard" && GameControl.letterTabletop.transform.GetChild(3).gameObject.name == "FCard")
            {
                print("test3");
                //characterCards[8].transform.SetParent(GameControl.wordTabletopPanel.transform, false);
                //characterCards[8].GetComponent<Image>().sprite = GameControl.wolfCardSprite;
            }
        }
    }
}