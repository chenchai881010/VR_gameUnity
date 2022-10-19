using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Transform target;
    public bool gatebool;
    public GameObject[] show;
    public GameObject[] hide;
    public bool SceneGate;//跳轉門
    public string loadname;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (SceneGate)
            {
                //開啟載入小屋
                ClassTwoPlayer.Instrance.openhouse();
                //下載下一個場景
                ClassTwoPlayer.Instrance.TOplayScene(loadname);
                //關閉模型
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
