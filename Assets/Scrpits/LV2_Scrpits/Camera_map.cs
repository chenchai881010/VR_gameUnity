using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_map : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, 5, target.transform.position.z);
    }
}
