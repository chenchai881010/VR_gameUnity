using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_lv3 : MonoBehaviour
{
    public GameObject MagicBan_Prefad;//�k��
    public GameObject Right_hand;//�k��
    public Hand hand;//�ⳡ

    private GameObject m_Magic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UseMagic()//�ϥ��]��
    {
        if (m_Magic != null)
        {
            m_Magic.SetActive(true);
        }
        else
        {
            Right_hand = hand.spawnedHand;
            m_Magic = Instantiate(MagicBan_Prefad, Right_hand.transform.GetChild(0));
        }
    }

    public void UN_UseMagic()//���ϥ��]��
    {
        if (m_Magic != null)
        {
            m_Magic.GetComponent<TreeMagic>().magic_unset();
        }
    }
    public void Magic_set()//�]�k�]�m
    {
        if (m_Magic != null)
        {
            if (m_Magic.activeSelf)
            {
                m_Magic.GetComponent<TreeMagic>().magic_set();
            }
        }
    }
    public void Magic_shoot()//�]�k�ϥ�
    {
        if (m_Magic != null)
        {
            m_Magic.GetComponent<TreeMagic>().magic_shooting();
        }
    }

}
