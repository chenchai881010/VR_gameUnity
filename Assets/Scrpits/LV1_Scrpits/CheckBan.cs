using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
public class CheckBan : MonoBehaviour
{
    public InputActionAsset inputActions;
    public GameObject uiLoading;
    InputAction grip;
    bool StartCheck;
    float waitTime;
    Smoke nowSmoke;
    [Space]
    public UnityEvent Grip_pressed;
    public UnityEvent Grip_release;
    // Start is called before the first frame update
    void Start()
    {
        var inputActionMap = inputActions.FindActionMap("XRI LeftHand");
        grip = inputActionMap.FindAction("Select");

        grip.performed += GripON;
        grip.canceled += GripOff;
        grip.Enable();
        StartCheck = false;
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (StartCheck)
        {
            if (waitTime <= 0)
            {
                uiLoading.SetActive(false);
                //顯示數據
                GameContraller_LV1.Instrance.step2_check(nowSmoke.m_Car);
            }
            else
            {
                uiLoading.SetActive(true);
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            uiLoading.SetActive(false);
        }
    }
    public void CallCheckBan()
    {
        if (GameContraller_LV1.Instrance.playing_Lv>=2)
        {
            gameObject.SetActive(true);
        }
    }
    private void GripON(InputAction.CallbackContext context) => Grip_pressed.Invoke();
    private void GripOff(InputAction.CallbackContext context) => Grip_release.Invoke();

    //排氣管碰撞
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Smoke"))
        {
            if (!StartCheck)
            {
                waitTime = Random.Range(6, 10);
            }
            StartCheck = true;
            nowSmoke = other.gameObject.GetComponent<Smoke>();
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Smoke"))
        {
            StartCheck = false;
            nowSmoke = null;
        }
    }
}
