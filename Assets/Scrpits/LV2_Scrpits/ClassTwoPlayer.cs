using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassTwoPlayer : MonoBehaviour
{
    public static ClassTwoPlayer Instrance;

    public GameObject LoadingHouse;//���J�p�ж�
    public GameObject Player;//���a��m
    public string[] saveName;//�B�@����
    public int Part=0;
    private bool life;//�O�_�s�b

    //���J�U�@�ӳ���
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
        //�O�_�b�B�@������
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
    //���J�C��
    public void TOplayScene(string _text)
    {
        async = SceneManager.LoadSceneAsync(_text);
        async.allowSceneActivation = false;
        Goplay = true;
    }
    //���s�}�a
    public void deldteOBJ()
    {
        Destroy(gameObject);
    }
}
