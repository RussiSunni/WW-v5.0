using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    private BackgroundTile[,] allTiles;

    void Start()
    {
        allTiles = new BackgroundTile[width, height];
    }

    private void Setup()
    {
        for (int i = 0; i < width; i++)
        {

        }
    }
}
