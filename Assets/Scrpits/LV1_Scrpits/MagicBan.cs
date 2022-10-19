using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBan : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject shootpoint;
    public GameObject Bullet;


    bool fireSwitch = false;//�o�g���\
    // Start is called before the first frame update

    void Start()
    {
        particle.Stop();
        
    }
    private void Update()
    {
        
    }
    public void Magic_Use()//�]�k�ϥ�
    {
        particle.Play();
        fireSwitch = true;
    }
    public IEnumerator Magic_stop()//�]�k���񵲧�
    {
        particle.Stop();
        fireSwitch = false;

        //�������
        yield return new WaitForSeconds(0.1F);

    }
    public void Rayshooting()//�o�g�]�k
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }
        if (!fireSwitch)
        {
            return;
        }

        //�o�g�l�u
        GameObject bullet_colen = Instantiate(Bullet, shootpoint.transform.position, shootpoint.transform.rotation);
        bullet_colen.SetActive(true);

        StartCoroutine(Magic_stop());
        
    }
    //�k������
    public void disapper_ban ()
    {
        
        fireSwitch = false;
        gameObject.SetActive(false);
    }

}
