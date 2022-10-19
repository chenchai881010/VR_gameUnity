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
    
    public int playing_Lv;//���a���q

    public int m_playerTime;
    public int m_Pollution;
   
    public int m_Mask;
    public Text hp_TIME;
    public Image poll_Img;
    public Text AQI_Point;
    public Color[] AQI_colors;
    public GameObject toBoss;//�����ǰe��
    public GameObject player;//���a
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
        //hp_Bar.value = (float)m_playerhp / Player_HP;�ܧ󬰮ɶ�
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
    public void PollutionChange(int PollPoint)//���V���ܤ�
    {
        m_Pollution += PollPoint;
        if (m_Pollution<=0)
        {
            m_Pollution = 0;
        }
        UI_update();
    }

    public void PlayerTimeChange(int Timechange)//�ɶ��ܤ�
    {         
        m_playerTime += Timechange;
        UI_update();
    }
    public void Poll_HP_Change() //���V�ȻP��q�ܤ�
    { 
        PlayerTimeChange(-1);
        nexttime = 1;
    }
    public void ClearWorld(int clearPoint )//�M��@�ɭ��C���V��
    {
        
            PollutionChange(-clearPoint);
      
    }

    public void ChekWINorLOSE()//��Ĺ�T�{
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
                    GameManager.Intrestance.m_GameHint("�i��ǰe���e�����V���Y�������ܰ��b�a!");
                    
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
        
         //------------------���ܨæb5���}�l
        GameManager.Intrestance.m_GameHint("�N���������V���M�z���a \n 5���}�l");
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
        //------------------���ܨæb5���}�l
        GameManager.Intrestance.m_GameHint("�}�l���j���X�{�F \n 3���}�l");
        StartCoroutine(delayStart(3));
    }
    public void rund_Three_play()
    {
        //---���m����
        lv2house.SetActive(false);
        Factory.transform.localPosition = new Vector3(-66,0,24.5f);
        lv3house.transform.localPosition = new Vector3(0, 0.45f, 0);
        CarManager.Insterance.Call_Car_Bake();
        //---�������l�C�U���C���d�C---�}�ҷϧw�޲z��

        //PollutionManager.Instance.gameObject.SetActive(false);
        //HealthManager.Instance.gameObject.SetActive(false);
        CarManager.Insterance.gameObject.SetActive(false);
        chimney.SetActive(true);
        
        //-------------------�]�w��q�A���V��-----
        m_playerTime = Player_time[2];

        m_Pollution = Pollution_point[2];
        UI_update();
        //------------------���ܨæb5���}�l
        GameManager.Intrestance.m_GameHint("�֧�_�·Ϫ��ϧw�B�z���a \n 5���}�l");
        GameManager.Intrestance.playAudio();
        StartCoroutine(delayStart(5));
    }
    public IEnumerator delayStart(float startTime)//����}�l
    {
        yield return new WaitForSeconds(startTime);
        GameManager.Intrestance.m_StartGame();
    }
    //ŵ�`���A�ܤ�
    public void FogDensityChange(int point)
    {
        RenderSettings.fogDensity = (float)point * 0.0001f * 0.5f ;
    }
}
