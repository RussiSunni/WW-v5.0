using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public static List<Transform> speechCards = new List<Transform>();
    public static List<Transform> actionCards = new List<Transform>();
    void Start()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        speechCards.Add(gameControlScript.helloCard);
        speechCards.Add(gameControlScript.yesCard);
        speechCards.Add(gameControlScript.noCard);
        speechCards.Add(gameControlScript.thankyouCard);
        speechCards.Add(gameControlScript.okCard);

        for (int i = 0; i < speechCards.Count; ++i)
        {
            var playerCard = Instantiate(speechCards[i], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(GameControl.speechHand.transform, false);
        }

        actionCards.Add(gameControlScript.openCard);
        // actionCards.Add(gameControlScript.doorCard);
        for (int i = 0; i < actionCards.Count; ++i)
        {
            var playerCard = Instantiate(actionCards[i], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(GameControl.actionHand.transform, false);
        }
    }

    public static void AddDoorCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        actionCards.Add(gameControlScript.doorCard);
    }

}

