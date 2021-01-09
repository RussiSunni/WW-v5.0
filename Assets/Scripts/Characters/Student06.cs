using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Student06 : MonoBehaviour
{
    SpriteRenderer student06;
    Sprite student06Front, student06Side;
    public static List<Transform> cards = new List<Transform>();
    public Sprite cardBackSprite;
    Image cardImage;
    void Start()
    {
        //2D sprites for side and front
        student06 = GetComponent<SpriteRenderer>();
        student06Front = Resources.Load<Sprite>("Library/Student06Front");
        student06Side = Resources.Load<Sprite>("Library/Student06Side");
        student06.sprite = student06Front;

        // Their cards
        GameObject gameControl = GameObject.Find("GameControl");
        GameControl gameControlScript = gameControl.GetComponent<GameControl>();
        cardBackSprite = Resources.Load<Sprite>("Cards/CardBack");
        cards.Add(gameControlScript.hiCard);
        cards.Add(gameControlScript.iCard);
        cards.Add(gameControlScript.amCard);
        cards.Add(gameControlScript.evaCard);
        cards.Add(gameControlScript.areCard);
        cards.Add(gameControlScript.youCard);
        cards.Add(gameControlScript.newCard);
        cards.Add(gameControlScript.hereCard);
        cards.Add(gameControlScript.questionMarkCard);
        cards.Add(gameControlScript.haveCard);
        cards.Add(gameControlScript.funCard);
    }

    void Update()
    {
        //2D sprites for side and front
        if (Academy.direction == "south" || Academy.direction == "north")
        {
            student06.sprite = student06Front;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Academy.direction == "west" || Academy.direction == "east")
        {
            student06.sprite = student06Side;
            this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
