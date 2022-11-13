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
    public void Set_Car_Side()//�g�u�I��-�{�˰���
    {
        //�ƻs���l���{�˰�
        CarSetCheck.GetComponent<CarSetCheckLarry>().CarPutLarry(gameObject);

        //�P�w�O�_���H�W��
        if (mainClear)
        {
            GameContraller_LV1.Instrance.UI_update("Miss");
        }
        //�^������
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
