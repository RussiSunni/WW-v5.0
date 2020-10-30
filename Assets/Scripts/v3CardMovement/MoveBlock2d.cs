 using UnityEngine;
 using System.Collections;
 
public class MoveBlock2d : MonoBehaviour
{
    public float speed = 70f;
    public bool selected = false;
    public Vector3 positionC;


    void Update ()
    {
        Debug.Log(gameObject.name);
        print(transform.position);


        if (selected == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }

        if (transform.position.x < -140 && transform.position.x > -160 && transform.position.y < -165 && transform.position.y > -185)
        {
            print("bingo");
            positionC.x = -150;
            positionC.y = -175;
            transform.position = positionC;
            selected = false;
        }
    }

    void OnMouseDown()
    {
        if (selected == false)
        {
            selected = true;
        }
        else
        {
            selected = false;
        }
    }
}