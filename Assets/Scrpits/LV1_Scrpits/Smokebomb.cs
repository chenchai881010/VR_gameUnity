using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smokebomb : MonoBehaviour
{
    public Rigidbody rd;
    public GameObject body;
    public GameObject bomb;
    public float speed;
    public GameObject target;
    private bool HIT;
    private bool stay=false;
    private float resat_time = 1f;
    // Start is called before the first frame update
    void Start()
    {
        HIT = false;
        rd = GetComponent<Rigidbody>();
        transform.LookAt(target.transform);
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }
        if (resat_time <= 0)
        {
            stay = true;
        }
        else
        {
            resat_time -= Time.deltaTime;
        }
        if (!HIT && stay)
        {
            rd.AddForce(transform.forward * speed);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HIT = true;
            //rd.AddForce(Vector3.zero);
            rd.velocity = Vector3.zero;
            body.SetActive(false);
            bomb.SetActive(true);
            GetComponent<SphereCollider>().enabled = false;
            GameContraller_LV1.Instrance.PlayerTimeChange(-10);
            Destroy(gameObject, 1f);
        }
    }
}
