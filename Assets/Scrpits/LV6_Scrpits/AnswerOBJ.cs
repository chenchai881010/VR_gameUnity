using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOBJ : MonoBehaviour
{
    public GameObject my_Question;//答案的問題
    public void Dele_Answer()//作答完畢，刪除答案
    {
        if (my_Question == null)
        {
            Destroy(gameObject);
        }
    }
}
