using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassTwoPlayer : MonoBehaviour
{
    public static ClassTwoPlayer Instrance;

    public GameObject LoadingHouse;//載入小房間
    public GameObject Player;//玩家位置
    public string[] saveName;//運作場景
    public int Part=0;
    private bool life;//是否存在

    //載入下一個場景
    private bool Goplay;
    private float loading_unm;
    private AsyncOperation async;
    private void Awake()
    {
        if (Instrance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instrance = this;

        }
        else
        {
            Destroy(gameObject);
        }
        life = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //是否在運作場景中
        string SceneName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < saveName.Length; i++)
        {
            if (SceneName ==saveName[i])
            {
                life = true;
            }
        }
        if (!life)
        {
            Destroy(gameObject);
        }
    }
    public void openhouse()
    {
        LoadingHouse.transform.position = Player.transform.position;
        LoadingHouse.SetActive(true);
    }
    private void Update()
    {
        if (Goplay)
        {
            loading_unm = async.progress;
            if (loading_unm >= 0.9f)
            {
                Goplay = false;
                async.allowSceneActivation = true;
            }
        }
    }
    //載入遊戲
    public void TOplayScene(string _text)
    {
        async = SceneManager.LoadSceneAsync(_text);
        async.allowSceneActivation = false;
        Goplay = true;
    }
    //重製破壞
    public void deldteOBJ()
    {
        Destroy(gameObject);
    }
}
