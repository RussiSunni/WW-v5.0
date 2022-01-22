using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordUI : MonoBehaviour
{
   // public Transform A4, A5, A6, B4, B5, B6, C4, C5, C6, D4, D5, D6, E4, E5, E6, F4, F5, F6, G4, G5, G6, H4, H5, H6;
    public Transform A, B, C, D, E;
    //public List<Transform> Col1 = new List<Transform>();
    //public List<Transform> Col2 = new List<Transform>();
    //public List<Transform> Col3 = new List<Transform>();
    //public List<Transform> Col4 = new List<Transform>();
    //public List<Transform> Col5 = new List<Transform>();
    //public List<Transform> Col6 = new List<Transform>();
    //public List<Transform> Col7 = new List<Transform>();
    //public List<Transform> Col8 = new List<Transform>();
    //public List<List<Transform>> Cols = new List<List<Transform>>();
    //public List<Transform> Row1 = new List<Transform>();
    //public List<Transform> Row2 = new List<Transform>();
    //public List<Transform> Row3 = new List<Transform>();
    //public List<List<Transform>> Rows = new List<List<Transform>>();

    //public static List<string> currentWords = new List<string>();

    string word;
    char[] board;

    List<Transform> GridRow = new List<Transform>();

    void Start()
    {
        //Col1.Add(A4);
        //Col1.Add(A5);
        //Col1.Add(A6);
        //Col2.Add(B4);
        //Col2.Add(B5);
        //Col2.Add(B6);
        //Col3.Add(C4);
        //Col3.Add(C5);
        //Col3.Add(C6);
        //Col4.Add(D4);
        //Col4.Add(D5);
        //Col4.Add(D6);
        //Col5.Add(E4);
        //Col5.Add(E5);
        //Col5.Add(E6);
        //Col6.Add(F4);
        //Col6.Add(F5);
        //Col6.Add(F6);
        //Col7.Add(G4);
        //Col7.Add(G5);
        //Col7.Add(G6);
        //Col8.Add(H4);
        //Col8.Add(H5);
        //Col8.Add(H6);

        //Cols.Add(Col1);
        //Cols.Add(Col2);
        //Cols.Add(Col3);
        //Cols.Add(Col4);
        //Cols.Add(Col5);
        //Cols.Add(Col6);
        //Cols.Add(Col7);
        //Cols.Add(Col8);

        //Row1.Add(A4);
        //Row1.Add(B4);
        //Row1.Add(C4);
        //Row1.Add(D4);
        //Row1.Add(E4);
        //Row1.Add(F4);
        //Row1.Add(G4);
        //Row1.Add(H4);

        //Row2.Add(A5);
        //Row2.Add(B5);
        //Row2.Add(C5);
        //Row2.Add(D5);
        //Row2.Add(E5);
        //Row2.Add(F5);
        //Row2.Add(G5);
        //Row2.Add(H5);

        //Row3.Add(A6);
        //Row3.Add(B6);
        //Row3.Add(C6);
        //Row3.Add(D6);
        //Row3.Add(E6);
        //Row3.Add(F6);
        //Row3.Add(G6);
        //Row3.Add(H6);

        //Rows.Add(Row1);
        //Rows.Add(Row2);
        //Rows.Add(Row3);

        GridRow.Add(A);
        GridRow.Add(B);
        GridRow.Add(C);
        GridRow.Add(D);
        GridRow.Add(E);
    }



    //public void UpdateStage()
    //{
    //    // load current board

    //    // Row 1
    //    char[] board1 = new char[8];
    //    for (int i = 0; i < 8; i++)
    //    {
    //        if (Row1[i].childCount > 0)
    //        {
    //            board1[i] = Row1[i].GetChild(0).gameObject.name[0];

    //            //  print(board1[i]);
    //        }
    //    }

    //    // Row 2
    //    char[] board2 = new char[8];
    //    for (int i = 0; i < 8; i++)
    //    {
    //        if (Row2[i].childCount > 0)
    //        {
    //            board2[i] = Row2[i].GetChild(0).gameObject.name[0];

    //            // print(board2[i]);
    //        }
    //    }

    //    // Row 3
    //    char[] board3 = new char[8];
    //    for (int i = 0; i < 8; i++)
    //    {
    //        if (Row3[i].childCount > 0)
    //        {
    //            board3[i] = Row3[i].GetChild(0).gameObject.name[0];

    //            // print(board3[i]);
    //        }
    //    }



    //    currentWords.Clear();
    //}
     


    public void HelloButton()
    {
        GameObject helloCard = Instantiate(Resources.Load("Prefabs/Cards/HelloCard")) as GameObject;
        SetGridParent(helloCard);
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

    // private void setParent2(GameObject block)
    // {
    //     for (int i = 2; i < Rows.Count; i--)
    //     {
    //         for (int h = 7; h < Rows[i].Count; h--)
    //         {
    //             if (Rows[i][h].childCount == 0)
    //             {
    //                 block.transform.SetParent(Rows[i][h], false);
    //                 break;
    //             }
    //             else
    //             {
    //                 continue;
    //             }
    //         }
    //     }
    // }

    //public void ClearBlocks()
    //{
    //    for (int i = 0; i < Row1.Count; i++)
    //    {
    //        if (Row1[i].childCount > 0)
    //        {
    //            Destroy(Row1[i].transform.GetChild(0).gameObject);
    //        }
    //    }
    //    for (int i = 0; i < Row2.Count; i++)
    //    {
    //        if (Row2[i].childCount > 0)
    //        {
    //            Destroy(Row2[i].transform.GetChild(0).gameObject);
    //        }
    //    }
    //}
}
