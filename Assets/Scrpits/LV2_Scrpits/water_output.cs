using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_output : MonoBehaviour
{
    public bool waterout;
    public bool type;
    public ParticleSystem water_m;
    // Start is called before the first frame update
    private float phChange_time = 1; 
    // Update is called once per frame
    void Update()
    {
        if (waterout)
        {
            if (phChange_time<=0)
            {
                if (type)
                {
                    ClearManager.Intrestance.changePH(0.1f);
                }
                else
                {
                    ClearManager.Intrestance.changePH(-0.1f);
                }
                phChange_time = 1;
            }
            else
            {
                phChange_time -= Time.deltaTime;    
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water_out"))
        {
            water_m.Play();
            waterout = true;
            phChange_time = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water_out"))
        {
            water_m.Stop();
            waterout = false;
        }
    }
}
