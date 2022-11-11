using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Crest;

public class Guide_move : MonoBehaviour
{
    public GameObject[] hands;//手
    public MeshRenderer[] Sphere;

    public Animator ani;
    public bool isGuide;
    public float _RotationSpeed;
    private GameObject player;
    public GameObject[] teleRange;
    public Water_Clear _Clear;
    // Start is called before the first frame update
    //運作與放置汙泥
    public Animator[] water_ani;
    public GameObject[] durty;
    //播放介紹音訊
    private AudioSource m_audio;
    public AudioClip[] voices;
    public int play_step;//播放順序
    void Start()
    {
        isGuide = false;
        play_step = 0;
        m_audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGuide)
        {
            transform.Rotate(Vector3.down * _RotationSpeed, Space.World);
        }
    }
    //開始導覽
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teleRange[0].SetActive(false);//關閉移動範圍
            
            //關閉本體模型
            Sphere[0].enabled = false;
            Sphere[1].enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            player = other.gameObject;
            //手部功能關閉
            for (int i = 0; i < hands.Length; i++)
            {
                hands[i].SetActive(false);
            }
            TeleportationManager.Intrestance.CanMove = false;

            isGuide = true;
            gameObject.transform.rotation =Quaternion.Euler(0,0,0);
            other.gameObject.transform.parent = gameObject.transform;
            //
            ani.SetTrigger("playmove");
            if (_Clear != null)
            {
                _Clear.guide_bool = true;
            }
        }
    }
    //二沉池處理
    public void second_pool()
    {
        for (int i = 0; i < water_ani.Length; i++)
        {
            water_ani[i].SetBool("play", true);
            durty[i].SetActive(true);
        }
    }

    //導覽結束
    public void endGuide()
    {
        player.transform.parent = null;
        TeleportationManager.Intrestance.CanMove = true;
        teleRange[1].SetActive(true);
        hands[0].SetActive(true);
        hands[2].SetActive(true);
    }
    //開始轉跳場景
    public void toScene()
    {
        ClassTwoPlayer.Instrance.Part++;
        ClassTwoPlayer.Instrance.openhouse();
        ClassTwoPlayer.Instrance.TOplayScene("LV2_Game");
        ClassTwoPlayer.Instrance.Part++;
    }
    //音訊呼叫
    public void playvoice()
    {
        m_audio.clip = voices[play_step];
        m_audio.Play();
        play_step++;
    }
    public void playGMvoice()
    {
        GameManager.Intrestance.playAudio();
    }
}
