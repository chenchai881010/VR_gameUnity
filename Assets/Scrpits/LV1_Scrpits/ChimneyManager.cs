using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyManager : MonoBehaviour
{
    public static ChimneyManager Instance;
    public ChimneyPol[] chimneys;
    public GameObject[] smoke_point;
    public GameObject smoke;
    public int beClear = 4;
    public GameObject smokebomb;



    private int aqi_add = 1;//累計到10就加1point
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        beClear = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clearing()
    {
        beClear--;

        if (beClear < 2)
        {
            smoke_HITplayer(3);
            smoke.SetActive(false);
        }
        else
        {
            smoke_HITplayer(2);
        }
        if (beClear <= 0)
        {
            GameContraller_LV1.Instrance.PollutionChange(-100);
            GameManager.Intrestance.WinGame();
            GameManager.Intrestance.playAudio();
        }
    }

    public void AQI_up(int up)
    {
        aqi_add += up;
        if (aqi_add>=10)
        {
            aqi_add -= 10;
            GameContraller_LV1.Instrance.PollutionChange(30);
        }
    }
    public IEnumerator smoke_HITplayer(int smoke_shoot)//多發攻擊
    {
        for (int i = 0; i < chimneys.Length; i++)
        {
            chimneys[i].particle.Stop();
        }
        for (int i = 0; i < smoke_shoot;)
        {
            int set = Random.Range(0, smoke_point.Length);
            if (!smoke_point[set].activeSelf)
            {
                smoke_point[set].SetActive(true);
                GameObject smoke_hit = Instantiate(smokebomb, smoke_point[set].transform.position, Quaternion.identity);
                smoke_hit.SetActive(true);
                i++;
            }
            
        }
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < chimneys.Length; i++)
        {
            chimneys[i].particle.Play();
            smoke_point[i].SetActive(false);
        }
    }
    public IEnumerator smoke_oneHit(int num)//單發反擊
    {
        chimneys[num].particle.Stop();
        smoke_point[num].SetActive(true);
        GameObject smoke_hit = Instantiate(smokebomb, smoke_point[num].transform.position, Quaternion.identity);
        smoke_hit.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        chimneys[num].particle.Play();
        smoke_point[num].SetActive(true);
    }
}
