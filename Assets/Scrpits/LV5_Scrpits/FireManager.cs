using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
public class FireManager : MonoBehaviour
{
    public static FireManager Intrestance;

    //霧霾
    public Material sky;
    //電量累積
    public Text electText;
    public int elect_point;
    public Text endplay;
    public GameObject button_learn;
    public GameObject button_end;
    public GameObject shovel;
    //切換鍵
    public GameObject[] nomal_use;
    public GameObject[] change_use;
    public InputActionAsset inputActions;
    public UnityEvent menu_pressed;
    InputAction _Menu;
    private bool UI_isActive = true;

    private bool MIND_TRG;
    // Start is called before the first frame update
    private void Awake()
    {
        Intrestance = this;
    }
    void Start()
    {
        _Menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        _Menu.performed += Menu_setting;
        _Menu.Enable();
        elect_point = 0;
        UI_isActive = true;
        MIND_TRG = false;
    }

    // Update is called once per frame


    //UI數值變化
    public void TextChange(int point)
    {
        elect_point += point;
        string pointtext = elect_point.ToString().PadLeft(4,'0');
        electText.text = "當前電量：<color=#FFF>"+pointtext+" MW</color>";
        FogDensityChange(elect_point);
        if (!MIND_TRG && elect_point>=500)
        {
            GameManager.Intrestance.step = 7;
            GameManager.Intrestance.playAudio();
            MIND_TRG = true;
        }
        if (elect_point>=1000)
        {
            stopplay();
        }
    }
    //霾害狀態變化
    public void FogDensityChange(int point)
    {
        RenderSettings.fogDensity = (float)point * 0.0001f * 0.5f;
    }
    //開啟介紹ui
    public void stopplay()
    {
        endplay.text = "恭喜達到目標電量";
        button_end.SetActive(true);
        button_learn.SetActive(true);
        //切換成ui控制模式//影藏鏟子
        for (int i = 0; i < nomal_use.Length; i++)
        {
            nomal_use[i].SetActive(false);
        }
        for (int i = 0; i < change_use.Length; i++)
        {
            change_use[i].SetActive(true);
        }
        shovel.SetActive(false);
        gameObject.SetActive(false);
        GameManager.Intrestance.step = 8;
        GameManager.Intrestance.playAudio();
    }
    //Menu控制項目
    private void Menu_setting(InputAction.CallbackContext context) => menu_pressed.Invoke();

    public void change_modle()
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
