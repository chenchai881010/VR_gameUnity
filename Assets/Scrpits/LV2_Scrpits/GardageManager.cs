using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardageManager : MonoBehaviour//�ĤT�����G�ߩU��
{
    public static GardageManager Intrestance;

    public GameObject[] Gardage_item;
    public Transform putpoint;//��m�I



    // Start is called before the first frame update
    private void Awake()
    {
        Intrestance = this;
    }
    void Start()
    {
        
        StartCoroutine(putgarbage());
    }

    // Update is called once per frame
    //�}�ҩU��
    public IEnumerator putgarbage()
    {
        GameManager.Intrestance.m_GameHint("�����w�b�Ƨ����A�ϥΤ������䮳����l�����ѤU���e���U���a!");
        yield return new WaitForSeconds(6.5f);
        GameManager.Intrestance.m_StartGame();
        for (int i = 0; i < Gardage_item.Length; i++)
        {
            Gardage_item[i].SetActive(true);
        }
        
    }
    //�v�éU��
    public void hideing()
    {
        for (int i = 0; i < Gardage_item.Length; i++)
        {
            if (Gardage_item[i] != null)
            {
                Gardage_item[i].SetActive(false);
            }
            
        }
    }
    //�Ԧ^�y�����U��
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obj_catch"))
        {
            other.gameObject.SetActive(false);
            other.gameObject.transform.position = putpoint.position;
            other.gameObject.SetActive(true);
        }
    }
}
