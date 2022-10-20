using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Questionpoint : MonoBehaviour
{//問題
    public QuestionData question;
    //ui使用
    public Canvas canvas;
    public Text Q_text;
    public Text A_text;
    public GameObject confirm;
    //移動區域
    public GameObject my_ground;
    public GameObject word_ground;
    //開啟問題
    public void openQuestion() 
    {
        canvas.enabled = true;
        Q_text.text = question.Question;
        A_text.text = "";
        my_ground.SetActive(true);
        word_ground.SetActive(false);
    }
    //輸入答案
    public void PutAnswer(int A)
    {
        A_text.text =question.Answers[A];
        confirm.SetActive(true);
    }
    //取消答案
    public void CancelAnswer()
    {
        A_text.text = "";
        confirm.SetActive(false);
    }
    //對答案
    public void checkAnswer()
    {
        if (confirm.activeSelf)
        {
            string my_answer = A_text.text;
            for (int i = 0; i < question.Answers.Length; i++)
            {
                if (question.Answers[i]==my_answer)
                {
                    QuestionManager.Instance.Getanswer[question.id] = true;
                    QuestionManager.Instance.getPoint(question.Answers_point[i]);
                }
            }
            my_ground.SetActive(false);
            word_ground.SetActive(true);
            Destroy(gameObject);
        }  
    }

}
