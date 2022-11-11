using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FlatKit;

public class Obj_getting : MonoBehaviour
{
    public GameObject catchOBJ;//®·®»ª«

    public GameObject Put_point;//©ñ¸mÂI
    public GameObject body;
    public GameObject O_point;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obj_catch"))
        {
            catchOBJ = other.gameObject;
            StartCoroutine(putin());
        }
        if (other.CompareTag("Obj_return"))
         {
            body.transform.position = O_point.transform.position + new Vector3(0, 5, 0);
         }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obj_catch"))
        {
            catchOBJ = null;
        }
    }
    public IEnumerator putin()
    {
        catchOBJ.GetComponent<Rigidbody>().useGravity = false;
        catchOBJ.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(catchOBJ.GetComponent<Buoyancy>());
        Destroy(catchOBJ.GetComponent<Rigidbody>());  
        catchOBJ.gameObject.transform.parent = Put_point.transform;
        catchOBJ.transform.localPosition = Vector3.zero;
        yield return null;
    }
}
