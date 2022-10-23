using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
public class WindManager : MonoBehaviour
{
    public GameObject MagicBan_Prefad;//法杖
    public GameObject Right_hand;//右手
    public Hand hand;//手部

    private GameObject m_Magic;
    //---------------------------------------
    public InputActionAsset inputActions;
    InputAction trigger;
    InputAction grip;

    [Space]
    public UnityEvent Trigger_pressed;
    public UnityEvent Trigger_release;
    public UnityEvent Grip_pressed;
    public UnityEvent Grip_release;
    //------------遊戲主要設定------------------------------
    public static WindManager Instrance;
    public string using_type;
    public WindModle my_Windsetting;//設定放置模型
    public GameObject[] WindModles;//模型資料庫
    // Start is called before the first frame update
    private void Awake()
    {
        Instrance = this;
    }
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

    public void UseMagic()//使用魔杖
    {
        if (m_Magic != null)
        {
            m_Magic.SetActive(true);
        }
        else
        {
            Right_hand = hand.spawnedHand;
            m_Magic = Instantiate(MagicBan_Prefad, Right_hand.transform.GetChild(0));
        }
    }

    public void UN_UseMagic()//不使用魔杖
    {
        if (m_Magic != null)
        {
            m_Magic.GetComponent<WindMagic>().magic_unset();
        }
    }
    public void Magic_set()//魔法設置
    {
        if (m_Magic != null)
        {
            if (m_Magic.activeSelf)
            {
                m_Magic.GetComponent<WindMagic>().magic_set();
            }
        }
    }
    public void Magic_shoot()//魔法使用
    {
        if (m_Magic != null)
        {
            m_Magic.GetComponent<WindMagic>().magic_shooting();
        }
    }
    //-------------------遊戲設定---------------
    public void setUse(string Type)
    {
        using_type = Type;
        switch (Type)
        {
            case "城市":
                GameManager.Intrestance.step = 2;
                GameManager.Intrestance.playAudio();
                my_Windsetting = WindModles[0].GetComponent<WindModle>();
                break;
            case "海邊":
                GameManager.Intrestance.step = 3;
                GameManager.Intrestance.playAudio();
                my_Windsetting = WindModles[1].GetComponent<WindModle>();
                break;
            case "沿岸":
                GameManager.Intrestance.step = 4;
                GameManager.Intrestance.playAudio();
                my_Windsetting = WindModles[2].GetComponent<WindModle>();
                break;
            default:
                break;
        }
    }

    //----------------------------------------------------------------------------------
    private void TriggerON(InputAction.CallbackContext context) => Trigger_pressed.Invoke();

    private void TriggerOff(InputAction.CallbackContext context) => Trigger_release.Invoke();

    private void GripON(InputAction.CallbackContext context) => Grip_pressed.Invoke();
    private void GripOff(InputAction.CallbackContext context) => Grip_release.Invoke();
}
