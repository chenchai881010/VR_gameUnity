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
        //���ʨ�԰���m
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
        //���ʨ�԰���m
        StartCoroutine(callhint("�N�U�����O�o�q����b���T����m"));
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
    }
    public void turnback()//�^���a
    {
        player.transform.parent = null;
        player.transform.position = Plaform.transform.position;
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
