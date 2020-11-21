using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Student05 : MonoBehaviour
{
    SpriteRenderer student05;
    Sprite student05Front, student05Side;
    void Start()
    {
        student05 = GetComponent<SpriteRenderer>();
        student05Front = Resources.Load<Sprite>("Library/Student05Front");
        student05Side = Resources.Load<Sprite>("Library/Student05Side");
        student05.sprite = student05Front;
    }

    void Update()
    {
        if (Academy.direction == "south" || Academy.direction == "north")
        {
            student05.sprite = student05Front;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Academy.direction == "west" || Academy.direction == "east")
        {
            student05.sprite = student05Side;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}
