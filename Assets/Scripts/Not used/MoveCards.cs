using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class MoveCards : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    GameObject card, parentTile, otherCard;
    public Transform newParent;
    public GameObject[,] allTiles;

    GameObject tile1_1, tile1_2, tile1_3, tile1_4, tile1_5, tile2_1, tile2_2, tile2_3, tile2_4, tile2_5, tile3_1, tile3_2, tile3_3, tile3_4, tile3_5;

    //private Vector2 firstTouchPosition;
    //private Vector2 finalTouchPosition;

    private Vector3 firstTouchPosition;
    private Vector3 finalTouchPosition;
    private Vector2 tempPosition;
    float swipeAngle = 0;

    public int column;
    public int row;
    int targetX;
    int targetY;

    void Start()
    {
        card = this.gameObject;

        tile1_1 = GameObject.Find("1-1");
        tile1_2 = GameObject.Find("1-2");
        tile1_3 = GameObject.Find("1-3");
        tile1_4 = GameObject.Find("1-4");
        tile1_5 = GameObject.Find("1-5");
        tile2_1 = GameObject.Find("2-1");
        tile2_2 = GameObject.Find("2-2");
        tile2_3 = GameObject.Find("2-3");
        tile2_4 = GameObject.Find("2-4");
        tile2_5 = GameObject.Find("2-5");
        tile3_1 = GameObject.Find("3-1");
        tile3_2 = GameObject.Find("3-2");
        tile3_3 = GameObject.Find("3-3");
        tile3_4 = GameObject.Find("3-4");
        tile3_5 = GameObject.Find("3-5");

        allTiles = new GameObject[,] { { tile1_1, tile2_1, tile3_1 }, { tile1_2, tile2_2, tile3_2 }, { tile1_3, tile2_3, tile3_3 }, { tile1_4, tile2_4, tile3_4 }, { tile1_5, tile2_5, tile3_5 } };
        //allTiles = new GameObject[] { tile1_1, tile1_2, tile1_3, tile1_4, tile1_5 };

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

        if (targetY == -36)
            row = 0;
        else if (targetY == -144)
            row = 1;
        else if (targetY == -252)
            row = 2;


    }

    // UI elements
    public void OnPointerDown(PointerEventData eventData)
    {
        //  print(Academy.direction);

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


        // else if (Academy.direction == "west")
        //     mousePos.z = 10.8f; // select distance = 10 units from the camera


        //firstTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));
        //   Debug.Log(firstTouchPosition);

        // Debug.Log(mousePos.x);
        // Debug.Log(mousePos.y);
        // Debug.Log(mousePos.z);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // var mousePos = Input.mousePosition;
        // mousePos.z = 10.8f; // select distance = 10 units from the camera

        //  finalTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));

        if (Academy.direction == "north" || Academy.direction == "south")
            finalTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));

        else if (Academy.direction == "east" || Academy.direction == "west")
        {
            var temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));
            finalTouchPosition.x = temp.z;
            finalTouchPosition.y = temp.y;
            finalTouchPosition.z = 10.8f;
        }

        // else if (Academy.direction == "south")
        //     finalTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));

        // finalTouchPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (CardMoveToggle.toggle.isOn)
            CalculateAngle();

        //   Debug.Log(finalTouchPosition);
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;

        //    Debug.Log(swipeAngle);
        MovePieces();
    }

    // ui
    void MovePieces()
    {
        parentTile = card.transform.parent.gameObject;

        if (Academy.direction == "north" || Academy.direction == "west")
        {
            if (swipeAngle > -45 && swipeAngle <= 45)
            {
                column = column + 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
            else if (swipeAngle > 45 && swipeAngle <= 135)
            {
                // Debug.Log("up");

                row = row - 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
            else if (swipeAngle > 135 || swipeAngle <= -135)
            {
                column = column - 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
            else if (swipeAngle < -45 && swipeAngle >= -135)
            {
                //   Debug.Log("down");

                row = row + 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
        }

        if (Academy.direction == "south" || Academy.direction == "east")
        {
            if (swipeAngle > -45 && swipeAngle <= 45)
            {
                column = column - 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
            else if (swipeAngle > 45 && swipeAngle <= 135)
            {
                // Debug.Log("up");

                row = row - 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
            else if (swipeAngle > 135 || swipeAngle <= -135)
            {
                column = column + 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
            else if (swipeAngle < -45 && swipeAngle >= -135)
            {
                //   Debug.Log("down");

                row = row + 1;
                newParent = allTiles[column, row].transform;
                if (newParent.gameObject.transform.childCount > 0)
                {
                    otherCard = newParent.gameObject.transform.GetChild(0).gameObject;
                    otherCard.transform.SetParent(parentTile.transform, false);
                }
                card.transform.SetParent(newParent, false);
            }
        }
    }
}
