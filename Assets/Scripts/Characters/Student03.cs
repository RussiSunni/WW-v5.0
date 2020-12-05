using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Student03 : MonoBehaviour
{
    SpriteRenderer student03;
    Sprite student03Front, student03Side;
    int turn = 0;
    void Start()
    {
        student03 = GetComponent<SpriteRenderer>();
        student03Front = Resources.Load<Sprite>("Library/Student03Front");
        student03Side = Resources.Load<Sprite>("Library/Student03Side");
        student03.sprite = student03Front;
    }

    void Update()
    {
        if (Academy.direction == "south" || Academy.direction == "north")
        {
            student03.sprite = student03Front;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else if (Academy.direction == "west" || Academy.direction == "east")
        {
            student03.sprite = student03Side;
            this.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }

    public void Move()
    {

        switch (turn)
        {
            case 0:
                transform.position = transform.position + new Vector3(5.4f, 0, 0);
                turn++;
                break;
            case 1:
                transform.position = transform.position + new Vector3(0f, 0, -5.4f);
                turn++;
                break;
            case 2:
                transform.position = transform.position + new Vector3(-5.4f, 0, 0);
                turn++;
                break;
            case 3:
                transform.position = transform.position + new Vector3(0f, 0, 5.4f);
                turn = 0;
                break;
            default:
                // code block
                break;
        }
    }
}

