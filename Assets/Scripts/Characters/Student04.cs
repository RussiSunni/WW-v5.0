using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Student04 : MonoBehaviour
{
    SpriteRenderer student04;
    Sprite student04Front, student04Side;
    void Start()
    {
        student04 = GetComponent<SpriteRenderer>();
        student04Front = Resources.Load<Sprite>("Library/Student04Front");
        student04Side = Resources.Load<Sprite>("Library/Student04Side");
        student04.sprite = student04Front;
    }

    void Update()
    {
        if (Academy.direction == "south" || Academy.direction == "north")
        {
            student04.sprite = student04Front;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Academy.direction == "west" || Academy.direction == "east")
        {
            student04.sprite = student04Side;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}

