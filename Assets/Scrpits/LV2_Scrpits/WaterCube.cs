using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCube : MonoBehaviour
{
    public Animator ani;
    bool startPlay;
    private void Start()
    {
        startPlay = false;
    }
    private void Update()
    {
        if (ani.GetBool("play"))
        {
            if (!startPlay)
            {
                startPlay = true;
                StartCoroutine(start_open());
            }
        }
    }
    public IEnumerator wait_open()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        GetComponent<BoxCollider>().enabled = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("microbe"))
        {
            Destroy(collision.gameObject);
            StartCoroutine(wait_open());
        }
    }
    public IEnumerator start_open()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(7);
        GetComponent<BoxCollider>().enabled = true;
    }
}
