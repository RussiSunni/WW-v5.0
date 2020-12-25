using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wolf : MonoBehaviour
{
    public static List<Transform> cards = new List<Transform>();
    public Sprite cardBackSprite;
    Image cardImage;
    void Start()
    {
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();

        cardBackSprite = Resources.Load<Sprite>("Cards/CardBack");

        cards.Add(gameControlScript.hiCard);

        cardImage = cards[0].GetComponent<Image>();
        cardImage.sprite = cardBackSprite;
    }
}

