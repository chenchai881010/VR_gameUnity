using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    public static GameManager Intrestance;
    public Canvas gamecanvas;
    public TextMeshProUGUI text;
    public Text hintText;
    public bool isPlaying;
    public GameObject[] teleportAreas;
    public Button exit_play;
    public Button try_again;
    public Canvas HandUI;

    public AudioClip[] audioClips;
    public AudioSource m_source;
    public int step; 
    // Start is called before the first frame update
    private void Awake()
    {
        isPlaying = true;
        Intrestance = this;
        step = 0;
    }
    void Start()
    {
        
    }
    public void WinGame() //獲勝
    {
        text.text = "汙染清除";
        hintText.text = "";
        gamecanvas.enabled = true;
        isPlaying = false;
        exit_play.gameObject.SetActive(true);
        try_again.gameObject.SetActive(true);
        HandUI.gameObject.SetActive(false);
        HIDE_TELEPORT();
    }
    public void m_WinGame(string hint) //獲勝(通用)
    {
        text.text = "";
        hintText.text = hint;
        gamecanvas.enabled = true;
        isPlaying = false;
        exit_play.gameObject.SetActive(true);
        try_again.gameObject.SetActive(true);
        HIDE_TELEPORT();
        HandUI.gameObject.SetActive(false);
    }
    public void LoseGame()  //失敗
    {
        text.text = "清除失敗";
        hintText.text = "";
        gamecanvas.enabled = true;
        isPlaying = false;
        exit_play.gameObject.SetActive(true);
        try_again.gameObject.SetActive(true);
        HIDE_TELEPORT();
        HandUI.gameObject.SetActive(false);
    }
    public void m_StopGame() // 暫停
    {
        text.text = "暫停中";
        hintText.text = "";
        gamecanvas.enabled = true;
        isPlaying = false;
        exit_play.gameObject.SetActive(false);
        try_again.gameObject.SetActive(false);
        HIDE_TELEPORT();
    }
    public void m_GameHint(string hint) // 提示
    {
        text.text = "";
        hintText.text = hint;
        gamecanvas.enabled = true;
        isPlaying = false;
        exit_play.gameObject.SetActive(false);
        try_again.gameObject.SetActive(false);
        HIDE_TELEPORT();
        HandUI.gameObject.SetActive(false);
    }
    public void m_StartGame()// 開始
    {
        gamecanvas.enabled = false;
        isPlaying = true;
        SHOW_TELEPORT();
        HandUI.gameObject.SetActive(true);
    }
    public void RePlayGame()// 重玩
    {
        gamecanvas.enabled = false;
        string thisgame = SceneManager.GetActiveScene().name;
        HandUI.gameObject.SetActive(true);
        SceneManager.LoadScene(thisgame);
    }
    public void IndexGame()// 返回選單
    {
        gamecanvas.enabled = false;
        HandUI.gameObject.SetActive(true);
        SceneManager.LoadScene(0);
    }
    public void ExitGame()// 離開遊戲
    {
        Application.Quit();
    }


    private void HIDE_TELEPORT()//隱藏傳送點
    {
        for (int i = 0; i < teleportAreas.Length; i++)
        {
            teleportAreas[i].SetActive(false);
        }
    }
    private void SHOW_TELEPORT()//隱藏傳送點
    {
        for (int i = 0; i < teleportAreas.Length; i++)
        {
            teleportAreas[i].SetActive(true);
        }
    }

    public void playAudio()
    {
        m_source.clip = audioClips[step];
        //Debug.Log(step);
        m_source.Play();
        step++;
    }
}
