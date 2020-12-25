using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Student01 : MonoBehaviour
{
    SpriteRenderer student01;
    Sprite student01Front, student01Side;
    public static List<Transform> cards = new List<Transform>();
    public Sprite cardBackSprite;
    Image cardImage;
    void Start()
    {
        //2D sprites for side and front
        student01 = GetComponent<SpriteRenderer>();
        student01Front = Resources.Load<Sprite>("Library/Student01Front");
        student01Side = Resources.Load<Sprite>("Library/Student01Side");
        student01.sprite = student01Front;

        // Their cards
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();
        cardBackSprite = Resources.Load<Sprite>("Cards/CardBack");
        cards.Add(gameControlScript.hiCard);
        cardImage = cards[0].GetComponent<Image>();
        cardImage.sprite = cardBackSprite;
    }

    void Update()
    {
        //2D sprites for side and front
        if (Academy.direction == "east")
        {
            student01.sprite = student01Front;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Academy.direction == "south")
        {
            student01.sprite = student01Side;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 00, 0);
        }
    }
}

