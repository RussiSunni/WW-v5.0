using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteLetters : MonoBehaviour
{
    public GameObject a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z, CanvasCode;
    public Transform firstPosition, secondPosition, thirdPosition, fourthPosition, fifthPosition, sixthPosition, seventhPosition, eighthPosition, ninthPosition, tenthPosition, eleventhPosition, twelthPosition;
    bool firstPositionTaken, secondPositionTaken, thirdPositionTaken, fourthPositionTaken, fifthPositionTaken, sixthPositionTaken, seventhPositionTaken, eighthPositionTaken, ninthPositionTaken, tenthPositionTaken, eleventhPositionTaken, twelthPositionTaken;

    public static GameObject aWritten, bWritten, cWritten, dWritten, eWritten, fWritten, gWritten, hWritten, iWritten, jWritten, kWritten, lWritten, mWritten, nWritten, oWritten, pWritten, qWritten, rWritten, sWritten, tWritten, uWritten, vWritten, wWritten, xWritten, yWritten, zWritten;
    char[] playerName = new char[12];
    List<char> playerNameList = new List<char>();
    public static string playerNameString;

    GameObject objectInFirstPosition, objectInSecondPosition, objectInThirdPosition, objectInFourthPosition, objectInFifthPosition, objectInSixthPosition, objectInSeventhPosition, objectInEighthPosition, objectInNinthPosition, objectInTenthPosition, objectInEleventhPosition, objectInTwelthPosition;

    public void CalculatePosition(GameObject writtenLetter, char letterName)
    {
        if (!firstPositionTaken)
        {
            writtenLetter.transform.position = firstPosition.position;
            objectInFirstPosition = writtenLetter;
            firstPositionTaken = true;
            // playerName[0] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!secondPositionTaken)
        {
            writtenLetter.transform.position = secondPosition.position;
            objectInSecondPosition = writtenLetter;
            secondPositionTaken = true;
            //playerNameList[1] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!thirdPositionTaken)
        {
            writtenLetter.transform.position = thirdPosition.position;
            objectInThirdPosition = writtenLetter;
            thirdPositionTaken = true;
            //  playerNameList[2] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!fourthPositionTaken)
        {
            writtenLetter.transform.position = fourthPosition.position;
            objectInFourthPosition = writtenLetter;
            fourthPositionTaken = true;
            //  playerNameList[3] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!fifthPositionTaken)
        {
            writtenLetter.transform.position = fifthPosition.position;
            objectInFifthPosition = writtenLetter;
            fifthPositionTaken = true;
            //  playerNameList[4] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!sixthPositionTaken)
        {
            writtenLetter.transform.position = sixthPosition.position;
            objectInSixthPosition = writtenLetter;
            sixthPositionTaken = true;
            ///  playerNameList[5] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!seventhPositionTaken)
        {
            writtenLetter.transform.position = seventhPosition.position;
            objectInSeventhPosition = writtenLetter;
            seventhPositionTaken = true;
            // playerNameList[6] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!eighthPositionTaken)
        {
            writtenLetter.transform.position = eighthPosition.position;
            objectInEighthPosition = writtenLetter;
            eighthPositionTaken = true;
            //   playerNameList[7] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!ninthPositionTaken)
        {
            writtenLetter.transform.position = ninthPosition.position;
            objectInNinthPosition = writtenLetter;
            ninthPositionTaken = true;
            //   playerNameList[8] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!tenthPositionTaken)
        {
            writtenLetter.transform.position = tenthPosition.position;
            objectInTenthPosition = writtenLetter;
            tenthPositionTaken = true;
            // playerNameList[9] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!eleventhPositionTaken)
        {
            writtenLetter.transform.position = eleventhPosition.position;
            objectInEleventhPosition = writtenLetter;
            eleventhPositionTaken = true;
            //  playerNameList[10] = letterName;
            playerNameList.Add(letterName);
        }
        else if (!twelthPositionTaken)
        {
            writtenLetter.transform.position = twelthPosition.position;
            objectInTwelthPosition = writtenLetter;
            twelthPositionTaken = true;
            // playerNameList[11] = letterName;
            playerNameList.Add(letterName);
        }

        playerNameString = string.Join("", playerNameList);
    }


    public void ACard()
    {
        char aName = char.Parse(a.name);
        aWritten = Instantiate(a, Academy.page3.transform);

        CalculatePosition(aWritten, aName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void BCard()
    {
        char bName = char.Parse(b.name);
        bWritten = Instantiate(b, Academy.page3.transform);
        CalculatePosition(bWritten, bName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void CCard()
    {
        char cName = char.Parse(c.name);
        cWritten = Instantiate(c, Academy.page3.transform);
        CalculatePosition(cWritten, cName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void DCard()
    {
        char dName = char.Parse(d.name);
        dWritten = Instantiate(d, Academy.page3.transform);
        CalculatePosition(dWritten, dName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void ECard()
    {
        char eName = char.Parse(e.name);
        eWritten = Instantiate(e, Academy.page3.transform);
        CalculatePosition(eWritten, eName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void FCard()
    {
        char fName = char.Parse(f.name);
        fWritten = Instantiate(f, Academy.page3.transform);
        CalculatePosition(fWritten, fName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }

    public void GCard()
    {
        char gName = char.Parse(g.name);
        gWritten = Instantiate(g, Academy.page3.transform);
        CalculatePosition(gWritten, gName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void HCard()
    {
        char hName = char.Parse(h.name);
        hWritten = Instantiate(h, Academy.page3.transform);
        CalculatePosition(hWritten, hName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void ICard()
    {
        char iName = char.Parse(i.name);
        iWritten = Instantiate(i, Academy.page3.transform);
        CalculatePosition(iWritten, iName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void JCard()
    {
        char jName = char.Parse(j.name);
        jWritten = Instantiate(j, Academy.page3.transform);
        CalculatePosition(jWritten, jName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void KCard()
    {
        char kName = char.Parse(k.name);
        kWritten = Instantiate(k, Academy.page3.transform);
        CalculatePosition(kWritten, kName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void LCard()
    {
        char lName = char.Parse(l.name);
        lWritten = Instantiate(l, Academy.page3.transform);
        CalculatePosition(lWritten, lName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void MCard()
    {
        char mName = char.Parse(m.name);
        mWritten = Instantiate(m, Academy.page3.transform);
        CalculatePosition(mWritten, mName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void NCard()
    {
        char nName = char.Parse(n.name);
        nWritten = Instantiate(n, Academy.page3.transform);
        CalculatePosition(nWritten, nName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void OCard()
    {
        char oName = char.Parse(o.name);
        oWritten = Instantiate(o, Academy.page3.transform);
        CalculatePosition(oWritten, oName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void PCard()
    {
        char pName = char.Parse(p.name);
        pWritten = Instantiate(p, Academy.page3.transform);
        CalculatePosition(pWritten, pName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void QCard()
    {
        char qName = char.Parse(q.name);
        qWritten = Instantiate(q, Academy.page3.transform);
        CalculatePosition(qWritten, qName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void RCard()
    {
        char rName = char.Parse(r.name);
        rWritten = Instantiate(r, Academy.page3.transform);
        CalculatePosition(rWritten, rName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void SCard()
    {
        char sName = char.Parse(s.name);
        sWritten = Instantiate(s, Academy.page3.transform);
        CalculatePosition(sWritten, sName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void TCard()
    {
        char tName = char.Parse(t.name);
        tWritten = Instantiate(t, Academy.page3.transform);
        CalculatePosition(tWritten, tName);
        CanvasCode.GetComponent<Academy>().SpellbookButtonRight();
        SoundManager.playConnectSound();
    }
    public void UCard()
    {
        char uName = char.Parse(u.name);
        uWritten = Instantiate(u, Academy.page3.transform);
        CalculatePosition(uWritten, uName);
        SoundManager.playConnectSound();
    }
    public void VCard()
    {
        char vName = char.Parse(v.name);
        vWritten = Instantiate(v, Academy.page3.transform);
        CalculatePosition(vWritten, vName);
        SoundManager.playConnectSound();
    }
    public void WCard()
    {
        char wName = char.Parse(w.name);
        wWritten = Instantiate(w, Academy.page3.transform);
        CalculatePosition(wWritten, wName);
        SoundManager.playConnectSound();
    }
    public void XCard()
    {
        char xName = char.Parse(x.name);
        xWritten = Instantiate(x, Academy.page3.transform);
        CalculatePosition(xWritten, xName);
        SoundManager.playConnectSound();
    }
    public void YCard()
    {
        char yName = char.Parse(y.name);
        yWritten = Instantiate(y, Academy.page3.transform);
        CalculatePosition(yWritten, yName);
        SoundManager.playConnectSound();
    }
    public void ZCard()
    {
        char zName = char.Parse(z.name);
        zWritten = Instantiate(z, Academy.page3.transform);
        CalculatePosition(zWritten, zName);
        SoundManager.playConnectSound();
    }




    public void Backspace()
    {
        if (twelthPositionTaken)
        {
            Destroy(objectInTwelthPosition);
            twelthPositionTaken = false;
            playerNameList.RemoveAt(11);
        }
        else if (eleventhPositionTaken)
        {
            Destroy(objectInEleventhPosition);
            eleventhPositionTaken = false;
            playerNameList.RemoveAt(10);
        }
        else if (tenthPositionTaken)
        {
            Destroy(objectInTenthPosition);
            tenthPositionTaken = false;
            playerNameList.RemoveAt(9);
        }
        else if (ninthPositionTaken)
        {
            Destroy(objectInNinthPosition);
            ninthPositionTaken = false;
            playerNameList.RemoveAt(8);
        }
        else if (eighthPositionTaken)
        {
            Destroy(objectInEighthPosition);
            eighthPositionTaken = false;
            playerNameList.RemoveAt(7);
        }
        else if (seventhPositionTaken)
        {
            Destroy(objectInSeventhPosition);
            seventhPositionTaken = false;
            playerNameList.RemoveAt(6);
        }
        else if (sixthPositionTaken)
        {
            Destroy(objectInSixthPosition);
            sixthPositionTaken = false;
            playerNameList.RemoveAt(5);
        }
        else if (fifthPositionTaken)
        {
            Destroy(objectInFifthPosition);
            fifthPositionTaken = false;
            playerNameList.RemoveAt(4);
        }
        else if (fourthPositionTaken)
        {
            Destroy(objectInFourthPosition);
            fourthPositionTaken = false;
            playerNameList.RemoveAt(3);
        }
        else if (thirdPositionTaken)
        {
            Destroy(objectInThirdPosition);
            thirdPositionTaken = false;
            playerNameList.RemoveAt(2);
        }
        else if (secondPositionTaken)
        {
            Destroy(objectInSecondPosition);
            secondPositionTaken = false;
            playerNameList.RemoveAt(1);
        }
        else if (firstPositionTaken)
        {
            Destroy(objectInFirstPosition);
            firstPositionTaken = false;
            playerNameList.RemoveAt(0);
        }

        playerNameString = string.Join("", playerNameList);
    }

}