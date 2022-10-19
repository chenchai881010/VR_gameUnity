using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class inputreader : MonoBehaviour
{
    List<InputDevice> inputDevices = new List<InputDevice>();

    // Start is called before the first frame update
    void Start()
    {
        InitalizeInputReader();
    }
    void InitalizeInputReader()
    {
        InputDevices.GetDevices(inputDevices);

        foreach (var inputDevice in inputDevices)
        {
            Debug.Log(inputDevice.name + "  " + inputDevice.characteristics);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (inputDevices.Count<2)
        {
            InitalizeInputReader();
        }
    }
}
