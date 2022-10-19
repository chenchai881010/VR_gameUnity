using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain_test : MonoBehaviour
{
    public ParticleSystem rain;
    public Light sunlight;
    public Color lightcolor;
    // Start is called before the first frame update
    public void raintest()
    { 
        sunlight.color = lightcolor;
        rain.Play();
    }
    
}
