using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LV5_GameControler : MonoBehaviour
{
    public Text Hint_text;//遊戲內容
    public GameObject GameLV5_Canvas;
    public Text hand_UItext;//手部ui
    public GameObject player;
    public GameObject Plaform;
    public Transform fire_point;
    public Transform wind_point;
    //-----------skybox設定--------------
    public Material sky;
    public Material Orange;
    public Canvas hand_ui;
    public GameObject windView;
    public GameObject fireView;
    //---------關卡u使用---------------
    public GameObject introduce_view;//介紹畫面
    public Text text_title;//解說標題
    public Image img_hint;//解說圖片
    public Text text_intrduct;//解說文字
    private int knowtime;
    public GameObject Knowledge_view;//風力介紹
    //-----------管理者------------
    public GameObject wind;
    public GameObject fire;
    public static LV5_GameControler intrance;

    private int playMod = 0;
    //---------實地查看點---------
    public GameObject[] seePoints;
    public Text check_wind_text;
    public GameObject know_Button;
    bool redo = false;
    public GameObject putGameCude;//設置點是否重設
    
    
    // Start is called before the first frame update
    private void Awake()
    {
        intrance = this;
    }
    void Start()
    {
        sky.CopyPropertiesFromMaterial(Orange);
        hand_ui.enabled = false;
        knowtime = 0;
        
        playMod = 0;
    }

    // Update is called once per frame
    public void toFire()
    {
        hand_UItext.text = "火力發電";
        GameLV5_Canvas.GetComponent<Canvas>().enabled = false;
        //移動到火力發電位置
        player.transform.position = fire_point.position;
        StartCoroutine(callhint("體驗舊式火力發電機，藉由用鏟子將燃料丟進爐中讓電力達到目標"));
        hand_ui.enabled = true;
        fireView.SetActive(true);
        windView.SetActive(false);
        fire.SetActive(true);
        playMod++;
        GameManager.Intrestance.step = 6;
        GameManager.Intrestance.playAudio();
    }
    public void toWind()
    {
        hand_UItext.text = "風力發電";
        GameLV5_Canvas.GetComponent<Canvas>().enabled = false;
        //移動到風力發電位置
        player.transform.position = wind_point.position;
        StartCoroutine(callhint("設計各式風力發電機並放在正確的位置"));
        hand_ui.enabled = true;
        fireView.SetActive(false);
        windView.SetActive(true);
        wind.SetActive(true);
        playMod++;
        GameManager.Intrestance.step = 1;
        GameManager.Intrestance.playAudio();
    }
    public IEnumerator callhint(string hinttext)
    {
        GameManager.Intrestance.m_GameHint(hinttext);
        yield return new WaitForSeconds(3);
        GameManager.Intrestance.m_StartGame();
    }
    public void give_info(Sprite infoimg,string infotext, string infotitle)
    {

        img_hint.sprite = infoimg;
        text_intrduct.text = infotext;
        text_title.text = infotitle;
        GameLV5_Canvas.GetComponent<Canvas>().enabled = true;
        introduce_view.SetActive(true);
        wind.GetComponent<WindManager>().enabled = false;
    }
    public void Knowledge_get()
    {
        wind.GetComponent<WindManager>().enabled = true;
        if (!redo)
        {
            knowtime++;
        }
        
        if (knowtime == 3)
        {
            Knowledge_view.SetActive(true);
            GameManager.Intrestance.step = 5;
            GameManager.Intrestance.playAudio();
        }
        else
        {
            GameLV5_Canvas.GetComponent<Canvas>().enabled = false;
        }
        
    }
    public void ToSeeWind()//實地查看
    {
        switch (text_title.text)
        {
            case "垂直軸風機":
                player.transform.position = seePoints[0].transform.position;
                break;
            case "水平軸三葉式風機":
                player.transform.position = seePoints[1].transform.position;
                break;
            case "套筒式離岸三葉式風機":
                player.transform.position = seePoints[2].transform.position;
                player.transform.parent = seePoints[2].transform;
                break;
            default:
                break;
        }
        Give_Suggest();
    }
    //檢測風機給予建議
    public void Give_Suggest()
    {
        string elect_out;
        redo=false;
        string sug01 = "";
        string sug02 = "";
        string sug03 = "";
        switch (text_title.text)
        {
            case "垂直軸風機":
                elect_out = "正常";
                if (WindManager.Instrance.my_Windsetting.Wind_head=="三葉式")
                {
                    sug01 = "選用垂直式。";
                    redo = true;
                }
                switch (WindManager.Instrance.my_Windsetting.Wind_size)
                {
                    case "大":
                    case "中":
                        sug02 = "無風力、風向限制可使用短柱即可";
                        redo = true;
                        break;
                    case "小":
                        sug02 = "";
                        break;
                }
                if (WindManager.Instrance.my_Windsetting.Wind_base == "需要")
                {
                    sug03 = "(無需安裝套筒)";
                    redo = true;
                }
                check_wind_text.text = "發電量 : " + elect_out + "\n建議 : \n" + sug01 + sug02 + sug03;
                break;
            case "水平軸三葉式風機":
                elect_out = "正常";
                if (WindManager.Instrance.my_Windsetting.Wind_head== "垂直式")
                {
                    sug01 = "選用三葉式。";
                    redo = true;
                }
                switch (WindManager.Instrance.my_Windsetting.Wind_size)
                {
                    case "大":
                        sug02 = "可以選擇更適合此風機適合的中間柱";
                        redo = true;
                        break;
                    case "小":
                        elect_out = "少";
                        sug02 = "三葉式有較大的扇葉需龐大的風力與風向才能啟用，可以選擇更適合此風機適合的中間柱";
                        redo = true;
                        break;
                    case "中":
                        sug02 = "";
                        break;
                }
                if (WindManager.Instrance.my_Windsetting.Wind_base == "需要")
                {
                    sug03 = "(無需安裝套筒)";
                    redo = true;
                }
                check_wind_text.text = "發電量 : " + elect_out + "\n建議 : \n" + sug01 + sug02 + sug03;
                break;
            case "套筒式離岸三葉式風機":
                elect_out = "正常";
                if (WindManager.Instrance.my_Windsetting.Wind_head == "垂直式")
                {
                    sug01 = "選用三葉式。";
                    redo = true;
                }
                switch (WindManager.Instrance.my_Windsetting.Wind_size)
                {
                    case "大":
                        sug02 = "";
                        
                        break;
                    case "小":
                        elect_out = "0";
                        sug02 = "離岸三葉式有較大的扇葉需龐大的風力與風向才能啟用，運轉後也有大量噪音產生影響民眾，可以選擇更適合此風機適合的中間柱與位置";
                        redo = true;
                        break;
                    case "中":
                        elect_out = "0";
                        sug02 = "離岸三葉式有較大的扇葉需龐大的風力與風向才能啟用，可以選擇更適合此風機適合的中間柱";
                        redo = true;
                        break;
                }
                if (WindManager.Instrance.my_Windsetting.Wind_base == "不需要")
                {
                    elect_out = "0";
                    sug03 = "(需安裝套筒才能正常作用)";
                    redo = true;
                }
                check_wind_text.text = "發電量 : " + elect_out + "\n建議 : \n" + sug01 + sug02 + sug03;
                break;
        }

        //如果redo為真
        if (redo)
        {
            putGameCude.GetComponent<BoxCollider>().enabled = true;
        }

        
    }
    public void turnback()//回到原地
    {
        player.transform.parent = null;
        player.transform.position = Plaform.transform.position;
        know_Button.SetActive(true);
    }
    public void endtest()
    {
        if (playMod == 2)
        {
            GameManager.Intrestance.m_WinGame("現在你已體驗完小島上的發電方法了");
        }
        player.transform.position = Plaform.transform.position;

    }
    public void endgamemanager(string fow)
    {
        switch (fow)
        {
            case "f":
                Destroy(fire);
                break;
            case "w":
                Destroy(wind);
                break;
            default:
                break;
        }
    }
}
