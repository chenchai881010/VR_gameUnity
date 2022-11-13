using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameContraller_LV1 : MonoBehaviour
{
    public static GameContraller_LV1 Instrance;
     
    public int playing_Lv;//���a���q
    public int m_playerTime;//�ɶ��p��
    public int m_MissCar;//���ѿ��~�ƶq
    public GameObject player;//���a
    public GameObject Step2Point;//�ĤG���q��m
    //ui��r
    public Text[] Step1_Texts;//0�G�ɶ� 1�GMiss����
    public Text[] Step2_Texts;//0:���� 1�GCO 2�GHC 3�GCO2 4�G�������G
    public GameObject[] StepUI;//0�G�Ĥ@���q 1�G�ĤG���q
    public Text check_OK;//�T�{���T�q
    public GameObject Knowledge;//���ѵ���
    public GameObject OverCount;
    private float timeCount;
    public bool Round2Start;
    
    //�����ƭ�
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
    public void UI_update(string ChangeItem)//ui�ܤ�
    {
        switch (ChangeItem)
        {
            case "Time":
                string min = (m_playerTime / 60).ToString().PadLeft(2, '0');
                string sed = (m_playerTime % 60).ToString().PadLeft(2, '0');
                Step1_Texts[0].text =min +"�G" +sed;
                break;
            case "Miss":
                m_MissCar++;
                Step1_Texts[1].text =m_MissCar.ToString() ;
                if (m_MissCar>=5)
                {
                    GameManager.Intrestance.LoseGame(); //�����C��(��������)
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


    public void ChekWINorLOSE( int N)//��Ĺ�T�{
    {
        check_OK.text = "�ˬd���T�ƶq�G\n" + N;
        if (N>=5)
        {
            GameManager.Intrestance.m_GameHint("�A�w���\�ˬd���T5�����l�F");
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
            case "������":
                if (COpoint>3.5 || HCpoint>1600)
                {
                    result = "<color=#f00>���X��</color>";
                }
                else
                {
                    result = "<color=#0f0>�X��</color>";
                }

                break;
            default:
                if (COpoint>1.2 || HCpoint>220)
                {
                    result = "<color=#f00>���X��</color>";
                }
                else
                {
                    result = "<color=#0f0>�X��</color>";
                }

                break;
        }
        UI_update("Check");
    }
    public void rund_One_play()
    {
        
         //------------------���ܨæb5���}�l
        GameManager.Intrestance.m_GameHint("�յۤ���Q�騮�A�b90���Q�Τ�W���]�k�αN�Q�騮�e���{�˰� \n 5���}�l");
        StartCoroutine(delayStart(5));
        GameManager.Intrestance.playAudio();
        timeCount = Time.time;
    }
    public IEnumerator rund_Two_play()
    {
        OverCount.SetActive(false);
        GameManager.Intrestance.m_GameHint("�ɶ���\n���U�ӷ|�ǰe���{�˰�");
        GameManager.Intrestance.Yes_Answer();
        yield return new WaitUntil(() =>Round2Start);
        //���ʨ�w�I
        Step2Point.SetActive(true);
        player.transform.position = Step2Point.transform.GetChild(0).position;
        //------------------���ܨæb5���}�l
        GameManager.Intrestance.m_GameHint("�Ө��{�˰ϡA�Q�μo����R�˸m�A�ݳo�Ǩ��l���Ʈ𪬪p�����N�� \n 5���}�l");
        GameObject.Find("CarSetCheck").GetComponent<CarSetCheckLarry>().Step2_Seting();
        yield return delayStart(5);
        GameManager.Intrestance.playAudio();
        
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
    public void Round2() => Round2Start = true;
    public void openKnowledge()
    {
        if (CarManager.Insterance.ok_Count==5)
        {
            Knowledge.SetActive(true);
        }
        
    }

}
