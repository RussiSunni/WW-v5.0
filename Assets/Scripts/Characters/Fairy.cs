using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public Transform A, B, C;
    List<Transform> GridRow = new List<Transform>();
    GameObject helloCard, openCard, theCard, doorCard;
    private SpriteRenderer spriteRenderer;

    // Delete later
    public static List<Transform> cards = new List<Transform>();


    void Start()
    {
        GridRow.Add(A);
        GridRow.Add(B);
        GridRow.Add(C);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
       // SayHello();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SayHello() 
    {
        helloCard = Instantiate(Resources.Load("Prefabs/Cards/HelloCard")) as GameObject;
        SetGridAParent(helloCard);
        //SoundManager.playSound(SoundManager.elfHello);
    }

    public void SayOpenTheDoor()
    {
        openCard = Instantiate(Resources.Load("Prefabs/Cards/OpenCard")) as GameObject;
        theCard = Instantiate(Resources.Load("Prefabs/Cards/TheCard")) as GameObject;
        doorCard = Instantiate(Resources.Load("Prefabs/Cards/DoorCard")) as GameObject;
        SetGridAParent(openCard);
        SetGridBParent(theCard);
        SetGridCParent(doorCard);
        //SoundManager.playSound(SoundManager.elfHello);
    }

    private void SetGridAParent(GameObject block)
    {
        block.transform.SetParent(GridRow[0], false);
    }

    private void SetGridBParent(GameObject block)
    {
        block.transform.SetParent(GridRow[1], false);
    }

    private void SetGridCParent(GameObject block)
    {
        block.transform.SetParent(GridRow[2], false);
    }


    void OnMouseDown()
    {
      //  SoundManager.playSound(SoundManager.elfHey);
    }
}
