using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class UI_Controller_L : MonoBehaviour
{
    public InputActionAsset inputActions;
    public Canvas m_UIcanvas;
    public GameObject[] change_use;//替換使用物
    public GameObject[] nomal_use;//通常使用物
    public UnityEvent menu_pressed;
    InputAction _Menu;
    bool UI_isActive;
    // Start is called before the first frame update
    void Start()
    {
        _Menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        _Menu.performed += Menu_setting;
        _Menu.Enable();
        UI_isActive = m_UIcanvas.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!UI_isActive) return;
        transform.LookAt(Camera.main.transform);
    }
    private void Menu_setting(InputAction.CallbackContext context) => menu_pressed.Invoke();

    public void HandUI_close()//手部ui開關
    {
        UI_isActive = !UI_isActive;
        m_UIcanvas.enabled = UI_isActive;
    }
    public void NC_change()//狀態切換
    {
        UI_isActive = !UI_isActive;
        for (int i = 0; i < nomal_use.Length; i++)
        {
            nomal_use[i].SetActive(UI_isActive);
        }
        for (int i = 0; i < change_use.Length; i++)
        {
            change_use[i].SetActive(!UI_isActive);
        }
    }
}
