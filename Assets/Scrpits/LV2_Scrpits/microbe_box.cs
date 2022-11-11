using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class microbe_box : MonoBehaviour
{//微生物桶
    public GameObject m_ui;
    public MeshRenderer Water_Color;
    public Material[] Water_m;
    public Transform Output_point;
    public GameObject microbe;
    public bool UsingBox;
    public int water_mod;//水的狀態
    public GameObject Guide;//導覽球

    Transform O_Transform;
    public bool IsFall;
    public static microbe_box Instrance;
    // Start is called before the first frame update

    private void Awake()
    {
        Instrance = this;
    }
    void Start()
    {
        O_Transform = gameObject.transform;
        UsingBox = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ui.activeSelf)//介紹ui
        {
            m_ui.transform.LookAt(Camera.main.transform);
        }
        Vector3 turn = transform.rotation.eulerAngles;//物件旋轉量
        if (((turn.x > 90&& turn.x < 270) || (turn.x < -90 && turn.x > -270)) ||
            ((turn.z > 90 && turn.z < 270) || (turn.z < -90 && turn.z > -270)))
        {
            if (UsingBox && !IsFall)
            {
                IsFall = true;
                StartCoroutine(put_micorbe());
            }
        }
        else
        {
            IsFall = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destory"))
        {
            Instantiate(gameObject, O_Transform.position, Quaternion.identity);
        }
    }
    public IEnumerator put_micorbe()//倒出微生物
    {
        while (UsingBox && IsFall)
        {
            Instantiate(microbe, Output_point.position, Quaternion.identity);
            yield return new WaitForSeconds(0.7f);

        }
        yield return null;
    }

    public void water_change()
    {
        Water_Color.material = Water_m[water_mod];

        ++water_mod;
        if (water_mod>=4)
        {
            Guide.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void use_box() => UsingBox = true;
    public void Unuse_box() => UsingBox = false;
}
