using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindModle : MonoBehaviour
{
    //�]�p�]�w
    public string Wind_head;
    public string Wind_size;
    public string Wind_base;
    public bool save;
    public bool test_is_ok;
    public void SaveSetting(string m_head, string m_size, string m_base)//�x�s�]�w
    {
        Wind_head = m_head;
        Wind_size = m_size;
        Wind_base = m_base;
        save = true;
    }
    public void InTest(bool TEST)//���լO�_�X��
    {
        test_is_ok = TEST;
    }
}
