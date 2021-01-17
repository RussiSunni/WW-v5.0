using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class Swipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    GameObject card;
    private Vector3 firstTouchPosition;
    private Vector3 finalTouchPosition;
    float swipeAngle = 0;
    //public Transform speechHand, speechTabletop, actionHand, actionTabletop;
    Transform hand, tabletop;
    //private bool speechOrAction;

    void Start()
    {
        card = this.gameObject;

        // speechTabletop = GameObject.Find("SpeechTabletop").transform;
        //  speechHand = GameObject.Find("SpeechHand").transform;
        // actionTabletop = GameObject.Find("ActionTabletop").transform;
        // actionHand = GameObject.Find("ActionHand").transform;

        tabletop = GameObject.Find("WordTabletop").transform;
        hand = GameObject.Find("WordHand").transform;
    }

    // UI elements
    public void OnPointerDown(PointerEventData eventData)
    {
        // if (this.transform.parent.gameObject.name == "SpeechHand" || this.transform.parent.gameObject.name == "SpeechTabletop")
        //     speechOrAction = true;
        // else if (this.transform.parent.gameObject.name == "ActionHand" || this.transform.parent.gameObject.name == "ActionTabletop")
        //     speechOrAction = false;

        var mousePos = Input.mousePosition;

        if (Academy.direction == "north" || Academy.direction == "south")
            firstTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));

        else if (Academy.direction == "east" || Academy.direction == "west")
        {
            var temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));
            firstTouchPosition.x = temp.z;
            firstTouchPosition.y = temp.y;
            firstTouchPosition.z = 10.8f;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Academy.direction == "north" || Academy.direction == "south")
            finalTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));

        else if (Academy.direction == "east" || Academy.direction == "west")
        {
            var temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));
            finalTouchPosition.x = temp.z;
            finalTouchPosition.y = temp.y;
            finalTouchPosition.z = 10.8f;
        }

        CalculateAngle();

        //   Debug.Log(finalTouchPosition);
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;

        // Debug.Log(swipeAngle);
        MovePieces();
    }

    // ui
    void MovePieces()
    {
        if (Academy.direction == "north" || Academy.direction == "west")
        {
            if (swipeAngle > -45 && swipeAngle <= 45)
            {
                //  Debug.Log("right");
            }
            else if (swipeAngle > 45 && swipeAngle <= 135)
            {
                // Debug.Log("up");
                this.transform.SetParent(tabletop);

                // if (speechOrAction)
                //     this.transform.SetParent(speechTabletop);
                // else
                //     this.transform.SetParent(actionTabletop);

            }
            else if (swipeAngle > 135 || swipeAngle <= -135)
            {
                // Debug.Log("left");
            }
            else if (swipeAngle < -45 && swipeAngle >= -135)
            {
                // Debug.Log("down");
                //if (speechOrAction)
                this.transform.SetParent(hand);
                // this.transform.SetParent(speechHand);
                //else
                //this.transform.SetParent(actionHand);
            }
        }

        if (Academy.direction == "south" || Academy.direction == "east")
        {
            if (swipeAngle > -45 && swipeAngle <= 45)
            {

            }
            else if (swipeAngle > 45 && swipeAngle <= 135)
            {
                //  Debug.Log("up");
            }
            else if (swipeAngle > 135 || swipeAngle <= -135)
            {

            }
            else if (swipeAngle < -45 && swipeAngle >= -135)
            {
                // Debug.Log("down");
            }
        }
    }
}
