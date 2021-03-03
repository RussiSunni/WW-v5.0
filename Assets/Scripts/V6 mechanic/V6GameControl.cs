using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V6GameControl : MonoBehaviour
{
    //public Transform wordPanel1, wordPanel2;
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
    List<Sprite> currentWordSprites = new List<Sprite>();
    public static List<string> currentWordFairyAnimations = new List<string>();
    List<string> currentWords = new List<string>();
    IDictionary<string, Sprite> wordImages = new Dictionary<string, Sprite>();
    public static List<DictionaryLookup> dictionaryLookupsList = new List<DictionaryLookup>();

    string word;
    char[] board;

    public Image centerWordImage, leftWordImage, rightWordImage, backgroundWordImage;
    Sprite catSprite, dogSprite, bearSprite, frogSprite, goatSprite, duckSprite, snakeSprite, mouseSprite, horseSprite, tigerSprite, zebraSprite, lizardSprite, donkeySprite, monkeySprite, wolfSprite, batSprite, camelSprite, chickenSprite, dolphinSprite, sharkSprite, forestSprite;
    Sprite motherSprite, sisterSprite, familySprite;

    public Animator fairyAnimator;


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


        var fairy = GameObject.Find("Fairy");
        V6Fairy fairyScript = fairy.GetComponent<V6Fairy>();

        // reset Fairy animation
        fairyScript.NoAnimation();

        // currentWords = words that have been made
        // currentWordSprites = current sprites that should be showing on the stage
        // wordImages = the db of the dictionary, that is loaded into memory in this class


        // maybe a list of objects. Include isFairy.


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



        // run the function
        // Search(board1, dictionaryLookups);
        Search(board1, dictionaryLookupsList);
        //  Search(board2, dictionaryLookups);
        Search(board2, dictionaryLookupsList);
        //   Search(board3, dictionaryLookups);
        Search(board3, dictionaryLookupsList);

        // for this string in Current Words, use this
        for (int i = 0; i < currentWords.Count; i++)
        {
            // if (!currentWordSprites.Contains(wordImages[currentWords[i]]))
            //     currentWordSprites.Add(wordImages[currentWords[i]]);

            foreach (var lookup in dictionaryLookupsList)
            {
                if (currentWords[i] == lookup.Name)
                {
                    if (lookup.isFairy == false)
                        currentWordSprites.Add(Resources.Load<Sprite>("Images/Sprites/" + lookup.Sprite));
                    else
                    {
                        currentWordFairyAnimations.Add(lookup.Sprite);
                    }
                }
            }
        }



        // //RULES ----------------     


        // clear for next update
        currentWordFairyAnimations.Clear();

        currentWordSprites.Clear();
        currentWords.Clear();
    }


    private bool Search(char[] board, List<DictionaryLookup> dictionaryLookupsList)
    {
        for (int i = 0; i < board.Length; i++)
        {
            foreach (DictionaryLookup dictionaryLookup in dictionaryLookupsList)
            {
                if (board[i] == dictionaryLookup.Name[0] && dfs(board, i, 0, dictionaryLookup.Name))
                {
                    print(dictionaryLookup.Name);
                }
            }
        }
        return false;
    }



    public bool dfs(char[] board, int i, int count, string word)
    {
        //print(word);

        if (count == word.Length)
            return true;

        if (i < 0 || i >= board.Length || board[i] != word[count])
            return false;


        char temp = board[i];
        board[i] = ' ';

        bool found = dfs(board, i + 1, count + 1, word);

        board[i] = temp;

        if (found && !currentWords.Contains(word))
        {
            print(word);
            currentWords.Add(word);
        }


        return found;
    }


    public void pressGoButton()
    {
       
    }



    // optimise to a loop
    public void pressAButton()
    {
        GameObject aBlock = Instantiate(Resources.Load("Prefabs/Letters/A")) as GameObject;
        //aBlock.transform.SetParent(A4);
        setParent1(aBlock);
    }
    public void pressBButton()
    {
        GameObject bBlock = Instantiate(Resources.Load("Prefabs/Letters/B")) as GameObject;
        setParent1(bBlock);
    }
    public void pressCButton()
    {
        GameObject cBlock = Instantiate(Resources.Load("Prefabs/Letters/C")) as GameObject;
        setParent1(cBlock);
    }
    public void pressDButton()
    {
        GameObject dBlock = Instantiate(Resources.Load("Prefabs/Letters/D")) as GameObject;
        setParent1(dBlock);
    }
    public void pressEButton()
    {
        GameObject eBlock = Instantiate(Resources.Load("Prefabs/Letters/E")) as GameObject;
        setParent1(eBlock);
    }
    public void pressFButton()
    {
        GameObject fBlock = Instantiate(Resources.Load("Prefabs/Letters/F")) as GameObject;
        setParent1(fBlock);
    }
    public void pressGButton()
    {
        GameObject gBlock = Instantiate(Resources.Load("Prefabs/Letters/G")) as GameObject;
        setParent1(gBlock);
    }
    public void pressHButton()
    {
        GameObject hBlock = Instantiate(Resources.Load("Prefabs/Letters/H")) as GameObject;
        setParent1(hBlock);
    }
    public void pressIButton()
    {
        GameObject iBlock = Instantiate(Resources.Load("Prefabs/Letters/I")) as GameObject;
        setParent1(iBlock);
    }
    public void pressJButton()
    {
        GameObject jBlock = Instantiate(Resources.Load("Prefabs/Letters/J")) as GameObject;
        setParent1(jBlock);
    }
    public void pressKButton()
    {
        GameObject kBlock = Instantiate(Resources.Load("Prefabs/Letters/K")) as GameObject;
        setParent1(kBlock);
    }
    public void pressLButton()
    {
        GameObject lBlock = Instantiate(Resources.Load("Prefabs/Letters/L")) as GameObject;
        setParent1(lBlock);
    }
    public void pressMButton()
    {
        GameObject mBlock = Instantiate(Resources.Load("Prefabs/Letters/M")) as GameObject;
        setParent1(mBlock);
    }
    public void pressNButton()
    {
        GameObject nBlock = Instantiate(Resources.Load("Prefabs/Letters/N")) as GameObject;
        setParent2(nBlock);
    }
    public void pressOButton()
    {
        GameObject oBlock = Instantiate(Resources.Load("Prefabs/Letters/O")) as GameObject;
        setParent2(oBlock);
    }
    public void pressPButton()
    {
        GameObject pBlock = Instantiate(Resources.Load("Prefabs/Letters/P")) as GameObject;
        setParent2(pBlock);
    }
    public void pressQButton()
    {
        GameObject qBlock = Instantiate(Resources.Load("Prefabs/Letters/Q")) as GameObject;
        setParent2(qBlock);
    }
    public void pressRButton()
    {
        GameObject rBlock = Instantiate(Resources.Load("Prefabs/Letters/R")) as GameObject;
        setParent2(rBlock);
    }
    public void pressSButton()
    {
        GameObject sBlock = Instantiate(Resources.Load("Prefabs/Letters/S")) as GameObject;
        setParent2(sBlock);
    }
    public void pressTButton()
    {
        GameObject tBlock = Instantiate(Resources.Load("Prefabs/Letters/T")) as GameObject;
        setParent2(tBlock);
    }
    public void pressUButton()
    {
        GameObject uBlock = Instantiate(Resources.Load("Prefabs/Letters/U")) as GameObject;
        setParent2(uBlock);
    }
    public void pressVButton()
    {
        GameObject vBlock = Instantiate(Resources.Load("Prefabs/Letters/V")) as GameObject;
        setParent2(vBlock);
    }
    public void pressWButton()
    {
        GameObject wBlock = Instantiate(Resources.Load("Prefabs/Letters/W")) as GameObject;
        setParent2(wBlock);
    }
    public void pressXButton()
    {
        GameObject xBlock = Instantiate(Resources.Load("Prefabs/Letters/X")) as GameObject;
        setParent2(xBlock);
    }
    public void pressYButton()
    {
        GameObject yBlock = Instantiate(Resources.Load("Prefabs/Letters/Y")) as GameObject;
        setParent2(yBlock);
    }
    public void pressZButton()
    {
        GameObject zBlock = Instantiate(Resources.Load("Prefabs/Letters/Z")) as GameObject;
        setParent2(zBlock);
    }

    private void setParent1(GameObject block)
    {
        for (int i = 2; i < Rows.Count; i--)
        {
            for (int h = 0; h < Rows[i].Count; h++)
            {
                if (Rows[i][h].childCount == 0)
                {
                    // block.transform.SetParent(Rows[i][h]);
                    block.transform.SetParent(Rows[i][h], false);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    private void setParent2(GameObject block)
    {
        for (int i = 2; i < Rows.Count; i--)
        {
            for (int h = 7; h < Rows[i].Count; h--)
            {
                if (Rows[i][h].childCount == 0)
                {
                    //block.transform.SetParent(Rows[i][h]);
                    block.transform.SetParent(Rows[i][h], false);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}