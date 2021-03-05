using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class V6Swipe : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // required interface when using the OnPointerDown method.
{
    GameObject block;
    private Vector3 firstTouchPosition;
    private Vector3 finalTouchPosition;
    float swipeAngle = 0;
    Transform B4;

    int currentRow;
    int currentCol;
    int rowIndex;
    int colIndex;

    void Start()
    {
        block = this.gameObject;
    }

    // UI elements
    public void OnPointerDown(PointerEventData eventData)
    {
        var mousePos = Input.mousePosition;

        if (Academy.direction == "north" || Academy.direction == "south")
            firstTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));

        else if (Academy.direction == "west" || Academy.direction == "east")
            firstTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(10.8f, Input.mousePosition.y, Input.mousePosition.x));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Academy.direction == "north" || Academy.direction == "south")
            finalTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.8f));

        else if (Academy.direction == "west" || Academy.direction == "east")
            finalTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(10.8f, Input.mousePosition.y, Input.mousePosition.x));

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
        // column and row

        var letterUI = GameObject.Find("LetterUI");
        LetterUI letterUIScript = letterUI.GetComponent<LetterUI>();


        var parent = block.transform.parent;

        for (int i = 0; i < letterUIScript.Rows.Count; i++)
        {
            if (letterUIScript.Rows[i].Contains(parent))
            {
                currentRow = i;
                rowIndex = letterUIScript.Rows[i].IndexOf(parent);
            }
        }

        for (int i = 0; i < letterUIScript.Cols.Count; i++)
        {
            if (letterUIScript.Cols[i].Contains(parent))
            {
                currentCol = i;
                colIndex = letterUIScript.Cols[i].IndexOf(parent);
            }
        }


        if (Academy.direction == "north")
        {
            if (swipeAngle > -45 && swipeAngle <= 45)
            {
                var newRowIndex = rowIndex + 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
            else if (swipeAngle > 45 && swipeAngle <= 135)
            {
                var newColIndex = colIndex - 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
            else if (swipeAngle > 135 || swipeAngle <= -135)
            {
                var newRowIndex = rowIndex - 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
            else if (swipeAngle < -45 && swipeAngle >= -135)
            {
                var newColIndex = colIndex + 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
        }
        else if (Academy.direction == "south")
        {
            if (swipeAngle > 135 || swipeAngle <= -135)
            {
                var newRowIndex = rowIndex + 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
            else if (swipeAngle > 45 && swipeAngle <= 135)
            {
                var newColIndex = colIndex - 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
            else if (swipeAngle > -45 && swipeAngle <= 45)
            {
                var newRowIndex = rowIndex - 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
            else if (swipeAngle < -45 && swipeAngle >= -135)
            {
                var newColIndex = colIndex + 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
        }
        else if (Academy.direction == "east")
        {
            if (swipeAngle > 45 && swipeAngle <= 135) // 
            {
                var newColIndex = colIndex - 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
            else if (swipeAngle > -45 && swipeAngle <= 45) //right
            {
                var newRowIndex = rowIndex + 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
            else if (swipeAngle < -45 && swipeAngle >= -135) // 
            {
                var newColIndex = colIndex + 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
            else if (swipeAngle > 135 || swipeAngle <= -135) // left
            {
                var newRowIndex = rowIndex - 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
        }
        if (Academy.direction == "west")
        {
            if (swipeAngle > -45 && swipeAngle <= 45)
            {
                Debug.Log("left");
                var newRowIndex = rowIndex - 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
            else if (swipeAngle > 45 && swipeAngle <= 135)
            {
                var newColIndex = colIndex - 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
            else if (swipeAngle > 135 || swipeAngle <= -135)
            {

                var newRowIndex = rowIndex + 1;
                this.transform.SetParent(letterUIScript.Rows[currentRow][newRowIndex]);
            }
            else if (swipeAngle < -45 && swipeAngle >= -135)
            {
                var newColIndex = colIndex + 1;
                this.transform.SetParent(letterUIScript.Cols[currentCol][newColIndex]);
            }
        }


        //  StartCoroutine((RegisterWord()));
    }
    // IEnumerator RegisterWord()
    // {
    //     yield return new WaitForSeconds(0.1f);

    //     GameObject letterUI = GameObject.Find("LetterUI");
    //     LetterUI letterUIScript = letterUI.GetComponent<LetterUI>();
    //     letterUIScript.UpdateStage();
    // }
}
