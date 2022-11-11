using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    //�ؼ�
    public Transform target;
    public bool gatebool;
    //�����ܤ�
    public GameObject[] show;
    public GameObject[] hide;
    public bool SceneGate;//�����
    public string loadname;
    public bool hintbool;//�O�_������
    public string hintText;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneGate)
            {
                //�}�Ҹ��J�p��
                ClassTwoPlayer.Instrance.openhouse();
                //�U���U�@�ӳ���
                ClassTwoPlayer.Instrance.TOplayScene(loadname);
                //�����ҫ�
                ClassTwoPlayer.Instrance.Part++;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                for (int i = 0; i < hide.Length; i++)
                {
                    hide[i].GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                other.gameObject.transform.position = target.position;
                //gameObject.SetActive(false);
                if (gatebool)
                {
                    for (int i = 0; i < show.Length; i++)
                    {
                        show[i].SetActive(true);
                    }
                    for (int i = 0; i < hide.Length; i++)
                    {
                        hide[i].SetActive(false);
                    }
                }
                if (hintbool)
                {
                    StartCoroutine(callhint(hintText));
                }
            }
            
        }
    }
    public IEnumerator callhint(string text)
    {
        GameManager.Intrestance.m_GameHint(text);
        yield return new WaitForSeconds(4);
        GameManager.Intrestance.m_StartGame();

    }
}
