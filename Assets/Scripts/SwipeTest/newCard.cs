using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class newCard : MonoBehaviour
{
    public int column;
    public int row;
    public int targetX;
    public int targetY;
    private GameObject otherCard;
    private newBoard board;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    public float swipeAngle = 0;

    void Start()
    {
        board = FindObjectOfType<newBoard>();

        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;

        row = targetX;
        column = targetY;
    }

    void Update()
    {
        targetX = column;
        targetY = row;

        if (Mathf.Abs(targetX - transform.position.x) > .1)
        {
            // move towards the target
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
        }
        else
        {
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;

            board.allCards[column, row] = this.gameObject;
        }

        if (Mathf.Abs(targetY - transform.position.y) > .1)
        {
            // move towards the target
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, .4f);
        }
        else
        {
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;

            board.allCards[column, row] = this.gameObject;
        }

    }

    private void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //   Debug.Log(firstTouchPosition);
    }

    private void OnMouseUp()
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
        // Debug.Log(swipeAngle);

        MovePieces();
    }

    void MovePieces()
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && column < 5)
        {
            // right swipe
            otherCard = board.allCards[column + 1, row];
            otherCard.GetComponent<newCard>().column -= 1;
            column += 1;
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && row < 5)
        {
            // up swipe
            otherCard = board.allCards[column, row + 1];
            otherCard.GetComponent<newCard>().row -= 1;
            row += 1;
        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && column > 0)
        {
            // left swipe
            otherCard = board.allCards[column - 1, row];
            otherCard.GetComponent<newCard>().column += 1;
            column += 1;
        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && row > 0)
        {
            // down swipe
            otherCard = board.allCards[column, row - 1];
            otherCard.GetComponent<newCard>().row += 1;
            row -= 1;
        }
    }
}