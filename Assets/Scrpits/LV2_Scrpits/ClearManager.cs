using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearManager : MonoBehaviour//第二部分：認識汙水處理-酸鹼中和
{
    public static ClearManager Intrestance;
    public float PH_point;
    public Text ph_text;

    public GameObject[] endhide;
    public GameObject Gate;
    public Canvas canvas;
    // Start is called before the first frame update
    private void Awake()
    {
        Intrestance = this;
    }
    void Start()
    {
        int b = Random.Range(0, 7);
        if (b % 2 == 0)
        {
            PH_point = Random.Range(3, 6);
        }
        else
        {
            PH_point = Random.Range(10, 8.7f);
        }
        if (PH_point.ToString().Length > 3)
        {
            ph_text.text = PH_point.ToString().Substring(0, 3);
        }
        else
        {
            ph_text.text = PH_point.ToString();
        }
        
    }

    //酸鹼變化
    public void changePH(float PH)
    {
        PH_point -= PH;
        ph_text.text = PH_point.ToString().Substring(0, 3);
    }
    //前往下一個區域
    public void toNext()
    {
        StartCoroutine(end_replay());
        Gate.SetActive(true);

        for (int i = 0; i < endhide.Length; i++)
        {
            if (i < 2)
            {
                endhide[i].transform.rotation = Quaternion.Euler(0, 0, 0);
                endhide[i].SetActive(false);
            }
            else
            {
                endhide[i].GetComponent<water_output>().waterout = false;
            }
            
        }
    }
    public IEnumerator end_replay()
    {
        canvas.enabled = true;
        yield return new WaitForSeconds(3f);
        canvas.enabled = false;
    }
}
