using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClassManager_LV2 : MonoBehaviour//�ĤG���`�޲z
{
    public static ClassManager_LV2 Instrance;

    public GardageManager gardage;
    public Transform River;
    public GameObject Player;//���a
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
            GameManager.Intrestance.m_GameHint("�o�̪��e�y���y�ۦ����}�B�۩U���ô��o�X�}�}�c��A�ЧA�����լd���������Y�C");//�C���}�l
            StartCoroutine(delayStart(7));
            PH_point.text = "������";
        }
        else if (ClassTwoPlayer.Instrance.Part == 1)
        {
            ClassTwoPlayer.Instrance.LoadingHouse.SetActive(false);
            GameManager.Intrestance.m_GameHint("�o�y�u�t�èS���N�����B�z���N�Ʃ�F�A�ЧA�����N�޽u���s�ɦV�����B�z�t�a!");
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
    public IEnumerator delayStart(float startTime)//����}�l
    {
        yield return new WaitForSeconds(startTime);
        GameManager.Intrestance.m_StartGame();
    }

    //�R�����d�M����
    public void closeCH2()
    {
        ClassTwoPlayer.Instrance.deldteOBJ();
    }
}
