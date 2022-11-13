using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_LV : MonoBehaviour
{
    public Transform Telepost_point;
    public GameObject main;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.transform.position = Telepost_point.position;
            main.gameObject.SetActive(false);

        }
    }
}
