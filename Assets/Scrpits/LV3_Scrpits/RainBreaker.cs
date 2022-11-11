using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBreaker : MonoBehaviour
{
    public static RainBreaker Instrance;

    public int WaterPower;//水流力量
    public int PowerUP;//每12點提升水流力量一次\
    public int PowerDOWEN;//每12點下降水流力量一次
    private int counttime;
    public int ex_up;//額外強化
    public Material rain;
    public Material Orange;
    public Material bark;
    public Light Sunlight;
    public GameObject Moutaion_Rain;//山上雨水模型
    public GameObject[] grounds;
    //雨水系統
    public ParticleSystem rain01;
    public ParticleSystem rain02;
    // Start is called before the first frame update
    private void Awake()
    {
        Instrance = this;
    }
    private void Start()
    {
        rain.CopyPropertiesFromMaterial(Orange);
        gameObject.GetComponent<Animator>().SetBool("rain", false);
    }
    public void water_Power_up(int strongpoint)
    {
        switch (strongpoint)
        {
            case 4:
                PowerUP += 4;
                break;
            case 6:
                PowerUP += 6;
                break;
            case 7:
                PowerUP += 6;
                break;
            default:
                break;
        }
        if (PowerUP>=12)
        {
            PowerUP -= 12;
            WaterPower++;
        }

    }
    public void water_Power_down(int strongpoint)
    {
        switch (strongpoint)
        {
            case 4:
                PowerDOWEN += 1;
                break;
            case 6:
                PowerDOWEN += 1;
                break;
            case 7:
                PowerDOWEN += 2;
                break;
            default:
                break;
        }
        if (PowerDOWEN >= 12)
        {
            PowerDOWEN -= 12;
            WaterPower--;
        }

    }
    public void rain_start_test()
    {
        grounds[0].SetActive(true);
        for (int i = 1; i < grounds.Length; i++)
        {
            grounds[1].SetActive(false);
        }
        rain01.Play();
        Sunlight.color = Color.black;
        rain.CopyPropertiesFromMaterial(bark);
        gameObject.GetComponent<Animator>().SetBool("rain",true);
        if (WaterPower>5)
        {
            rain02.Play();
            StartCoroutine(waterup());
        }
        
    }
    public void rain_end_test()
    {
        if (counttime == 5)
        {
            gameObject.GetComponent<Animator>().SetBool("rain", false);
            if (WaterPower < 4)
            {
                GameManager.Intrestance.m_WinGame("水土保持做得很完美");
                GameManager.Intrestance.step = 3;
                GameManager.Intrestance.playAudio();
            }
            else if ((3 < WaterPower) && (WaterPower < 7))
            {
                GameManager.Intrestance.m_WinGame("盡量保持了，很不錯!");
            }
            else
            {
                GameManager.Intrestance.m_WinGame("土石流還是發生了，想一想再試一次看看");
                GameManager.Intrestance.step = 4;
                GameManager.Intrestance.playAudio();
            }
        }
        counttime++;
        WaterPower += ex_up;
        if (WaterPower > 10)
        {
            WaterPower = 10;
        }
        else if (WaterPower < 1)
        {
            WaterPower = 1;
        }
    }

    public IEnumerator waterup()
    {
        while (Moutaion_Rain.transform.position.y<=0 &&TreeManager.Insterance.TreePoint<50)
        {
            Moutaion_Rain.transform.position += new Vector3(0, 0.5f, 0);
            yield return new WaitForSeconds(0.5f);

        }
        
    }
}
