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
        //移動到戰鬥位置
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
        //移動到戰鬥位置
        StartCoroutine(callhint("將各式風力發電機放在正確的位置"));
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
        knowtime++;
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
    }
    public void turnback()//回到原地
    {
        player.transform.parent = null;
        player.transform.position = Plaform.transform.position;
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
