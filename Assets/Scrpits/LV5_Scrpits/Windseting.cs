using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windseting : MonoBehaviour
{
    public GameObject[] selet;//����ܤ�
    //----��T---------------
    public string SetType;//��m��T
    public bool isSeleting;//��ܤ�

    public GameObject[] modSeting;
    [Multiline(3)]
    public string info_text;
    public string info_title;
    public Sprite info_image;
    // Start is called before the first frame update
    private bool now_mod;
    private void Start()
    {
        now_mod = isSeleting;
    }
    private void Update()
    {
        if (now_mod !=isSeleting)
        {
            
            if (isSeleting)
            {
               selet[0].SetActive(true);
               
            }
            else
            { 
                selet[0].SetActive(false);
                
            }
            now_mod = isSeleting;
        }
    }
    public void setwind_elect()//�]�m�o�q�˸m
    {
        Debug.Log(gameObject.name);
        for (int i = 0; i < modSeting.Length; i++)
        {
            if (modSeting[i].activeSelf)
            {
                modSeting[i].SetActive(false);
            }
        }
        switch (WindManager.Instrance.using_type)
        {
            case "����":
                modSeting[0].SetActive(true);
                break;
            case "����":
                modSeting[1].SetActive(true);
                break;
            case "�u��":
                modSeting[2].SetActive(true);
                break;
            default:
                break;
        }
        if (WindManager.Instrance.using_type ==SetType)
        {
            LV5_GameControler.intrance.give_info(info_image,info_text,info_title);
            //���X��T
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
