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

    public GameObject[] modSeting;//放置點
    public GameObject[] puttingModle;//當前放置模型
    [Multiline(3)]
    public string info_text;
    public string info_title;
    public Sprite info_image;
    //法術使用限制
    public movepoint_Lv5 movepoint_;//當前位置
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
    public void setwind_elect()//設置發電裝置
    {
        if (WindManager.Instrance.my_Windsetting ==null || WindManager.Instrance.my_Windsetting.save==false
            ||movepoint_.movetime%2==0||LV5_GameControler.intrance.introduce_view.activeSelf)
        {
            Debug.Log("法術中斷");
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
            //生成
            puttingModle[i] = Instantiate(WindManager.Instrance.my_Windsetting.gameObject,modSeting[i].transform);
            puttingModle[i].transform.localPosition = new Vector3(0, 0, 0);
            //大小改變
            switch (WindManager.Instrance.my_Windsetting.Wind_size)
            {
                case "大":
                    puttingModle[i].transform.localScale = new Vector3(90, 90, 90);
                    break;
                case "中":
                    puttingModle[i].transform.localScale = new Vector3(67, 67, 67);
                    break;
                case "小":
                    puttingModle[i].transform.localScale = new Vector3(10, 10, 10);
                    break;
            }
        }
        if (WindManager.Instrance.using_type ==SetType)
        {
            LV5_GameControler.intrance.give_info(info_image,info_text,info_title);
            LV5_GameControler.intrance.putGameCude = gameObject;
            //跳出資訊
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
