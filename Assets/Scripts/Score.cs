using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scorePanel;
    private int score = 0;

    public void UpdateScorePanel(int addedScore)
    {
        score = score + addedScore;
        scorePanel.text = score.ToString();
    }
}