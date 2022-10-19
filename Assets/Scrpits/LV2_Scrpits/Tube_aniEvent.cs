using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tube_aniEvent : MonoBehaviour
{
    public UnityEvent AniGame_in;
    public UnityEvent AniGame_out;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Water_in() => AniGame_in.Invoke();
    private void Water_out() => AniGame_out.Invoke();
}
