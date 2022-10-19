using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionManager : MonoBehaviour
{
    public static PollutionManager Instance;

    public GameObject[] setPOINT;
    public GameObject[] GOJpfbs;

    private GameObject[] m_GOJpfbs = new GameObject[2];//�]�w�q
    private float delayTime = 10;
    private int put_in;//�üƨ��o��m�I
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
    //�U���ͦ�
    public void Garbage_put()
    {
        delayTime = 10;
        if (m_GOJpfbs[0]!=null && m_GOJpfbs[1]!= null)
        {
            return;
        }
        do//�]�m�I�T�{
        {
            put_in = Random.Range(0, setPOINT.Length);
        } while (setPOINT[put_in].activeSelf);
        setPOINT[put_in].SetActive(true);
        
        //�ͦ�
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
    //�����ͦ��I
    public IEnumerator ClosePoint(int point)
    {
        yield return new WaitForSeconds(1f);
        setPOINT[point].SetActive(false);
    }
}
