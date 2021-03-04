﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterUI : MonoBehaviour
{
    public Transform A4, A5, A6, B4, B5, B6, C4, C5, C6, D4, D5, D6, E4, E5, E6, F4, F5, F6, G4, G5, G6, H4, H5, H6;
    public Transform A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z;
    public List<Transform> Col1 = new List<Transform>();
    public List<Transform> Col2 = new List<Transform>();
    public List<Transform> Col3 = new List<Transform>();
    public List<Transform> Col4 = new List<Transform>();
    public List<Transform> Col5 = new List<Transform>();
    public List<Transform> Col6 = new List<Transform>();
    public List<Transform> Col7 = new List<Transform>();
    public List<Transform> Col8 = new List<Transform>();
    public List<List<Transform>> Cols = new List<List<Transform>>();
    public List<Transform> Row1 = new List<Transform>();
    public List<Transform> Row2 = new List<Transform>();
    public List<Transform> Row3 = new List<Transform>();
    public List<List<Transform>> Rows = new List<List<Transform>>();

    List<string> currentWords = new List<string>();

    string word;
    char[] board;

    void Start()
    {
        Col1.Add(A4);
        Col1.Add(A5);
        Col1.Add(A6);
        Col2.Add(B4);
        Col2.Add(B5);
        Col2.Add(B6);
        Col3.Add(C4);
        Col3.Add(C5);
        Col3.Add(C6);
        Col4.Add(D4);
        Col4.Add(D5);
        Col4.Add(D6);
        Col5.Add(E4);
        Col5.Add(E5);
        Col5.Add(E6);
        Col6.Add(F4);
        Col6.Add(F5);
        Col6.Add(F6);
        Col7.Add(G4);
        Col7.Add(G5);
        Col7.Add(G6);
        Col8.Add(H4);
        Col8.Add(H5);
        Col8.Add(H6);

        Cols.Add(Col1);
        Cols.Add(Col2);
        Cols.Add(Col3);
        Cols.Add(Col4);
        Cols.Add(Col5);
        Cols.Add(Col6);
        Cols.Add(Col7);
        Cols.Add(Col8);

        Row1.Add(A4);
        Row1.Add(B4);
        Row1.Add(C4);
        Row1.Add(D4);
        Row1.Add(E4);
        Row1.Add(F4);
        Row1.Add(G4);
        Row1.Add(H4);

        Row2.Add(A5);
        Row2.Add(B5);
        Row2.Add(C5);
        Row2.Add(D5);
        Row2.Add(E5);
        Row2.Add(F5);
        Row2.Add(G5);
        Row2.Add(H5);

        Row3.Add(A6);
        Row3.Add(B6);
        Row3.Add(C6);
        Row3.Add(D6);
        Row3.Add(E6);
        Row3.Add(F6);
        Row3.Add(G6);
        Row3.Add(H6);

        Rows.Add(Row1);
        Rows.Add(Row2);
        Rows.Add(Row3);
    }



    public void UpdateStage()
    {
        // load current board

        // Row 1
        char[] board1 = new char[8];
        for (int i = 0; i < 8; i++)
        {
            if (Row1[i].childCount > 0)
            {
                board1[i] = Row1[i].GetChild(0).gameObject.name[0];
            }
        }

        // Row 2
        char[] board2 = new char[8];
        for (int i = 0; i < 8; i++)
        {
            if (Row2[i].childCount > 0)
            {
                board2[i] = Row2[i].GetChild(0).gameObject.name[0];
            }
        }

        // Row 3
        char[] board3 = new char[8];
        for (int i = 0; i < 8; i++)
        {
            if (Row3[i].childCount > 0)
            {
                board3[i] = Row3[i].GetChild(0).gameObject.name[0];
            }
        }


        currentWords.Clear();


    }
    // optimise to a loop
    public void pressAButton()
    {
        GameObject aBlock = Instantiate(Resources.Load("Prefabs/Letters/a")) as GameObject;
        //aBlock.transform.SetParent(A4);
        setParent1(aBlock);
    }
    public void pressBButton()
    {
        GameObject bBlock = Instantiate(Resources.Load("Prefabs/Letters/b")) as GameObject;
        setParent1(bBlock);
    }
    public void pressCButton()
    {
        GameObject cBlock = Instantiate(Resources.Load("Prefabs/Letters/c")) as GameObject;
        setParent1(cBlock);
    }
    public void pressDButton()
    {
        GameObject dBlock = Instantiate(Resources.Load("Prefabs/Letters/d")) as GameObject;
        setParent1(dBlock);
    }
    public void pressEButton()
    {
        GameObject eBlock = Instantiate(Resources.Load("Prefabs/Letters/e")) as GameObject;
        setParent1(eBlock);
    }
    public void pressFButton()
    {
        GameObject fBlock = Instantiate(Resources.Load("Prefabs/Letters/f")) as GameObject;
        setParent1(fBlock);
    }
    public void pressGButton()
    {
        GameObject gBlock = Instantiate(Resources.Load("Prefabs/Letters/g")) as GameObject;
        setParent1(gBlock);
    }
    public void pressHButton()
    {
        GameObject hBlock = Instantiate(Resources.Load("Prefabs/Letters/h")) as GameObject;
        setParent1(hBlock);
    }
    public void pressIButton()
    {
        GameObject iBlock = Instantiate(Resources.Load("Prefabs/Letters/i")) as GameObject;
        setParent1(iBlock);
    }
    public void pressJButton()
    {
        GameObject jBlock = Instantiate(Resources.Load("Prefabs/Letters/j")) as GameObject;
        setParent1(jBlock);
    }
    public void pressKButton()
    {
        GameObject kBlock = Instantiate(Resources.Load("Prefabs/Letters/k")) as GameObject;
        setParent1(kBlock);
    }
    public void pressLButton()
    {
        GameObject lBlock = Instantiate(Resources.Load("Prefabs/Letters/l")) as GameObject;
        setParent1(lBlock);
    }
    public void pressMButton()
    {
        GameObject mBlock = Instantiate(Resources.Load("Prefabs/Letters/m")) as GameObject;
        setParent1(mBlock);
    }
    public void pressNButton()
    {
        GameObject nBlock = Instantiate(Resources.Load("Prefabs/Letters/n")) as GameObject;
        setParent2(nBlock);
    }
    public void pressOButton()
    {
        GameObject oBlock = Instantiate(Resources.Load("Prefabs/Letters/o")) as GameObject;
        setParent2(oBlock);
    }
    public void pressPButton()
    {
        GameObject pBlock = Instantiate(Resources.Load("Prefabs/Letters/p")) as GameObject;
        setParent2(pBlock);
    }
    public void pressQButton()
    {
        GameObject qBlock = Instantiate(Resources.Load("Prefabs/Letters/q")) as GameObject;
        setParent2(qBlock);
    }
    public void pressRButton()
    {
        GameObject rBlock = Instantiate(Resources.Load("Prefabs/Letters/r")) as GameObject;
        setParent2(rBlock);
    }
    public void pressSButton()
    {
        GameObject sBlock = Instantiate(Resources.Load("Prefabs/Letters/s")) as GameObject;
        setParent2(sBlock);
    }
    public void pressTButton()
    {
        GameObject tBlock = Instantiate(Resources.Load("Prefabs/Letters/t")) as GameObject;
        setParent2(tBlock);
    }
    public void pressUButton()
    {
        GameObject uBlock = Instantiate(Resources.Load("Prefabs/Letters/u")) as GameObject;
        setParent2(uBlock);
    }
    public void pressVButton()
    {
        GameObject vBlock = Instantiate(Resources.Load("Prefabs/Letters/v")) as GameObject;
        setParent2(vBlock);
    }
    public void pressWButton()
    {
        GameObject wBlock = Instantiate(Resources.Load("Prefabs/Letters/w")) as GameObject;
        setParent2(wBlock);
    }
    public void pressXButton()
    {
        GameObject xBlock = Instantiate(Resources.Load("Prefabs/Letters/x")) as GameObject;
        setParent2(xBlock);
    }
    public void pressYButton()
    {
        GameObject yBlock = Instantiate(Resources.Load("Prefabs/Letters/y")) as GameObject;
        setParent2(yBlock);
    }
    public void pressZButton()
    {
        GameObject zBlock = Instantiate(Resources.Load("Prefabs/Letters/z")) as GameObject;
        setParent2(zBlock);
    }


    // for 3 rows
    // private void setParent1(GameObject block)
    // {
    //     for (int i = 2; i < Rows.Count; i--)
    //     {
    //         for (int h = 0; h < Rows[i].Count; h++)
    //         {
    //             if (Rows[i][h].childCount == 0)
    //             {
    //                 block.transform.SetParent(Rows[i][h]);
    //                 break;
    //             }
    //             else
    //             {
    //                 continue;
    //             }
    //         }
    //     }
    // }

    // private void setParent2(GameObject block)
    // {
    //     for (int i = 2; i < Rows.Count; i--)
    //     {
    //         for (int h = 7; h < Rows[i].Count; h--)
    //         {
    //             if (Rows[i][h].childCount == 0)
    //             {
    //                 block.transform.SetParent(Rows[i][h]);
    //                 break;
    //             }
    //             else
    //             {
    //                 continue;
    //             }
    //         }
    //     }
    // }

    //1 ROW---------------------

    void setParent1(GameObject block)
    {
        for (int h = 0; h < Row1.Count; h++)
        {
            if (Row1[h].childCount == 0)
            {
                block.transform.SetParent(Row1[h], false);
                break;
            }
            else
            {
                continue;
            }
        }
    }

    void setParent2(GameObject block)
    {
        for (int h = 7; h < Row1.Count; h--)
        {
            if (Row1[h].childCount == 0)
            {
                block.transform.SetParent(Row1[h], false);
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
        for (int i = 0; i < Row1.Count; i++)
        {
            if (Row1[i].childCount > 0)
            {
                Destroy(Row1[i].transform.GetChild(0).gameObject);
            }
        }
        for (int i = 0; i < Row2.Count; i++)
        {
            if (Row2[i].childCount > 0)
            {
                Destroy(Row2[i].transform.GetChild(0).gameObject);
            }
        }
    }
}
