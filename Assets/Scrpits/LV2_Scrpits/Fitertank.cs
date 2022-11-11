using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fitertank : MonoBehaviour
{
    //引導
    public GameObject guide;
    bool isGuide;
    //水物件
    public Material water;
    public MeshRenderer Water_Color;
    //探測物件
    public GameObject Durty;//探測子物件數量
    // Start is called before the first frame update
    void Start()
    {
        isGuide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Durty.transform.childCount == 0 && !isGuide)
        {
            isGuide = true;
            guide.SetActive(true);
            Water_Color.material = water;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("microbe"))
        {
            StartCoroutine(boxMove());
            Destroy(collision.gameObject);
        }
    }
    public IEnumerator boxMove()
    {
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(0.8f);
        GetComponent<BoxCollider>().enabled = true;
    }
}
