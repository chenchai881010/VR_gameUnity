using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
    public GameObject Handprefad;
    public InputDeviceCharacteristics inputDeviceCharacteristics;

    private InputDevice _TargetDevice;
    private Animator _handAnimator;
    public GameObject spawnedHand;
    // Start is called before the first frame update
    void Start()
    {
        InitialzeHand();
    }
    private void InitialzeHand()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(inputDeviceCharacteristics, devices);

        if (devices.Count>0)//°»´ú¬O§_¦³¸Ë¸m
        {
            _TargetDevice = devices[0];

            spawnedHand = Instantiate(Handprefad, transform);
            _handAnimator = spawnedHand.GetComponent<Animator>();

        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!_TargetDevice.isValid)
        {
            InitialzeHand();
        }
        else
        {
            UpdateHand();
        }
    }
    private void UpdateHand()
    {
        if (_TargetDevice.TryGetFeatureValue(CommonUsages.trigger, out float TriggerValue))
        {
            _handAnimator.SetFloat("Trigger", TriggerValue);
        }
        else
        {
            _handAnimator.SetFloat("Trigger", 0);
        }
        if (_TargetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            _handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            _handAnimator.SetFloat("Grip", 0);
        }
    }
}
