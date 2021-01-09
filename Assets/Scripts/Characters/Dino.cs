using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
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
        cards.Add(gameControlScript.whatCard);
        cards.Add(gameControlScript.isCard);
        cards.Add(gameControlScript.yourCard);
        cards.Add(gameControlScript.nameCard);
        cards.Add(gameControlScript.questionMarkCard);
        cards.Add(gameControlScript.iCard);
        cards.Add(gameControlScript.askedCard);
        cards.Add(gameControlScript.youCard);
        cards.Add(gameControlScript.areCard);
        cards.Add(gameControlScript.notCard);
        cards.Add(gameControlScript.fromCard);
        cards.Add(gameControlScript.hereCard);
        cards.Add(gameControlScript.evaCard);
        cards.Add(gameControlScript.niceCard);
        cards.Add(gameControlScript.toCard);
        cards.Add(gameControlScript.meetCard);
    }

    public void Move()
    {
        transform.position = transform.position + new Vector3(-5.4f, 0, 0);
    }
}

