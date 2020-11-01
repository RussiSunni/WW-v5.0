using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteLetters : MonoBehaviour
{
    public GameObject a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z;
    public Transform firstPosition, secondPosition, thirdPosition, fourthPosition, fifthPosition, sixthPosition, seventhPosition, eighthPosition, ninthPosition, tenthPosition, eleventhPosition, twelthPosition;
    bool firstPositionTaken, secondPositionTaken, thirdPositionTaken, fourthPositionTaken, fifthPositionTaken, sixthPositionTaken, seventhPositionTaken, eighthPositionTaken, ninthPositionTaken, tenthPositionTaken, eleventhPositionTaken, twelthPositionTaken;

    public void CalculatePosition(GameObject writtenLetter)
    {
        if (!firstPositionTaken)
        {
            writtenLetter.transform.position = firstPosition.position;
            firstPositionTaken = true;
        }
        else if (!secondPositionTaken)
        {
            writtenLetter.transform.position = secondPosition.position;
            secondPositionTaken = true;
        }
        else if (!thirdPositionTaken)
        {
            writtenLetter.transform.position = thirdPosition.position;
            thirdPositionTaken = true;
        }
        else if (!fourthPositionTaken)
        {
            writtenLetter.transform.position = fourthPosition.position;
            fourthPositionTaken = true;
        }
        else if (!fifthPositionTaken)
        {
            writtenLetter.transform.position = fifthPosition.position;
            fifthPositionTaken = true;
        }
        else if (!sixthPositionTaken)
        {
            writtenLetter.transform.position = sixthPosition.position;
            sixthPositionTaken = true;
        }
        else if (!seventhPositionTaken)
        {
            writtenLetter.transform.position = seventhPosition.position;
            seventhPositionTaken = true;
        }
        else if (!eighthPositionTaken)
        {
            writtenLetter.transform.position = eighthPosition.position;
            eighthPositionTaken = true;
        }
        else if (!ninthPositionTaken)
        {
            writtenLetter.transform.position = ninthPosition.position;
            ninthPositionTaken = true;
        }
        else if (!tenthPositionTaken)
        {
            writtenLetter.transform.position = tenthPosition.position;
            tenthPositionTaken = true;
        }
        else if (!eleventhPositionTaken)
        {
            writtenLetter.transform.position = eleventhPosition.position;
            eleventhPositionTaken = true;
        }
        else if (!twelthPositionTaken)
        {
            writtenLetter.transform.position = twelthPosition.position;
            twelthPositionTaken = true;
        }
    }

    public void ACard()
    {
        GameObject aWritten = Instantiate(a, Academy.page3.transform);
        CalculatePosition(aWritten);
    }
    public void BCard()
    {
        GameObject bWritten = Instantiate(b, Academy.page3.transform);
        CalculatePosition(bWritten);
    }
    public void CCard()
    {
        GameObject cWritten = Instantiate(c, Academy.page3.transform);
        CalculatePosition(cWritten);
    }
    public void DCard()
    {
        GameObject dWritten = Instantiate(d, Academy.page3.transform);
        CalculatePosition(dWritten);
    }
    public void ECard()
    {
        GameObject eWritten = Instantiate(e, Academy.page3.transform);
        CalculatePosition(eWritten);
    }
    public void FCard()
    {
        GameObject fWritten = Instantiate(f, Academy.page3.transform);
        CalculatePosition(fWritten);
    }

    public void GCard()
    {
        GameObject gWritten = Instantiate(g, Academy.page3.transform);
        CalculatePosition(gWritten);
    }
    public void HCard()
    {
        GameObject hWritten = Instantiate(h, Academy.page3.transform);
        CalculatePosition(hWritten);
    }
    public void ICard()
    {
        GameObject iWritten = Instantiate(i, Academy.page3.transform);
        CalculatePosition(iWritten);
    }
    public void JCard()
    {
        GameObject jWritten = Instantiate(j, Academy.page3.transform);
        CalculatePosition(jWritten);
    }
    public void KCard()
    {
        GameObject kWritten = Instantiate(k, Academy.page3.transform);
        CalculatePosition(kWritten);
    }
    public void LCard()
    {
        GameObject lWritten = Instantiate(l, Academy.page3.transform);
        CalculatePosition(lWritten);
    }
    public void MCard()
    {
        GameObject mWritten = Instantiate(m, Academy.page3.transform);
        CalculatePosition(mWritten);
    }
    public void NCard()
    {
        GameObject nWritten = Instantiate(n, Academy.page3.transform);
        CalculatePosition(nWritten);
    }
    public void OCard()
    {
        GameObject oWritten = Instantiate(o, Academy.page3.transform);
        CalculatePosition(oWritten);
    }
    public void PCard()
    {
        GameObject pWritten = Instantiate(p, Academy.page3.transform);
        CalculatePosition(pWritten);
    }
    public void QCard()
    {
        GameObject qWritten = Instantiate(q, Academy.page3.transform);
        CalculatePosition(qWritten);
    }
    public void RCard()
    {
        GameObject rWritten = Instantiate(r, Academy.page3.transform);
        CalculatePosition(rWritten);
    }
    public void SCard()
    {
        GameObject sWritten = Instantiate(s, Academy.page3.transform);
        CalculatePosition(sWritten);
    }
    public void TCard()
    {
        GameObject tWritten = Instantiate(t, Academy.page3.transform);
        CalculatePosition(tWritten);
    }
    public void UCard()
    {
        GameObject uWritten = Instantiate(u, Academy.page3.transform);
        CalculatePosition(uWritten);
    }
    public void VCard()
    {
        GameObject vWritten = Instantiate(v, Academy.page3.transform);
        CalculatePosition(vWritten);
    }
    public void WCard()
    {
        GameObject wWritten = Instantiate(w, Academy.page3.transform);
        CalculatePosition(wWritten);
    }
    public void XCard()
    {
        GameObject xWritten = Instantiate(x, Academy.page3.transform);
        CalculatePosition(xWritten);
    }
    public void YCard()
    {
        GameObject yWritten = Instantiate(y, Academy.page3.transform);
        CalculatePosition(yWritten);
    }
    public void ZCard()
    {
        GameObject zWritten = Instantiate(z, Academy.page3.transform);
        CalculatePosition(zWritten);
    }
}