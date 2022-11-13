using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    public ParticleSystem M_smoke;
    public CarContraller m_Car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckBan"))
        {
            M_smoke.Stop();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CheckBan"))
        {
            M_smoke.Play();
        }
    }
}
