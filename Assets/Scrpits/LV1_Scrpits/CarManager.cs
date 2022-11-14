using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    public static CarManager Insterance;

    public GameObject[] CarModle;
    public GameObject[] CarPrefads = new GameObject[13];
    public Transform[] Set_Transfroms;//0=>向前大車 1=>向前中車 2=>向前小車 
    public Transform[] Park;//停車場(隱藏)

    public int carCount = 0;//車輛以釋放紀錄

    float m_delay_time;
    public int m_car_count;//釋放紀錄
    int recar;
    //step2 元素
    public GameObject carLarry;//攔截板
    public int UseWay;//方案代號
    public int ok_Count;
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
        carCount = 8;
        ok_Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Intrestance.isPlaying || GameContraller_LV1.Instrance.playing_Lv != 1)
        {
            return;
        }
        if (carCount<=0)
        {
            ResetCar();
        }
        
        if (m_delay_time <= 0 && m_car_count<carCount )
            SetCarRun();
        else
            m_delay_time -= Time.deltaTime;
    }
    public void SetCarRun()//設定車子移動
    {
        for (int i = 0; i < 1; )
        {
                recar = Random.Range(0, CarPrefads.Length);
            
            if (CarPrefads[recar].GetComponent<CarContraller>().isStop)
            {
                if (recar<6)
                {
                    CarPrefads[recar].transform.position = Set_Transfroms[0].position;
                }
                else
                {
                    CarPrefads[recar].transform.position = Set_Transfroms[1].position;
                } 
                i++;
            }
        }
       
        CarPrefads[recar].GetComponent<CarContraller>().Ani_rechange();
        CarPrefads[recar].GetComponent<CarContraller>().isStop = false;
        CarPrefads[recar].GetComponent<CanShootDataContraller>().noShoot = false;
        m_delay_time =Random.Range(3.5f, 4.5f);
        m_car_count++;
        
    }
    public void ResetCar()//reset車子
    {
        carCount = 8;
        m_car_count = 0;
    }
    public void Call_Car_Bake()
    {
        for (int i = 0; i < CarPrefads.Length; i++)
        {
            CarPrefads[i].transform.position = Park[i].position;
            CarPrefads[i].GetComponent<CarContraller>().isStop = true;
        }
    }
    //車輛優化
    public void ClearMeth(int n)//選定處理方案
    {
        UseWay = n;
    }
    public IEnumerator CarChecking(CarContraller car)//處理運作
    {
        car.checking = false;
        if (car.carType =="摩托車")
        {
            switch (UseWay)
            {
                case 1:
                    if (car.m_CarData.CO <=3.5 && car.m_CarData.HC <= 1600)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                case 2:
                    if (car.m_CarData.CO > 3.5 && car.m_CarData.HC <= 1600)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                case 3:
                    if (car.m_CarData.CO <= 3.5 && car.m_CarData.HC > 1600)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                case 4:
                    if (car.m_CarData.CO > 3.5 && car.m_CarData.HC > 1600)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (UseWay)
            {
                case 1:
                    if (car.m_CarData.CO <= 1.2 && car.m_CarData.HC <= 220)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                case 2:
                    if (car.m_CarData.CO > 1.2 && car.m_CarData.HC <= 220)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                case 3:
                    if (car.m_CarData.CO <= 1.2 && car.m_CarData.HC > 220)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                case 4:
                    if (car.m_CarData.CO > 1.2 && car.m_CarData.HC > 220)
                    {
                        car.animator.SetFloat("Mod", 1);
                        ok_Count++;
                    }
                    break;
                default:
                    break;
            }
        }

        if (car.animator.GetFloat("Mod") == 1)
        {
            GameManager.Intrestance.step = 5;
            GameManager.Intrestance.playAudio();
        }
        else
        {
            GameManager.Intrestance.step = 6;
            GameManager.Intrestance.playAudio();
        }
        car.isStop = false;
        yield return new WaitForSeconds(5);
        GameContraller_LV1.Instrance.ChekWINorLOSE(ok_Count);
        carLarry.GetComponent<BoxCollider>().enabled = true;
        carLarry.GetComponent<CarSetCheckLarry>().Next_Car();
    }

}
