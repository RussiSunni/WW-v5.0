using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class SwipeTest : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    GameObject card, parentTile, otherCard;
    public Transform newParent;
    GameObject[] allTiles;

    GameObject tile1_1, tile1_2, tile1_3, tile1_4, tile1_5;

    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    float swipeAngle = 0;

    int column;
    int row;
    int targetX;
    int targetY;

    public bool canMove;

    void Start()
    {
        card = this.gameObject;

        tile1_1 = GameObject.Find("1-1");
        tile1_2 = GameObject.Find("1-2");
        tile1_3 = GameObject.Find("1-3");
        tile1_4 = GameObject.Find("1-4");
        tile1_5 = GameObject.Find("1-5");

        int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
        allTiles = new GameObject[] { tile1_1, tile1_2, tile1_3, tile1_4, tile1_5 };

        //targetX = (int)transform.position.x;
        // targetY = (int)transform.position.y;

        parentTile = card.transform.parent.gameObject;
        targetX = (int)parentTile.GetComponent<RectTransform>().anchoredPosition.x;
        targetY = (int)parentTile.GetComponent<RectTransform>().anchoredPosition.y;

        //row = targetX;
        // column = targetY;

        if (targetX == -216)
            column = 0;
        else if (targetX == -108)
            column = 1;
        else if (targetX == 0)
            column = 2;
        else if (targetX == 108)
            column = 3;
        else if (targetX == 216)
            column = 4;

        if (targetY == 0)
            row = 0;
        else if (targetX == -108)
            row = 1;
    }

    // UI elements
    public void OnPointerDown(PointerEventData eventData)
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (canMove)
            CalculateAngle();
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
        MovePieces();
    }

    // ui
    void MovePieces()
    {
        parentTile = card.transform.parent.gameObject;

        if (swipeAngle > -45 && swipeAngle <= 45)
        {
            column = column + 1;
            newParent = allTiles[column].transform;
            if (newParent.gameObject.transform.childCount > 0)
            {
                otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                otherCard.transform.SetParent(parentTile.transform, false);
            }
            card.transform.SetParent(newParent, false);
        }
        else if (swipeAngle > 45 && swipeAngle <= 135)
        {
            Debug.Log("up");
        }
        else if (swipeAngle > 135 || swipeAngle <= -135)
        {
            column = column - 1;
            newParent = allTiles[column].transform;
            if (newParent.gameObject.transform.childCount > 0)
            {
                otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                otherCard.transform.SetParent(parentTile.transform, false);
            }
            card.transform.SetParent(newParent, false);
        }
        else if (swipeAngle < -45 && swipeAngle >= -135)
        {
            Debug.Log("down");
        }
    }



    //objects
    // private void OnMouseDown()
    // {
    //     firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     //Debug.Log(firstTouchPosition);
    //     Debug.Log(row);
    // }

    // private void OnMouseUp()
    // {
    //     finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     //  Debug.Log(firstTouchPosition);
    //     CalculateAngle();
    // }

    // objects
    // void MovePieces()
    // {
    //     parentTile = card.transform.parent.gameObject;

    //     if (swipeAngle > -45 && swipeAngle <= 45)
    //     {
    //         row = row + 1;
    //         newParent = allTiles[row].transform;
    //         if (newParent.gameObject.transform.childCount > 0)
    //         {
    //             otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
    //             otherCard.transform.SetParent(parentTile.transform, false);
    //         }
    //         card.transform.SetParent(newParent, false);
    //     }
    //     else if (swipeAngle > 45 && swipeAngle <= 135)
    //     {
    //         Debug.Log("up");
    //     }
    //     else if (swipeAngle > 135 || swipeAngle <= -135)
    //     {
    //         row = row - 1;
    //         newParent = allTiles[row].transform;
    //         if (newParent.gameObject.transform.childCount > 0)
    //         {
    //             otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
    //             otherCard.transform.SetParent(parentTile.transform, false);
    //         }
    //         card.transform.SetParent(newParent, false);
    //     }
    //     else if (swipeAngle < -45 && swipeAngle >= -135)
    //     {
    //         Debug.Log("down");
    //     }
    // }

    void Update()
    {
        // if (Input.GetMouseButtonDown(0))
        // {
        //     //  Debug.Log("Pressed primary button.");
        //     child.transform.SetParent(newParent, false);
        // }
    }


}
