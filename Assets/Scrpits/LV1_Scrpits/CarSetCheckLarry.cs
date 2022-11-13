using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSetCheckLarry : MonoBehaviour
{
    public GameObject[] carLarry = new GameObject[10];//ó
    int next_car_id;
    int Car_count;//ó计璸计竟
    // Start is called before the first frame update
    private void Start()
    {
        next_car_id = 0;
        Car_count = 0;
    }
    public void CarPutLarry(GameObject checkCar)
    {
        if (Car_count == 10)
            return;
        if (Car_count == 0)
        {
            carLarry[0] = Instantiate(checkCar, gameObject.transform);
            carLarry[0].GetComponent<CarContraller>().m_CarData = checkCar.GetComponent<CarContraller>().m_CarData;
            carLarry[0].GetComponent<CarContraller>().isStop = true;
            carLarry[0].GetComponent<CarContraller>().speed = 4;
            carLarry[0].GetComponent<CarContraller>().checking = true;
            carLarry[0].transform.localPosition = Vector3.zero;
            ClearCheck(carLarry[0]);
            Destroy(carLarry[0].GetComponent<CanShootDataContraller>());
        }
        else
        {
            carLarry[Car_count] = Instantiate(checkCar, gameObject.transform);
            carLarry[Car_count].GetComponent<CarContraller>().m_CarData = checkCar.GetComponent<CarContraller>().m_CarData;
            carLarry[Car_count].GetComponent<CarContraller>().isStop = true;
            carLarry[Car_count].GetComponent<CarContraller>().speed = 4;
            carLarry[Car_count].transform.localPosition = 
                carLarry[Car_count-1].transform.localPosition + 
                carLarry[Car_count - 1].GetComponent<CarContraller>().CarSet.transform.localPosition;
            ClearCheck(carLarry[Car_count]);
            Destroy(carLarry[Car_count].GetComponent<CanShootDataContraller>());
        }
        Car_count++;
    }
    public void ClearCheck(GameObject car)
    {
        if (car.GetComponent<CanShootDataContraller>().mainClear)
        {
            car.GetComponent<CarContraller>().animator.SetFloat("Mod", 1);
        }
    }
    //浪代玡砞竚
    public void Step2_Seting()
    {
        for (int i = 1; i < carLarry.Length; i++)
        {
            if (carLarry[i] != null)
            {
                carLarry[i].transform.GetChild(2).gameObject.SetActive(false);
            }
        }
    }
    //近瑈浪代
    public void Next_Car()
    {
        next_car_id++;
        if (next_car_id >= 10 || carLarry[next_car_id] == null)
        {
            if (CarManager.Insterance.ok_Count<5)
            {
                GameManager.Intrestance.LoseGame();
            }
            return;
        }
        carLarry[next_car_id].GetComponent<CarContraller>().checking = true;
        carLarry[next_car_id].transform.GetChild(2).gameObject.SetActive(true);
        for (int i = next_car_id; i < carLarry.Length; i++)
        {
            if (carLarry[i] != null)
            {
                carLarry[i].GetComponent<CarContraller>().isStop = false;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            GetComponent<BoxCollider>().enabled = false;
            for (int i = next_car_id; i < carLarry.Length; i++)
            {
                if (carLarry[i] != null)
                {
                    carLarry[i].GetComponent<CarContraller>().isStop = true;
                }
            }
        }
    }

}
