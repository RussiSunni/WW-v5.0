using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class newBoard : MonoBehaviour
{
    int width;
    int height;
    public GameObject tilePrefab;
    public GameObject[] cards;
    private BackgroundTile[,] allTiles;
    public GameObject[,] allCards;

    void Start()
    {
        width = 5;
        height = 5;

        allTiles = new BackgroundTile[2, 2];
        allCards = new GameObject[2, 2];
        Setup();
    }

    private void Setup()
    {
        int cardToUse = 0;

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector2 tempPosition = new Vector2(i, j);

                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity);

                backgroundTile.transform.parent = this.transform;

                backgroundTile.name = "( " + i + ", " + j + " )";

                GameObject card = Instantiate(cards[cardToUse], tempPosition, Quaternion.identity);

                // card.transform.parent = this.transform;
                // card.name = this.gameObject.name;

                // allCards[i, j] = card;

                cardToUse++;
            }
        }
    }
}
