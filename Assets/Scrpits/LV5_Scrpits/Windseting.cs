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

    public GameObject[] modSeting;//��m�I
    public GameObject[] puttingModle;//��e��m�ҫ�
    [Multiline(3)]
    public string info_text;
    public string info_title;
    public Sprite info_image;
    //�k�N�ϥέ���
    public movepoint_Lv5 movepoint_;//��e��m
    // Start is called before the first frame update
    private bool now_mod;
    private void Start()
    {
        now_mod = isSeleting;
        puttingModle = new GameObject[modSeting.Length];
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
        if (WindManager.Instrance.my_Windsetting ==null || WindManager.Instrance.my_Windsetting.save==false
            ||movepoint_.movetime%2==0||LV5_GameControler.intrance.introduce_view.activeSelf)
        {
            Debug.Log("�k�N���_");
            return;
        }
        Debug.Log(gameObject.name);
        if (puttingModle != null)
        {
            for (int i = 0; i < modSeting.Length; i++)
            {
                Destroy(puttingModle[i]);
            }
        }

        for (int i = 0; i < puttingModle.Length; i++)
        {
            //�ͦ�
            puttingModle[i] = Instantiate(WindManager.Instrance.my_Windsetting.gameObject,modSeting[i].transform);
            puttingModle[i].transform.localPosition = new Vector3(0, 0, 0);
            //�j�p����
            switch (WindManager.Instrance.my_Windsetting.Wind_size)
            {
                case "�j":
                    puttingModle[i].transform.localScale = new Vector3(90, 90, 90);
                    break;
                case "��":
                    puttingModle[i].transform.localScale = new Vector3(67, 67, 67);
                    break;
                case "�p":
                    puttingModle[i].transform.localScale = new Vector3(10, 10, 10);
                    break;
            }
        }
        if (WindManager.Instrance.using_type ==SetType)
        {
            LV5_GameControler.intrance.give_info(info_image,info_text,info_title);
            LV5_GameControler.intrance.putGameCude = gameObject;
            //���X��T
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
