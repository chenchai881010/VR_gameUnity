using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class1_Contraller : MonoBehaviour
{
    public GameObject MagicBan_Prefad;//�k��
    public GameObject Right_hand;//�k��
    public Hand hand;//�ⳡ

    private GameObject m_Magic;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    //�]�k����
    public void UseMagic()
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
        
    public void NUseMagic()
    {
        if (m_Magic == null)
            return;
        if (!m_Magic.activeSelf)
            return;
        m_Magic.GetComponent<MagicBan>().disapper_ban();
    }
    public void Magicset()
    {
        if (m_Magic == null)
            return;
        if (!m_Magic.activeSelf)
            return;
        m_Magic.GetComponent<MagicBan>().Magic_Use();
    }
    public void MagicShooting()
    {
        if (m_Magic == null)
            return;
        if (!m_Magic.activeSelf)
            return;
        m_Magic.GetComponent<MagicBan>().Rayshooting();
    }
    //---------------------------------------------------------------------------------------

}
