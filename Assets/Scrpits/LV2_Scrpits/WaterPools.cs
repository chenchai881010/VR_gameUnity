using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPools : MonoBehaviour
{
    public Transform[] mainpoints;//主水池
    public Transform[] otherpoints;//其他水池
    int Microbe_num;//微生物量
    // Start is called before the first frame update
    public void putting_Microbe(GameObject microbe)
    {
        if (Microbe_num < mainpoints.Length)
        {
            //初始化
            microbe.GetComponent<Rigidbody>().isKinematic = true;
            microbe.GetComponent<Rigidbody>().useGravity = false;
            microbe.GetComponent<Transform>().position = mainpoints[Microbe_num].position;

            //生成2分至其他池
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
