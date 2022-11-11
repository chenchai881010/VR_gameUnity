using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPools : MonoBehaviour
{
    public Transform[] mainpoints;//�D����
    public Transform[] otherpoints;//��L����
    int Microbe_num;//�L�ͪ��q
    // Start is called before the first frame update
    public void putting_Microbe(GameObject microbe)
    {
        if (Microbe_num < mainpoints.Length)
        {
            //��l��
            microbe.GetComponent<Rigidbody>().isKinematic = true;
            microbe.GetComponent<Rigidbody>().useGravity = false;
            microbe.GetComponent<Transform>().position = mainpoints[Microbe_num].position;

            //�ͦ�2���ܨ�L��
            Instantiate(microbe, otherpoints[Microbe_num].position, Quaternion.identity);
            Instantiate(microbe, otherpoints[Microbe_num+8].position, Quaternion.identity);
            Instantiate(microbe, otherpoints[Microbe_num+16].position, Quaternion.identity);
            ++Microbe_num;
            if (Microbe_num == mainpoints.Length)
            {
                microbe_box.Instrance.water_change();
            }
        }
        else
        {
            Destroy(microbe);
        }
    
    }
}
