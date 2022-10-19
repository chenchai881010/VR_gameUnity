using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardageManager : MonoBehaviour//第三部份：撿垃圾
{
    public static GardageManager Intrestance;

    public GameObject[] Gardage_item;
    public Transform putpoint;//放置點



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
    //開啟垃圾
    public IEnumerator putgarbage()
    {
        GameManager.Intrestance.m_GameHint("汙水已淨化完成，使用中指握鍵拿取鏟子撈走剩下的河中垃圾吧!");
        yield return new WaitForSeconds(6.5f);
        GameManager.Intrestance.m_StartGame();
        for (int i = 0; i < Gardage_item.Length; i++)
        {
            Gardage_item[i].SetActive(true);
        }
        
    }
    //影藏垃圾
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
    //拉回流走的垃圾
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
