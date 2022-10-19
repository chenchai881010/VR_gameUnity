using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePol : MonoBehaviour
{
    public int Hart_Point;
    public bool inGarbageRange;
    public Animator m_Animator;

    public int put_point;//放置點

    private float delayTime = 5;
    private float m_delayTime;
    // Start is called before the first frame update
    void Start()
    {
        m_delayTime = delayTime;
        m_Animator = GetComponent<CanShootDataContraller>().animator;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }
        if (inGarbageRange)
        {
            if (m_delayTime <= 0)
            {
                Pollution();
            }
            else
            {
                m_delayTime -= Time.deltaTime;
            }
        }
        if (m_Animator.GetFloat("Mod") != 0)
        {
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 0.75f);
            StartCoroutine(PollutionManager.Instance.ClosePoint(put_point));
        }
    }
    public void Pollution()//汙染變化
    {
        m_delayTime = delayTime;
       
        GameContraller_LV1.Instrance.PollutionChange(1);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inGarbageRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inGarbageRange = false;
        }
    }
}
