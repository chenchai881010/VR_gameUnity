using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerOBJ : MonoBehaviour
{
    public GameObject my_Question;//���ת����D
    public void Dele_Answer()//�@�������A�R������
    {
        if (my_Question == null)
        {
            Destroy(gameObject);
        }
    }
}
