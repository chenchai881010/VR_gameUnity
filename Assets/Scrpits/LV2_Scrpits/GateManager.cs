using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour//¶Ç°eªù
{
    public static GateManager Instrance;

    public Gate gate;
    public GameObject player;
    public Transform[] movepoint;
    // Start is called before the first frame update

    private void Awake()
    {
        Instrance = this;
    }

    public void callGate() 
    {
        gate.gameObject.transform.position = player.transform.forward + new Vector3(0, 0, 2);
        gate.target = movepoint[1];
    }
}
