using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public static CarManager Insterance;

    public GameObject[] CarModle;
    public GameObject[] CarPrefads = new GameObject[13];
    public Transform[] Set_Transfroms;//0=>�V�e�j�� 1=>�V�e���� 2=>�V�e�p�� //(�ק令��V�D)3=>�V��j�� 4=>�V�ᤤ�� 5=>�V��p��
    public Transform[] Park;//������(�v��)


    public int carCount = 0;//�����H�������
    public int PullCount=0;//���V�֭p�q


    float m_delay_time;
    int m_car_count;//�������
    int recar;
    // Start is called before the first frame update
    private void Awake()
    {
        Insterance = this;
    }
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            //int point = Random.Range(0, Set_Transfroms.Length);
            CarPrefads[i] = Instantiate(CarModle[Random.Range(8, 12)], Park[i].position, Quaternion.identity);
            CarPrefads[i].GetComponent<CarContraller>().CarID = i;
            CarPrefads[i].GetComponent<CarContraller>().isReturn = false;
            CarPrefads[i].GetComponent<CarContraller>().isVertical = false;
            CarPrefads[i].GetComponent<CarContraller>().isStop = true;

            
        }
        for (int i = 2; i < 6; i++)
        {
            CarPrefads[i] = Instantiate(CarModle[Random.Range(4, 8)], Park[i].position, Quaternion.identity);
            CarPrefads[i].GetComponent<CarContraller>().CarID = i;
            CarPrefads[i].GetComponent<CarContraller>().isReturn = false;
            CarPrefads[i].GetComponent<CarContraller>().isVertical = false;
            CarPrefads[i].GetComponent<CarContraller>().isStop = true;

           
        }
        for (int i = 6; i < 13; i++)
        {
             CarPrefads[i] = Instantiate(CarModle[Random.Range(0, 4)], Park[i].position, Quaternion.identity);
            CarPrefads[i].GetComponent<CarContraller>().CarID = i;
            CarPrefads[i].GetComponent<CarContraller>().isReturn = false;
             CarPrefads[i].GetComponent<CarContraller>().isVertical = false;
             CarPrefads[i].GetComponent<CarContraller>().isStop = true;

            
        }
        carCount = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }
        if (carCount<=0)
        {
            ResetCar();
        }
        if (PullCount>=1)
        {
            PullCount = 0;
            GameContraller_LV1.Instrance.PollutionChange(20);
        }

        if (m_delay_time <= 0 && m_car_count<carCount)
            SetCarRun();
        else
            m_delay_time -= Time.deltaTime;
    }
    public void SetCarRun()//���l����
    {
        for (int i = 0; i < 1; )
        {
            if (GameContraller_LV1.Instrance.playing_Lv == 1)
            {
                recar = Random.Range(6, CarPrefads.Length);
            }
            else
            {
                recar = Random.Range(0, CarPrefads.Length);
            }
            
            if (CarPrefads[recar].GetComponent<CarContraller>().isStop)
            {
                if (recar<2)
                {
                    CarPrefads[recar].transform.position = Set_Transfroms[0].position;
                }
                else if (recar < 6)
                {
                    CarPrefads[recar].transform.position = Set_Transfroms[1].position;
                } else
                {
                    CarPrefads[recar].transform.position = Set_Transfroms[2].position;
                }
                i++;
            }
        }
       
        CarPrefads[recar].GetComponent<CarContraller>().Ani_rechange();
        CarPrefads[recar].GetComponent<CarContraller>().isStop = false;
        m_delay_time=Random.Range(2f, 4.5f);
        m_car_count++;
        
    }
    public void ResetCar()//reset���l
    {
        if (GameContraller_LV1.Instrance.playing_Lv == 1)
        {
            carCount = 5;
        }
        else
        {
            carCount = 8;
        }
        
        m_car_count = 0;
        /*for (int i = 0; i < 13; i++)
        {
            CarPrefads[i].SetActive(false);
            if (i < 2)
            {
                CarPrefads[i].transform.position = Set_Transfroms[0].transform.localPosition;
            }
            else if (i < 6)
            {
                CarPrefads[i].transform.position = Set_Transfroms[1].transform.localPosition;
            }
            else if (i < 13)
            {
                CarPrefads[i].transform.position = Set_Transfroms[2].transform.localPosition;
            }
        }*/

    }
    public void Call_Car_Bake()
    {
        for (int i = 0; i < CarPrefads.Length; i++)
        {
            CarPrefads[i].transform.position = Park[i].position;
            CarPrefads[i].GetComponent<CarContraller>().isStop = true;
        }
    }

}
