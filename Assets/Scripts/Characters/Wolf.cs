using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wolf : MonoBehaviour
{
    List<GameObject> cards = new List<GameObject>();
    GameObject helloCard;
    void Start()
    {
        helloCard = GameObject.Find("HelloCard");

        cards.Add(helloCard);
        print(cards[0].name);
    }

    // add any cards from player, plus logic on when to use
}

