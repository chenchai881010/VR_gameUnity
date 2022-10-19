using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClassManager_LV2 : MonoBehaviour//第二關總管理
{
    public static ClassManager_LV2 Instrance;

    public GardageManager gardage;
    public Transform River;
    public GameObject Player;//玩家
    public Text PH_point;
    // Start is called before the first frame update
    private void Awake()
    {
        Instrance = this;
    }
    void Start()
    {
        ClassTwoPlayer.Instrance.Player = Player;
        if (ClassTwoPlayer.Instrance.Part == 0)
        {
            GameManager.Intrestance.playAudio();
            GameManager.Intrestance.m_GameHint("這裡的河流都流著汙水漂浮著垃圾並散發出陣陣惡臭，請你幫忙調查汙水的源頭。");//遊戲開始
            StartCoroutine(delayStart(7));
            PH_point.text = "未偵測";
        }
        else if (ClassTwoPlayer.Instrance.Part == 1)
        {
            ClassTwoPlayer.Instrance.LoadingHouse.SetActive(false);
            GameManager.Intrestance.m_GameHint("這座工廠並沒有將汙水處理完就排放了，請你幫忙將管線重新導向汙水處理廠吧!");
            StartCoroutine(delayStart(8));
        }
        else
        {
            GameManager.Intrestance.step = 1;
            GameManager.Intrestance.playAudio();
            Player.transform.position = River.position;
            gardage.gameObject.SetActive(true);
            ClassTwoPlayer.Instrance.LoadingHouse.SetActive(false);
            PH_point.text = "7";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator delayStart(float startTime)//延遲開始
    {
        yield return new WaitForSeconds(startTime);
        GameManager.Intrestance.m_StartGame();
    }

    //刪除關卡專有物
    public void closeCH2()
    {
        ClassTwoPlayer.Instrance.deldteOBJ();
    }
}
