using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameContraller_LV1 : MonoBehaviour
{
    public static GameContraller_LV1 Instrance;
     
    public int playing_Lv;//玩家階段
    public int m_playerTime;//時間計時
    public int m_MissCar;//辨識錯誤數量
    public GameObject player;//玩家
    public GameObject Step2Point;//第二階段位置
    //ui文字
    public Text[] Step1_Texts;//0：時間 1：Miss次數
    public Text[] Step2_Texts;//0:類型 1：CO 2：HC 3：CO2 4：偵測結果
    public GameObject[] StepUI;//0：第一階段 1：第二階段
    public Text check_OK;//確認正確量
    public GameObject Knowledge;//知識視窗
    public GameObject OverCount;
    private float timeCount;
    public bool Round2Start;
    
    //偵測數值
    string carType;float COpoint;int HCpoint;float CO2point;string result;
    // Start is called before the first frame update
    private void Awake()
    {
        Instrance = this;
    }
    void Start()
    {
        Round2Start = false;
        playing_Lv = 1;
        m_playerTime = 90;
        m_MissCar = 0;
        rund_One_play();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Intrestance.isPlaying && playing_Lv==1)
        {
            if (Time.time - timeCount>1)
            {
                timeCount = Time.time;
                m_playerTime--;
                UI_update("Time");
                if (m_playerTime <= 0)
                {
                    UI_update("Change");
                    StartCoroutine(rund_Two_play());
                }
            }
        }
        
    }
    public void UI_update(string ChangeItem)//ui變化
    {
        switch (ChangeItem)
        {
            case "Time":
                string min = (m_playerTime / 60).ToString().PadLeft(2, '0');
                string sed = (m_playerTime % 60).ToString().PadLeft(2, '0');
                Step1_Texts[0].text =min +"：" +sed;
                break;
            case "Miss":
                m_MissCar++;
                Step1_Texts[1].text =m_MissCar.ToString() ;
                if (m_MissCar>=5)
                {
                    GameManager.Intrestance.LoseGame(); //結束遊戲(闖關失敗)
                }
                break;
            case "Change":
                playing_Lv++;
                StepUI[0].SetActive(false);
                StepUI[1].SetActive(true);
                break;
            case "Check":
                Step2_Texts[0].text = carType;
                Step2_Texts[1].text = COpoint.ToString("0.00")+" Vol%";//tostring("0.00")
                Step2_Texts[2].text = HCpoint + " ppm";
                Step2_Texts[3].text = CO2point.ToString("0.0") + " Vol%";//tostring("0.0")
                Step2_Texts[4].text = result;
                break;
            default:
                break;
        }
    }


    public void ChekWINorLOSE( int N)//輸贏確認
    {
        check_OK.text = "檢查正確數量：\n" + N;
        if (N>=5)
        {
            GameManager.Intrestance.m_GameHint("你已成功檢查正確5輛車子了");
            GameManager.Intrestance.Yes_Answer();
        }
       
    }
    public void step2_check(CarContraller m_Car)
    {
        carType = m_Car.carType;
        COpoint = m_Car.m_CarData.CO;
        HCpoint = m_Car.m_CarData.HC;
        CO2point = m_Car.m_CarData.CO2;
        switch (carType)
        {
            case "摩托車":
                if (COpoint>3.5 || HCpoint>1600)
                {
                    result = "<color=#f00>不合格</color>";
                }
                else
                {
                    result = "<color=#0f0>合格</color>";
                }

                break;
            default:
                if (COpoint>1.2 || HCpoint>220)
                {
                    result = "<color=#f00>不合格</color>";
                }
                else
                {
                    result = "<color=#0f0>合格</color>";
                }

                break;
        }
        UI_update("Check");
    }
    public void rund_One_play()
    {
        
         //------------------提示並在5秒後開始
        GameManager.Intrestance.m_GameHint("試著分辨烏賊車，在90秒內利用手上的魔法棒將烏賊車送到臨檢區 \n 5秒後開始");
        StartCoroutine(delayStart(5));
        GameManager.Intrestance.playAudio();
        timeCount = Time.time;
    }
    public IEnumerator rund_Two_play()
    {
        OverCount.SetActive(false);
        GameManager.Intrestance.m_GameHint("時間到\n接下來會傳送到臨檢區");
        GameManager.Intrestance.Yes_Answer();
        yield return new WaitUntil(() =>Round2Start);
        //移動到定點
        Step2Point.SetActive(true);
        player.transform.position = Step2Point.transform.GetChild(0).position;
        //------------------提示並在5秒後開始
        GameManager.Intrestance.m_GameHint("來到臨檢區，利用廢氣分析裝置，看這些車子的排氣狀況給予意見 \n 5秒後開始");
        GameObject.Find("CarSetCheck").GetComponent<CarSetCheckLarry>().Step2_Seting();
        yield return delayStart(5);
        GameManager.Intrestance.playAudio();
        
    }

    public IEnumerator delayStart(float startTime)//延遲開始
    {
        yield return new WaitForSeconds(startTime);
        GameManager.Intrestance.m_StartGame();
    }
    //霾害狀態變化
    public void FogDensityChange(int point)
    {
        RenderSettings.fogDensity = (float)point * 0.0001f * 0.5f ;
    }
    public void Round2() => Round2Start = true;
    public void openKnowledge()
    {
        if (CarManager.Insterance.ok_Count==5)
        {
            Knowledge.SetActive(true);
        }
        
    }

}
