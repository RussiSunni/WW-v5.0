using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Student01 : MonoBehaviour
{
    SpriteRenderer student01;
    Sprite student01Front, student01Side;
    void Start()
    {
        student01 = GetComponent<SpriteRenderer>();
        student01Front = Resources.Load<Sprite>("Library/Student01Front");
        student01Side = Resources.Load<Sprite>("Library/Student01Side");
        student01.sprite = student01Front;
    }

    void Update()
    {
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

