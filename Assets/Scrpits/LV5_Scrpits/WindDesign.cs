using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindDesign : MonoBehaviour
{
    //設計設定
    public string Wind_head;
    public string Wind_size;
    public string Wind_base;
    //使用UI
    public GameObject Wind_DUI;//設計介面

    //提示與物件
    public GameObject MOVE_Hint;//移動點提示
    public GameObject Wind_Modle;//模型
    public GameObject[] Wind_Modle_data;//模型資料庫
    //內部模型紀錄
    private GameObject m_base;//底座
    private GameObject m_body;//本體
    //內部設定紀錄
    private string set_head;
    private string set_size;
    private string set_base;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MOVE_Hint.SetActive(false);
            Wind_DUI.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MOVE_Hint.SetActive(true);
            Wind_DUI.SetActive(false);
        }
    }

    //ui互動程式
    public void hade_setting(Text head) 
    {
        Wind_head = head.text;
        if (set_head != Wind_head)
        {
            if (m_body!=null)
            {
                Destroy(m_body);
            }
             switch (Wind_head)
            {
                case "垂直式":
                    m_body = Instantiate(Wind_Modle_data[0], Wind_Modle.transform);
                    set_head = Wind_head;
                    break;
                case "三葉式":
                    m_body = Instantiate(Wind_Modle_data[1], Wind_Modle.transform);
                    set_head = Wind_head;
                    break;
            }
            m_body.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }

    }
    public void size_setting(Text size)
    {
        Wind_size = size.text;
        if (set_size != Wind_size)
        {
            switch (Wind_size)
            {
                case "大":
                    m_body.transform.localScale = new Vector3(0.02f,0.02f,0.02f);
                    set_size = Wind_size;
                    break;
                case "中":
                    m_body.transform.localScale = new Vector3(0.015f, 0.015f, 0.015f);
                    set_size = Wind_size;
                    break;
                case "小":
                    m_body.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                    set_size = Wind_size;
                    break;
            }
            if (m_base !=null)
            {
                m_base.transform.localScale = m_body.transform.localScale;
            }
        }
    }
    public void base_setting(Text the_base)
    {
        Wind_base = the_base.text;
        if (set_base != Wind_base)
        {
            switch (Wind_base)
            {
                case "需要":
                    m_base = Instantiate(Wind_Modle_data[2], Wind_Modle.transform);
                    m_base.transform.localScale = m_body.transform.localScale;
                    set_base = Wind_base;
                    break;
                case "不需要":
                    if (m_base !=null)
                    {
                        Destroy(m_base);
                    }
                    set_base = Wind_base;
                    break;
            }
            
        }
    }
    //儲存設定
    public void SaveDesign()
    {
        Wind_Modle.GetComponent<WindModle>().SaveSetting(Wind_head, Wind_size, Wind_base);
    }
}
