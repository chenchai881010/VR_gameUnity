using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBan : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject shootpoint;
    public GameObject Bullet;


    bool fireSwitch = false;//發射允許
    // Start is called before the first frame update

    void Start()
    {
        particle.Stop();
        
    }
    private void Update()
    {
        
    }
    public void Magic_Use()//魔法使用
    {
        particle.Play();
        fireSwitch = true;
    }
    public IEnumerator Magic_stop()//魔法釋放結束
    {
        particle.Stop();
        fireSwitch = false;

        //延遲消失
        yield return new WaitForSeconds(0.1F);

    }
    public void Rayshooting()//發射魔法
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }
        if (!fireSwitch)
        {
            return;
        }

        //發射子彈
        GameObject bullet_colen = Instantiate(Bullet, shootpoint.transform.position, shootpoint.transform.rotation);
        bullet_colen.SetActive(true);

        StartCoroutine(Magic_stop());
        
    }
    //法杖消失
    public void disapper_ban ()
    {
        
        fireSwitch = false;
        gameObject.SetActive(false);
    }

}
