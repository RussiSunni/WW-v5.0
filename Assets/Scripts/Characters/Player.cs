using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    //    public static List<Transform> speechCards = new List<Transform>();
    //  public static List<Transform> actionCards = new List<Transform>();
    public static List<Transform> playerCards = new List<Transform>();
    void Start()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        // speechCards.Add(gameControlScript.helloCard);
        // speechCards.Add(gameControlScript.yesCard);
        // speechCards.Add(gameControlScript.noCard);
        // speechCards.Add(gameControlScript.thankyouCard);

        // for (int i = 0; i < speechCards.Count; ++i)
        // {
        //     var playerCard = Instantiate(speechCards[i], new Vector3(0, 0, 0), Quaternion.identity);
        //     playerCard.transform.SetParent(GameControl.speechHand.transform, false);
        // }

        // actionCards.Add(gameControlScript.openCard);
        // // actionCards.Add(gameControlScript.doorCard);
        // for (int i = 0; i < actionCards.Count; ++i)
        // {
        //     var playerCard = Instantiate(actionCards[i], new Vector3(0, 0, 0), Quaternion.identity);
        //     playerCard.transform.SetParent(GameControl.actionHand.transform, false);
        // }

        playerCards.Add(gameControlScript.helloCard);
        playerCards.Add(gameControlScript.yesCard);
        playerCards.Add(gameControlScript.noCard);
        playerCards.Add(gameControlScript.thankyouCard);
        playerCards.Add(gameControlScript.openCard);

        for (int i = 0; i < playerCards.Count; ++i)
        {
            var playerCard = Instantiate(playerCards[i], new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(GameControl.wordHandPanel.transform, false);
        }
    }

    public static void AddDoorCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.doorCard);
        playerCards.Add(gameControlScript.doorCard);
    }

    public static void AddCloseCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.evaCard);
        playerCards.Add(gameControlScript.closeCard);
    }

    public static void AddEvaCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.evaCard);
        playerCards.Add(gameControlScript.evaCard);
    }

    public static void AddMeetCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.meetCard);
        playerCards.Add(gameControlScript.meetCard);
    }

    public static void AddOpenCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.meetCard);
        playerCards.Add(gameControlScript.openCard);
    }

    public static void AddTheCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.meetCard);
        playerCards.Add(gameControlScript.theCard);
    }

    public static void AddPleaseCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.meetCard);
        playerCards.Add(gameControlScript.pleaseCard);
    }

    public static void AddHiCard()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        //actionCards.Add(gameControlScript.meetCard);
        playerCards.Add(gameControlScript.hiCard);
    }
}

