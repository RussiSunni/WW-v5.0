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
    public static string playerNameString;

    public void CalculatePosition(GameObject writtenLetter, char letterName)
    {
        if (!firstPositionTaken)
        {
            writtenLetter.transform.position = firstPosition.position;
            firstPositionTaken = true;
            playerName[0] = letterName;

        }
        else if (!secondPositionTaken)
        {
            writtenLetter.transform.position = secondPosition.position;
            secondPositionTaken = true;
            playerName[1] = letterName;

        }
        else if (!thirdPositionTaken)
        {
            writtenLetter.transform.position = thirdPosition.position;
            thirdPositionTaken = true;
            playerName[2] = letterName;
        }
        else if (!fourthPositionTaken)
        {
            writtenLetter.transform.position = fourthPosition.position;
            fourthPositionTaken = true;
            playerName[3] = letterName;
        }
        else if (!fifthPositionTaken)
        {
            writtenLetter.transform.position = fifthPosition.position;
            fifthPositionTaken = true;
            playerName[4] = letterName;
        }
        else if (!sixthPositionTaken)
        {
            writtenLetter.transform.position = sixthPosition.position;
            sixthPositionTaken = true;
            playerName[5] = letterName;
        }
        else if (!seventhPositionTaken)
        {
            writtenLetter.transform.position = seventhPosition.position;
            seventhPositionTaken = true;
            playerName[6] = letterName;
        }
        else if (!eighthPositionTaken)
        {
            writtenLetter.transform.position = eighthPosition.position;
            eighthPositionTaken = true;
            playerName[7] = letterName;
        }
        else if (!ninthPositionTaken)
        {
            writtenLetter.transform.position = ninthPosition.position;
            ninthPositionTaken = true;
            playerName[8] = letterName;
        }
        else if (!tenthPositionTaken)
        {
            writtenLetter.transform.position = tenthPosition.position;
            tenthPositionTaken = true;
            playerName[9] = letterName;
        }
        else if (!eleventhPositionTaken)
        {
            writtenLetter.transform.position = eleventhPosition.position;
            eleventhPositionTaken = true;
            playerName[10] = letterName;
        }
        else if (!twelthPositionTaken)
        {
            writtenLetter.transform.position = twelthPosition.position;
            twelthPositionTaken = true;
            playerName[11] = letterName;
        }

        playerNameString = string.Join("", playerName);
    }


    public void ACard()
    {
        char aName = char.Parse(a.name);
        aWritten = Instantiate(a, Academy.page3.transform);

        CalculatePosition(aWritten, aName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();

    }
    public void BCard()
    {
        char bName = char.Parse(b.name);
        bWritten = Instantiate(b, Academy.page3.transform);
        CalculatePosition(bWritten, bName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void CCard()
    {
        char cName = char.Parse(c.name);
        cWritten = Instantiate(c, Academy.page3.transform);
        CalculatePosition(cWritten, cName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void DCard()
    {
        char dName = char.Parse(d.name);
        dWritten = Instantiate(d, Academy.page3.transform);
        CalculatePosition(dWritten, dName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void ECard()
    {
        char eName = char.Parse(e.name);
        eWritten = Instantiate(e, Academy.page3.transform);
        CalculatePosition(eWritten, eName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void FCard()
    {
        char fName = char.Parse(f.name);
        fWritten = Instantiate(f, Academy.page3.transform);
        CalculatePosition(fWritten, fName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }

    public void GCard()
    {
        char gName = char.Parse(g.name);
        gWritten = Instantiate(g, Academy.page3.transform);
        CalculatePosition(gWritten, gName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void HCard()
    {
        char hName = char.Parse(h.name);
        hWritten = Instantiate(h, Academy.page3.transform);
        CalculatePosition(hWritten, hName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void ICard()
    {
        char iName = char.Parse(i.name);
        iWritten = Instantiate(i, Academy.page3.transform);
        CalculatePosition(iWritten, iName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void JCard()
    {
        char jName = char.Parse(j.name);
        jWritten = Instantiate(j, Academy.page3.transform);
        CalculatePosition(jWritten, jName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void KCard()
    {
        char kName = char.Parse(k.name);
        kWritten = Instantiate(k, Academy.page3.transform);
        CalculatePosition(kWritten, kName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void LCard()
    {
        char lName = char.Parse(l.name);
        lWritten = Instantiate(l, Academy.page3.transform);
        CalculatePosition(lWritten, lName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void MCard()
    {
        char mName = char.Parse(m.name);
        mWritten = Instantiate(m, Academy.page3.transform);
        CalculatePosition(mWritten, mName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void NCard()
    {
        char nName = char.Parse(n.name);
        nWritten = Instantiate(n, Academy.page3.transform);
        CalculatePosition(nWritten, nName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void OCard()
    {
        char oName = char.Parse(o.name);
        oWritten = Instantiate(o, Academy.page3.transform);
        CalculatePosition(oWritten, oName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void PCard()
    {
        char pName = char.Parse(p.name);
        pWritten = Instantiate(p, Academy.page3.transform);
        CalculatePosition(pWritten, pName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void QCard()
    {
        char qName = char.Parse(q.name);
        qWritten = Instantiate(q, Academy.page3.transform);
        CalculatePosition(qWritten, qName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void RCard()
    {
        char rName = char.Parse(r.name);
        rWritten = Instantiate(r, Academy.page3.transform);
        CalculatePosition(rWritten, rName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void SCard()
    {
        char sName = char.Parse(s.name);
        sWritten = Instantiate(s, Academy.page3.transform);
        CalculatePosition(sWritten, sName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
        SoundManager.playConnectSound();
    }
    public void TCard()
    {
        char tName = char.Parse(t.name);
        tWritten = Instantiate(t, Academy.page3.transform);
        CalculatePosition(tWritten, tName);
        CanvasCode.GetComponent<Academy>().SpellbookButton();
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
}