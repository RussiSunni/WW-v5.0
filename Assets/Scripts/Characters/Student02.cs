using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Student02 : MonoBehaviour
{
    SpriteRenderer student02;
    Sprite student02Front, student02Side;
    void Start()
    {
        student02 = GetComponent<SpriteRenderer>();
        student02Front = Resources.Load<Sprite>("Library/Student02Front");
        student02Side = Resources.Load<Sprite>("Library/Student02Side");
        student02.sprite = student02Front;
    }

    void Update()
    {
        if (Academy.direction == "south" || Academy.direction == "north")
        {
            student02.sprite = student02Front;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Academy.direction == "west" || Academy.direction == "east")
        {
            student02.sprite = student02Side;
            this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}

