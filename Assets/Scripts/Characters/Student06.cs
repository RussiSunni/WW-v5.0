using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Student06 : MonoBehaviour
{
    SpriteRenderer student06;
    Sprite student06Front, student06Side;
    void Start()
    {
        student06 = GetComponent<SpriteRenderer>();
        student06Front = Resources.Load<Sprite>("Library/Student06Front");
        student06Side = Resources.Load<Sprite>("Library/Student06Side");
        student06.sprite = student06Front;
    }

    void Update()
    {
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
