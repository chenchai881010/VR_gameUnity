using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public static QuestionManager Instance;

    public GameObject[] questions;
    public bool[] Getanswer;
    public int gameScore;
    //ui顯示
    public Text item;
    public Text num;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameScore = 0;
        Getanswer = new bool[questions.Length];
        item.text = Getanswer.Length.ToString();
        num.text = gameScore.ToString();
    }

    //計分
    public void getPoint(int score)
    {
        gameScore += score;
        int a=0;
        for (int i = 0; i < Getanswer.Length; i++)
        {
            if (Getanswer[i]==false)
            {
                a++;
            }
        }
        item.text = a.ToString();
        num.text = gameScore.ToString();
    }
}
