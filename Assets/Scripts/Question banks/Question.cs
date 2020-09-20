using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public int number;
    public string questionName;
    public string answer;
    public string fairyTalk;
    public List<string> answerList = new List<string>();
    public Sprite sprite;
    public List<string> answerOptions = new List<string>();
    public List<Sprite> answerOptionsSprites = new List<Sprite>();
    public List<string> tags = new List<string>();
    public int size;
    public bool answered;
    public bool known;
    public string answerSound;
}