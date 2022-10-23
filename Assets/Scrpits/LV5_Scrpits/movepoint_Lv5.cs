using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepoint_Lv5 : MonoBehaviour
{
    public Transform[] movepoint;
    public int movetime;
    public WindModle[] modles;
    private void Start()
    {
        movetime = 0;
    }
    private void OnTriggerEnter(Collider other)//傳送
    {
        if (other.CompareTag("Player"))
        {
            movetime ++;
            int n = movetime / 2;
            other.gameObject.transform.position = movepoint[movetime-(n*2)].position;

        }
    }
    public void GATE_ACTIVE()//啟用傳送們
    {
        if (modles[0].save && modles[1].save && modles[2].save)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
