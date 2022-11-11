using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microbe_put : MonoBehaviour
{
    public bool inPool;//是否為水池物件
    Animator animator;
    bool active;//啟用動畫

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (inPool)
        {
            if (!active)
            {
                active = true;
                StartCoroutine(ani_act());
            }
        }
    }

    public IEnumerator ani_act()
    {
        animator.SetBool("active", active);
        yield return new WaitForSeconds(5);
        animator.SetTrigger("end");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pool"))
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            inPool = true;
            other.gameObject.GetComponent<WaterPools>().putting_Microbe(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
