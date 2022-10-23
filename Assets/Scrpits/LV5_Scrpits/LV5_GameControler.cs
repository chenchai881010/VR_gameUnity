using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LV5_GameControler : MonoBehaviour
{
    public Text Hint_text;//�C�����e
    public GameObject GameLV5_Canvas;
    public Text hand_UItext;//�ⳡui
    public GameObject player;
    public GameObject Plaform;
    public Transform fire_point;
    public Transform wind_point;
    //-----------skybox�]�w--------------
    public Material sky;
    public Material Orange;
    public Canvas hand_ui;
    public GameObject windView;
    public GameObject fireView;
    //---------���du�ϥ�---------------
    public GameObject introduce_view;//���еe��
    public Text text_title;//�ѻ����D
    public Image img_hint;//�ѻ��Ϥ�
    public Text text_intrduct;//�ѻ���r
    private int knowtime;
    public GameObject Knowledge_view;//���O����
    //-----------�޲z��------------
    public GameObject wind;
    public GameObject fire;
    public static LV5_GameControler intrance;

    private int playMod = 0;
    //---------��a�d���I---------
    public GameObject[] seePoints;
    public Text check_wind_text;
    public GameObject know_Button;
    bool redo = false;
    public GameObject putGameCude;//�]�m�I�O�_���]
    
    
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
        hand_UItext.text = "���O�o�q";
        GameLV5_Canvas.GetComponent<Canvas>().enabled = false;
        //���ʨ���O�o�q��m
        player.transform.position = fire_point.position;
        StartCoroutine(callhint("�����¦����O�o�q���A�ǥѥ���l�N�U�ƥ�i�l�����q�O�F��ؼ�"));
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
        hand_UItext.text = "���O�o�q";
        GameLV5_Canvas.GetComponent<Canvas>().enabled = false;
        //���ʨ쭷�O�o�q��m
        player.transform.position = wind_point.position;
        StartCoroutine(callhint("�]�p�U�����O�o�q���é�b���T����m"));
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
    public void ToSeeWind()//��a�d��
    {
        switch (text_title.text)
        {
            case "�����b����":
                player.transform.position = seePoints[0].transform.position;
                break;
            case "�����b�T��������":
                player.transform.position = seePoints[1].transform.position;
                break;
            case "�M���������T��������":
                player.transform.position = seePoints[2].transform.position;
                player.transform.parent = seePoints[2].transform;
                break;
            default:
                break;
        }
        Give_Suggest();
    }
    //�˴�����������ĳ
    public void Give_Suggest()
    {
        string elect_out;
        redo=false;
        string sug01 = "";
        string sug02 = "";
        string sug03 = "";
        switch (text_title.text)
        {
            case "�����b����":
                elect_out = "���`";
                if (WindManager.Instrance.my_Windsetting.Wind_head=="�T����")
                {
                    sug01 = "��Ϋ������C";
                    redo = true;
                }
                switch (WindManager.Instrance.my_Windsetting.Wind_size)
                {
                    case "�j":
                    case "��":
                        sug02 = "�L���O�B���V����i�ϥεu�W�Y�i";
                        redo = true;
                        break;
                    case "�p":
                        sug02 = "";
                        break;
                }
                if (WindManager.Instrance.my_Windsetting.Wind_base == "�ݭn")
                {
                    sug03 = "(�L�ݦw�ˮM��)";
                    redo = true;
                }
                check_wind_text.text = "�o�q�q : " + elect_out + "\n��ĳ : \n" + sug01 + sug02 + sug03;
                break;
            case "�����b�T��������":
                elect_out = "���`";
                if (WindManager.Instrance.my_Windsetting.Wind_head== "������")
                {
                    sug01 = "��ΤT�����C";
                    redo = true;
                }
                switch (WindManager.Instrance.my_Windsetting.Wind_size)
                {
                    case "�j":
                        sug02 = "�i�H��ܧ�A�X�������A�X�������W";
                        redo = true;
                        break;
                    case "�p":
                        elect_out = "��";
                        sug02 = "�T���������j���������e�j�����O�P���V�~��ҥΡA�i�H��ܧ�A�X�������A�X�������W";
                        redo = true;
                        break;
                    case "��":
                        sug02 = "";
                        break;
                }
                if (WindManager.Instrance.my_Windsetting.Wind_base == "�ݭn")
                {
                    sug03 = "(�L�ݦw�ˮM��)";
                    redo = true;
                }
                check_wind_text.text = "�o�q�q : " + elect_out + "\n��ĳ : \n" + sug01 + sug02 + sug03;
                break;
            case "�M���������T��������":
                elect_out = "���`";
                if (WindManager.Instrance.my_Windsetting.Wind_head == "������")
                {
                    sug01 = "��ΤT�����C";
                    redo = true;
                }
                switch (WindManager.Instrance.my_Windsetting.Wind_size)
                {
                    case "�j":
                        sug02 = "";
                        
                        break;
                    case "�p":
                        elect_out = "0";
                        sug02 = "�����T���������j���������e�j�����O�P���V�~��ҥΡA�B���]���j�q�������ͼv�T�����A�i�H��ܧ�A�X�������A�X�������W�P��m";
                        redo = true;
                        break;
                    case "��":
                        elect_out = "0";
                        sug02 = "�����T���������j���������e�j�����O�P���V�~��ҥΡA�i�H��ܧ�A�X�������A�X�������W";
                        redo = true;
                        break;
                }
                if (WindManager.Instrance.my_Windsetting.Wind_base == "���ݭn")
                {
                    elect_out = "0";
                    sug03 = "(�ݦw�ˮM���~�ॿ�`�@��)";
                    redo = true;
                }
                check_wind_text.text = "�o�q�q : " + elect_out + "\n��ĳ : \n" + sug01 + sug02 + sug03;
                break;
        }

        //�p�Gredo���u
        if (redo)
        {
            putGameCude.GetComponent<BoxCollider>().enabled = true;
        }

        
    }
    public void turnback()//�^���a
    {
        player.transform.parent = null;
        player.transform.position = Plaform.transform.position;
        know_Button.SetActive(true);
    }
    public void endtest()
    {
        if (playMod == 2)
        {
            GameManager.Intrestance.m_WinGame("�{�b�A�w���秹�p�q�W���o�q��k�F");
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
