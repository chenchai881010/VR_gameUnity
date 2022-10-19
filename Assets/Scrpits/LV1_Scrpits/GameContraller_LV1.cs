using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameContraller_LV1 : MonoBehaviour
{
    public static GameContraller_LV1 Instrance;

    private int[] Player_time = new int[3] {120,90,60};
    private float nexttime = 1;
    private int[] Pollution_point = new int[3] { 180, 280, 480 };
    
    public int playing_Lv;//玩家階段

    public int m_playerTime;
    public int m_Pollution;
   
    public int m_Mask;
    public Text hp_TIME;
    public Image poll_Img;
    public Text AQI_Point;
    public Color[] AQI_colors;
    public GameObject toBoss;//王關傳送門
    public GameObject player;//玩家
    public GameObject chimney;
    [Space]
    public GameObject lv2house;
    public GameObject Factory;
    public GameObject lv3house;
    // Start is called before the first frame update
    private void Awake()
    {
        Instrance = this;
    }
    void Start()
    {
        m_playerTime= Player_time[0];
        m_Pollution = Pollution_point[0];
        playing_Lv = 1;
        toBoss.SetActive(false);
        UI_update();
        rund_One_play();
    }

    // Update is called once per frame
    void Update()
    {
        if (nexttime<=0&&GameManager.Intrestance.isPlaying)
        {
            Poll_HP_Change();
        }
        else if (nexttime > 0 && GameManager.Intrestance.isPlaying)
        {
            nexttime -= Time.deltaTime;
        }

    }
    private void UI_update()
    {

        if (m_Pollution>500)
        {
            m_Pollution = 500;
        }
        //hp_Bar.value = (float)m_playerhp / Player_HP;變更為時間
        string m = (m_playerTime / 60).ToString();
        string s = (m_playerTime % 60).ToString();
        hp_TIME.text = m.PadLeft(2,'0') + ":" + s.PadLeft(2, '0');
        if (m_Pollution <= 50)
        {
            poll_Img.color = AQI_colors[0];
        }
        else if (m_Pollution <= 100)
        {
            poll_Img.color = AQI_colors[1];
        }
        else if (m_Pollution <= 150)
        {
            poll_Img.color = AQI_colors[2];
        }
        else if (m_Pollution <= 200)
        {
            poll_Img.color = AQI_colors[3];
        }
        else if (m_Pollution <= 300)
        {
            poll_Img.color = AQI_colors[4];
        }
        else
        {
            poll_Img.color = AQI_colors[5];
        }

        AQI_Point.text =""+ m_Pollution;
        FogDensityChange(m_Pollution);
        ChekWINorLOSE();
    }
    public void PollutionChange(int PollPoint)//汙染值變化
    {
        m_Pollution += PollPoint;
        if (m_Pollution<=0)
        {
            m_Pollution = 0;
        }
        UI_update();
    }

    public void PlayerTimeChange(int Timechange)//時間變化
    {         
        m_playerTime += Timechange;
        UI_update();
    }
    public void Poll_HP_Change() //汙染值與血量變化
    { 
        PlayerTimeChange(-1);
        nexttime = 1;
    }
    public void ClearWorld(int clearPoint )//清潔世界降低汙染值
    {
        
            PollutionChange(-clearPoint);
      
    }

    public void ChekWINorLOSE()//輸贏確認
    {

        if (m_playerTime>0&&m_Pollution<=50)
        {
            switch (playing_Lv)
            {
                case 1:
                    playing_Lv++;
                    rund_Two_play();
                    GameManager.Intrestance.playAudio();
                    break;
                case 2:
                    GameManager.Intrestance.m_GameHint("進到傳送門前往汙染源頭讓城市變乾淨吧!");
                    
                    toBoss.SetActive(true);
                    toBoss.transform.position = player.transform.position + new Vector3(0, 0, 1.5f);
                    playing_Lv++;
                    GameManager.Intrestance.playAudio();
                    break;
                default:
                    break;
            }

        }
        if (m_Pollution >50 && m_playerTime <= 0)
        {
            GameManager.Intrestance.LoseGame();

        }
    }
    public void rund_One_play()
    {
        
         //------------------提示並在5秒後開始
        GameManager.Intrestance.m_GameHint("將城市的汙染源清理掉吧 \n 5秒後開始");
        StartCoroutine(delayStart(5));
        GameManager.Intrestance.playAudio();
    }

    public void rund_Two_play()
    {
        if (playing_Lv > 1)
        {
            m_playerTime = Player_time[1];

            m_Pollution = Pollution_point[1];
            UI_update();
        }
        GameManager.Intrestance.playAudio();
        //------------------提示並在5秒後開始
        GameManager.Intrestance.m_GameHint("開始有大車出現了 \n 3秒後開始");
        StartCoroutine(delayStart(3));
    }
    public void rund_Three_play()
    {
        //---布置場景
        lv2house.SetActive(false);
        Factory.transform.localPosition = new Vector3(-66,0,24.5f);
        lv3house.transform.localPosition = new Vector3(0, 0.45f, 0);
        CarManager.Insterance.Call_Car_Bake();
        //---關閉車子。垃圾。健康。---開啟煙囪管理員

        //PollutionManager.Instance.gameObject.SetActive(false);
        //HealthManager.Instance.gameObject.SetActive(false);
        CarManager.Insterance.gameObject.SetActive(false);
        chimney.SetActive(true);
        
        //-------------------設定血量，汙染值-----
        m_playerTime = Player_time[2];

        m_Pollution = Pollution_point[2];
        UI_update();
        //------------------提示並在5秒後開始
        GameManager.Intrestance.m_GameHint("快把冒黑煙的煙囪處理掉吧 \n 5秒後開始");
        GameManager.Intrestance.playAudio();
        StartCoroutine(delayStart(5));
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
}
