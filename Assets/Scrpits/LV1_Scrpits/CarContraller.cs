using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARData
{
    public float CO;
    public int HC;
    public float CO2;
}
public class CarContraller : MonoBehaviour
{

    public string carType;//����
    public int CarID;
    public CARData m_CarData;

    //���ʳt�פ�V
    public float speed = 1f;
    public bool isVertical;
    public bool isReturn;

    public Animator animator;
    public bool isStop;
    public Transform CarSet;//���Z
    Vector3 movement;
    //�ˬd��
    public bool checking;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }

        if (!isStop)
        {
            moving();
        }
    }

    public void moving()
    {
        if (isVertical)
        {
            if (isReturn)
            {
                if (transform.rotation.y != 90)//�V�k
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1.5f);
                    movement = new Vector3(1, 0, 0);
                }
               
            }
            else
            {
                if (transform.rotation.y != -90)//�V��
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1.5f);
                    movement = new Vector3(-1, 0, 0);
                }

            }
            
            
        }
        else
        {
            if (isReturn)
            {
                if (transform.rotation.y != 180)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 1.5f);
                    movement = new Vector3(0, 0, -1);
                }

            }
            else
            {
                if (transform.rotation.y != 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1.5f);
                    movement = new Vector3(0, 0, 1);
                }

            }
            
            
        }
        gameObject.transform.position += movement * Time.deltaTime * speed;

    }
    public void Ani_rechange()//�H�üƳ]�m�������A
    {
        if (carType == "������")
        {
            m_CarData = new CARData
            {
                CO = Random.Range(1.5f, 6),
                HC = Random.Range(1100, 1750),
                CO2 = Random.Range(3, 12)
            };
            
            if (m_CarData.CO > 3.5f || m_CarData.HC > 1600)//�O�_���H�W��
            {
                GetComponent<CanShootDataContraller>().mainClear = false;
                animator.SetFloat("Mod", 0);
            }
            else
            {
                GetComponent<CanShootDataContraller>().mainClear = true;
                animator.SetFloat("Mod", 1);
            }
        }
        else
        {
            m_CarData = new CARData
            {
                CO = Random.Range(0.45f, 2.11f),
                HC = Random.Range(175, 320),
                CO2 = Random.Range(9, 17)
            };

            if (m_CarData.CO > 1.2f || m_CarData.HC > 220)//�O�_���H�W��
            {
                GetComponent<CanShootDataContraller>().mainClear = false;
                animator.SetFloat("Mod", 0);
            }
            else
            {
                GetComponent<CanShootDataContraller>().mainClear = true;
                animator.SetFloat("Mod", 1);
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)//�^�k���A
    {
        if ( other.CompareTag("StopLine"))
        {
            isStop = true;

            CarManager.Insterance.m_car_count--;
            gameObject.transform.position = CarManager.Insterance.Park[CarID].position;
        }
        if (other.CompareTag("OverCount"))
        {
            GetComponent<CanShootDataContraller>().noShoot = true;
            if (GetComponent<CanShootDataContraller>().mainClear == false)
            {
                GameContraller_LV1.Instrance.UI_update("Miss");
                GetComponent<CanShootDataContraller>().mainClear = true;
            }
            
        }
        if (other.CompareTag("Bullet")) 
        {
            if (GameContraller_LV1.Instrance.playing_Lv>=2 && checking)
            {
                
                StartCoroutine(CarManager.Insterance.CarChecking(this));
            }
            
        }
    }

}


