using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShootDataContraller : MonoBehaviour
{
    public Animator animator;
    public bool noShoot;
    public bool mainClear;
    public GameObject CarSetCheck;
    // Start is called before the first frame update
    private void Start()
    {
        CarSetCheck = GameObject.Find("CarSetCheck");
    }
    public void Set_Car_Side()//射線碰撞-臨檢停車
    {
        //複製車子到臨檢區
        CarSetCheck.GetComponent<CarSetCheckLarry>().CarPutLarry(gameObject);

        //判定是否為違規車
        if (mainClear)
        {
            GameContraller_LV1.Instrance.UI_update("Miss");
        }
        //回停車場
        GetComponent<CarContraller>().isStop = true;
        CarManager.Insterance.m_car_count--;
        gameObject.transform.position = CarManager.Insterance.Park[GetComponent<CarContraller>().CarID].position;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            if (noShoot||GameContraller_LV1.Instrance.playing_Lv>=2)
            {
                return;
            }
            Set_Car_Side();
            Destroy(other.gameObject);
        }
    }
}
