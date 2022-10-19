using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            GameManager.Intrestance.playAudio();
        }
    }
}
