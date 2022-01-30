using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fairy : MonoBehaviour
{
    public Transform A;
    List<Transform> GridRow = new List<Transform>();
    GameObject helloCard;
    private SpriteRenderer spriteRenderer;

    // Delete later
    public static List<Transform> cards = new List<Transform>();


    void Start()
    {
        GridRow.Add(A);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SayHello();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SayHello()
    {
        helloCard = Instantiate(Resources.Load("Prefabs/Cards/HelloCard")) as GameObject;
        SetGridParent(helloCard);
        //SoundManager.playSound(SoundManager.elfHello);
    }

    private void SetGridParent(GameObject block)
    {
        block.transform.SetParent(GridRow[0], false);
    }
        

    void OnMouseDown()
    {
      //  SoundManager.playSound(SoundManager.elfHey);
    }
}
