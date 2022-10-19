using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_lv3 : MonoBehaviour
{
    public GameObject MagicBan_Prefad;//法杖
    public GameObject Right_hand;//右手
    public Hand hand;//手部

    private GameObject m_Magic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UseMagic()//使用魔杖
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

    public void UN_UseMagic()//不使用魔杖
    {
        if (m_Magic != null)
        {
            m_Magic.GetComponent<TreeMagic>().magic_unset();
        }
    }
    public void Magic_set()//魔法設置
    {
        if (m_Magic != null)
        {
            if (m_Magic.activeSelf)
            {
                m_Magic.GetComponent<TreeMagic>().magic_set();
            }
        }
    }
    public void Magic_shoot()//魔法使用
    {
        if (m_Magic != null)
        {
            m_Magic.GetComponent<TreeMagic>().magic_shooting();
        }
    }

}
