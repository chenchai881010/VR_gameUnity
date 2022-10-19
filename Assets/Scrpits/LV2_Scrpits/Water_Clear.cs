using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Clear : MonoBehaviour
{
    public Tube input_Tube;
    public Tube output_Tube;

    public GameObject waterout;
    public Material water_color;
    public GameObject guide;
    public bool guide_bool;
    public Transform outPoint;

    public Animator[] Anis;
    // Start is called before the first frame update
    void Start()
    {
        //output_Tube.Water_mod(1);
        output_Tube.water_color(water_color);
        waterout.transform.position = outPoint.position+new Vector3(0, -10f, 0);
        guide_bool = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (input_Tube.Water_in && input_Tube.water_run)
        {
            waterout.transform.position = outPoint.position;
            if (!guide_bool)
            {
                guide.SetActive(true);
                for (int i = 0; i < Anis.Length; i++)
                {
                    Anis[i].SetBool("play", true);
                }
            }
        }
        else
        {
            waterout.transform.position = outPoint.position + new Vector3(0, -10f, 0);
            if (!guide_bool)
            {
                guide.SetActive(false);
            }
        }
    }
}
