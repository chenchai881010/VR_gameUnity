using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyPol : MonoBehaviour
{
    //public int Hart_Point;
    //public bool inChimneyRange;
    public Animator m_Animator;
    public Color[] Smokes;

    public ParticleSystem particle;
    public bool isClear;
    public int ID;
    //�ϧw��q�P�_������
    private int hp = 4;
    private float Rehit = 2.5f;//��_���A���ɶ�
    private float poltime;
    private float m_poltime;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        poltime = Random.Range(10, 15);
        m_Animator = GetComponent<CanShootDataContraller>().animator;
        particle.startColor = Smokes[Smokes.Length - hp];
        m_poltime = poltime;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.Intrestance.isPlaying || isClear)
        {
            return;
        }
        if (!gameObject.GetComponent<BoxCollider>().enabled)//�����٭�
        {
            if (Rehit <= 0)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                Rehit -= Time.deltaTime;
            }
        }
        if (m_Animator.GetFloat("Mod") != 0)//�����b��
        {
            isClear = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            ChimneyManager.Instance.Clearing();
            GameContraller_LV1.Instrance.PollutionChange(-20);
            GameContraller_LV1.Instrance.PlayerTimeChange(20);
        }
        if (m_poltime <= 0 && gameObject.GetComponent<BoxCollider>().enabled)//���V���A
        {
            Pollution();
        }
        else
        {
            m_poltime -= Time.deltaTime;
        }
    }
    public void Pollution()//���V�ܤ�
    {
        m_poltime = poltime;
        ChimneyManager.Instance.AQI_up(2);
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            hp--;
            Rehit = 2.5f;
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
            if (hp <= 0)
            {
                m_Animator.SetFloat("Mod", 1);
            }
            else
            {
                particle.startColor = Smokes[Smokes.Length - hp];
                StartCoroutine(ChimneyManager.Instance.smoke_oneHit(ID));
            }
        }
    }

}
