using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Vector3 initialPosition, mousePosition;
    public float deltaX, deltaY, deltaZ;
    public static bool locked, pressed, destroyed;

    public Transform[] targetBlock = new Transform[6];
    public Transform targetBlockSingle;


    // doubleclick 
    public float firstClickTime, timeBetweenClicks;
    public bool coroutineAllowed;
    public int clickCounter;

    // rotation
    public Vector3 RotateStep = new Vector3(0, 180, 0);
    public float RotateSpeed = 5f;
    public Quaternion _targetRot = Quaternion.identity;

    public string sceneName;

    public GameObject[] targetBlocks;


    protected virtual void Start()
    {
        // initialPosition = transform.position;

        // // doubleclick
        // firstClickTime = 0f;
        // timeBetweenClicks = 0.3f;
        // clickCounter = 0;
        // coroutineAllowed = true;
    }

    protected virtual void OnMouseDown()
    {
        // deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        // deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        // deltaZ = -8;
    }

    // protected virtual void OnMouseDrag()
    // {
    //     if (!locked)
    //     {
    //         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         transform.position = new Vector3(mousePosition.x - deltaX, mousePosition.y - deltaY, Academy.cameraPos.z + 1);
    //         pressed = true;
    //     }
    // }

    protected virtual void OnMouseUp()
    {
        //transform.position = new Vector3(initialPosition.x, initialPosition.y, Academy.cameraPos.z + 1);
    }


    // protected virtual void Update()
    // {
    //     // rotate
    //     transform.rotation = Quaternion.Lerp(transform.rotation, _targetRot, RotateSpeed * Time.deltaTime);
    // }
}

