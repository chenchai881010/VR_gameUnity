using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IndexManager : MonoBehaviour
{
    public Image GameImage;
    public Text Gameplay;
    public Text GameIntroduction;
    public GameObject Loading;
    public GameObject Button_re;
    public GameObject Button_Play;
    public CHData[] cHDatas;
    [Space]
    public GameObject CheckView;

    private int dataID;
    private bool Goplay;
    private float loading_unm;
    private AsyncOperation async;
    // Start is called before the first frame update
    private void Start()
    {
        Goplay = false;
        Button_Play.SetActive(true);
        Button_re.SetActive(true);
        Loading.SetActive(false);

    }
    private void Update()
    {
        if (Goplay)
        {
            loading_unm = async.progress;
            if (loading_unm>=0.9f)
            {
                Goplay = false;
                async.allowSceneActivation = true;
            }
        }
    }
    //�T�{�C��
    public void checkGame(int item)
    {
        dataID = item - 1;
        GameImage.sprite = cHDatas[dataID].Game_images[0];//�Ϥ�
        Gameplay.text = cHDatas[dataID].HowToPlay;//�p��
        GameIntroduction.text = cHDatas[dataID].Class_Introduction;//�ҵ{����
        GameManager.Intrestance.step = item;
        GameManager.Intrestance.playAudio();
        if (item==5)
        {
            Debug.Log("PLAY");
            StartCoroutine(playvoice_Next(8.5F, item, 8));
        }
        StartCoroutine(Image_run(dataID));
        Button_Play.SetActive(true);
        Button_re.SetActive(true);
        Loading.SetActive(false);
    }
    //���J�C��
    public void TOplayScene()
    {
        Button_Play.SetActive(false);
        Button_re.SetActive(false);
        Loading.SetActive(true);
        async = SceneManager.LoadSceneAsync(cHDatas[dataID].PlayScene);
        async.allowSceneActivation = false;
        Goplay = true;
    }
    //�]���O
    public IEnumerator Image_run(int dataID)
    {
        int num = 0;
        
        while (CheckView.activeSelf)
        {
            if (num >= cHDatas[dataID].Game_images.Length)
            {
                num = 0;
            }
            GameImage.sprite = cHDatas[dataID].Game_images[num];//�Ϥ�
            yield return new WaitForSeconds(3);
            num++;
        }
        yield return null; 
    }

    public IEnumerator playvoice_Next(float s,int plays,int item)
    {
        yield return new WaitForSeconds(s);
        if (GameManager.Intrestance.step == plays+1)
        {
            GameManager.Intrestance.step = item;
            GameManager.Intrestance.playAudio();
        }
    }
    //learnWay����
    public void openData()
    {
        LearnWay.Instrance.OpenData();
    }
    //���椸����
    public void playAudioCH()
    {
        GameManager.Intrestance.m_source.clip = cHDatas[dataID].CHvoice;
        //Debug.Log(step);
        GameManager.Intrestance.m_source.Play();
        
    }
}
