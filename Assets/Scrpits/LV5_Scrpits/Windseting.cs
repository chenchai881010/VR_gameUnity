using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Windseting : MonoBehaviour
{
    public GameObject[] selet;//選擇變化
    //----資訊---------------
    public string SetType;//位置資訊
    public bool isSeleting;//選擇中

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
    public void setwind_elect()//設置發電裝置
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
            case "城市":
                modSeting[0].SetActive(true);
                break;
            case "海邊":
                modSeting[1].SetActive(true);
                break;
            case "沿岸":
                modSeting[2].SetActive(true);
                break;
            default:
                break;
        }
        if (WindManager.Instrance.using_type ==SetType)
        {
            LV5_GameControler.intrance.give_info(info_image,info_text,info_title);
            //跳出資訊
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
