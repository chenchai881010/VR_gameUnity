using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;

public class HandButtonTest : MonoBehaviour
{
    public TextMeshProUGUI text;

    public InputActionAsset inputActions;
    public XRRayInteractor rayInteractor;
    InputAction trigger;
    InputAction grip;


    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;
        var inputActionMap = inputActions.FindActionMap("XRI RightHand");
        trigger = inputActionMap.FindAction("Activate");
        
        trigger.performed += TriggerON;
        trigger.canceled += TriggerOff;
        trigger.Enable();

        grip = inputActionMap.FindAction("Select");
        
        grip.performed += GripON;
        grip.canceled += GripOff;
        grip.Enable();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void TriggerON(InputAction.CallbackContext context)
    {
        text.text = "Ttrigger on";
    }
    private void TriggerOff(InputAction.CallbackContext context)
    {
        text.text = "Ttrigger off";
    }
    private void GripON(InputAction.CallbackContext context)
    {
        text.text = "Rrip on";
    }
    private void GripOff(InputAction.CallbackContext context)
    {
        text.text = "Rrip off";
    }
}
