using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public GameObject Coal;//¿U®Æ
    public GameObject Coal_prefad;//·Ñ¬´¼Ò«¬
    public Transform put_point;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
            if (Coal != null)
            {
                Destroy(Coal);
                FireManager.Intrestance.TextChange(Random.Range(120,85));
            }
        }
        else if (other.CompareTag("Coal"))
        {
            if (Coal == null)
            {
                Coal = Instantiate(Coal_prefad,put_point);
                Coal.transform.localPosition = Vector3.zero;
            }
        }
    }
}
