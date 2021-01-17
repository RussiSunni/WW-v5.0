using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fairy : MonoBehaviour
{
    public static List<Transform> cards = new List<Transform>();
    public Sprite cardBackSprite;
    Image cardImage;
    void Start()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        cardBackSprite = Resources.Load<Sprite>("Cards/CardBack");

        cards.Add(gameControlScript.helloCard);
        cards.Add(gameControlScript.areCard);
        cards.Add(gameControlScript.youCard);
        cards.Add(gameControlScript.lostCard);
        cards.Add(gameControlScript.questionMarkCard);
        cards.Add(gameControlScript.goCard);
        cards.Add(gameControlScript.throughCard);
        //  cards.Add(gameControlScript.openCard);
        cards.Add(gameControlScript.theCard);
        cards.Add(gameControlScript.doorCard);
        cards.Add(gameControlScript.okCard);


        // cardImage = cards[0].GetComponent<Image>();
        // cardImage.sprite = cardBackSprite;
    }
}

