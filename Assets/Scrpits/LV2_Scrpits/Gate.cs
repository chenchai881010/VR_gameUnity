using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Transform target;
    public bool gatebool;
    public GameObject[] show;
    public GameObject[] hide;
    public bool SceneGate;//�����
    public string loadname;
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
                gameObject.SetActive(false);
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
            }
            
        }
    }
}
