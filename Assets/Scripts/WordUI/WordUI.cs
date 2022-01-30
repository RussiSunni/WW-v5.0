using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordUI : MonoBehaviour
{
    public Transform A, B, C, D, E;
    List<Transform> GridRow = new List<Transform>();
    public Button helloCardBtn;
    public Sprite emptyCardSprite, helloCardSprite;


    void Start()
    {
        GridRow.Add(A);
        GridRow.Add(B);
        GridRow.Add(C);
        GridRow.Add(D);
        GridRow.Add(E);
    }

    public void TurnOnHelloButton()
    {
        helloCardBtn.interactable = true;
        helloCardBtn.image.sprite = helloCardSprite;
    }

    public void TurnOffHelloButton()
    {
        helloCardBtn.interactable = false;
        helloCardBtn.image.sprite = emptyCardSprite;
    }

    public void HelloButton()
    {
        GameObject helloCard = Instantiate(Resources.Load("Prefabs/Cards/HelloCard")) as GameObject;
        SetGridParent(helloCard);
        SoundManager.playSound(SoundManager.effectPop);

        TurnOffHelloButton();
    }

    public void ReturnHelloButton()
    {
        SoundManager.playSound(SoundManager.effectPop);
        ClearBlocks();
        TurnOnHelloButton();
    }


    // for 3 rows
    private void SetGridParent(GameObject block)
    {
        for (int i = 0; i < 5; i++)
        {
            if (GridRow[i].childCount == 0)
            {
                block.transform.SetParent(GridRow[i], false);
                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void ClearBlocks()
    {
        for (int i = 0; i < GridRow.Count; i++)
        {
            if (GridRow[i].childCount > 0)
            {
                Destroy(GridRow[i].transform.GetChild(0).gameObject);
            }
        }
    }
}
