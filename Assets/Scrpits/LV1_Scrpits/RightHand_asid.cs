using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class RightHand_asid : MonoBehaviour
{
    public InputActionAsset inputActions;
    public XRRayInteractor rayInteractor;
    InputAction trigger;
    InputAction grip;

    [Space]
    public UnityEvent Trigger_pressed;
    public UnityEvent Trigger_release;
    public UnityEvent Grip_pressed;
    public UnityEvent Grip_release;


    public LineRenderer UI_TEST;
    // Start is called before the first frame update
    void Start()
    {
        
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
    private void TriggerON(InputAction.CallbackContext context) => Trigger_pressed.Invoke();

    private void TriggerOff(InputAction.CallbackContext context) => Trigger_release.Invoke();

    private void GripON(InputAction.CallbackContext context) => Grip_pressed.Invoke();
    private void GripOff(InputAction.CallbackContext context) => Grip_release.Invoke();

    public void Hide_ray() => rayInteractor.enabled = false;
    public void Show_ray() => rayInteractor.enabled = true;

}
