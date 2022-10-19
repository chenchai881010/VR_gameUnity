using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionManager : MonoBehaviour
{
    public static PollutionManager Instance;

    public GameObject[] setPOINT;
    public GameObject[] GOJpfbs;

    private GameObject[] m_GOJpfbs = new GameObject[2];//設定量
    private float delayTime = 10;
    private int put_in;//亂數取得放置點
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }
        if (delayTime <= 0)
        {
            Garbage_put();
        }
        else
        {
            delayTime -= Time.deltaTime;
        }
    }
    //垃圾生成
    public void Garbage_put()
    {
        delayTime = 10;
        if (m_GOJpfbs[0]!=null && m_GOJpfbs[1]!= null)
        {
            return;
        }
        do//設置點確認
        {
            put_in = Random.Range(0, setPOINT.Length);
        } while (setPOINT[put_in].activeSelf);
        setPOINT[put_in].SetActive(true);
        
        //生成
        if (m_GOJpfbs[0] == null)
        {
            m_GOJpfbs[0] = Instantiate(GOJpfbs[Random.Range(0, GOJpfbs.Length)], setPOINT[put_in].transform);
            m_GOJpfbs[0].GetComponent<GarbagePol>().put_point = put_in;

        }
        else if (m_GOJpfbs[1] == null)
        {
            m_GOJpfbs[1] = Instantiate(GOJpfbs[Random.Range(0, GOJpfbs.Length)], setPOINT[put_in].transform);
            m_GOJpfbs[1].GetComponent<GarbagePol>().put_point = put_in;
        }
        else
        {
            return;
        }
    
    }
    //關閉生成點
    public IEnumerator ClosePoint(int point)
    {
        yield return new WaitForSeconds(1f);
        setPOINT[point].SetActive(false);
    }
}
