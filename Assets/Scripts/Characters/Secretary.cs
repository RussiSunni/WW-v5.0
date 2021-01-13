using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Secretary : MonoBehaviour
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
        cards.Add(gameControlScript.pleaseCard);
        cards.Add(gameControlScript.closeCard);
        cards.Add(gameControlScript.theCard);
        cards.Add(gameControlScript.doorCard);



        // cardImage = cards[0].GetComponent<Image>();
        // cardImage.sprite = cardBackSprite;
    }
}

