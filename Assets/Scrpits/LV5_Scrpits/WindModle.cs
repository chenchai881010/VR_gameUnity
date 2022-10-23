using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindModle : MonoBehaviour
{
    //設計設定
    public string Wind_head;
    public string Wind_size;
    public string Wind_base;
    public bool save;
    public bool test_is_ok;
    public void SaveSetting(string m_head, string m_size, string m_base)//儲存設定
    {
        Wind_head = m_head;
        Wind_size = m_size;
        Wind_base = m_base;
        save = true;
    }
    public void InTest(bool TEST)//測試是否合格
    {
        test_is_ok = TEST;
    }
}
