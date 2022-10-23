using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindMakeUI : MonoBehaviour
{
    //ui頁數
    public GameObject[] UIPages;
    public GameObject next;
    public GameObject previous;
    public GameObject confirm;
    public WindDesign nowDesign;
    public Text confirm_text;
    public GameObject text_savehint;
    private int my_page;

    private void Start()
    {
        my_page = 0;
    }
    public void next_page()
    {
        UIPages[my_page].SetActive(false);
        my_page++;
        UIPages[my_page].SetActive(true);
        if (my_page ==(UIPages.Length-1))
        {
            next.SetActive(false);
            confirm.SetActive(true);
            confirm_text.text = " 風扇類型 : "+nowDesign.Wind_head+"\n 風扇大小 : "
                + nowDesign.Wind_size + "\n 底座 : "+ nowDesign.Wind_base;
        }
    }
    public void previous_page()
    {
        UIPages[my_page].SetActive(false);
        my_page--;
        UIPages[my_page].SetActive(true);
        if (my_page == 0)
        {
            previous.SetActive(false);
        }
    }
    public void confirm_page()
    {
        my_page = 0;
        previous.SetActive(false);
        text_savehint.SetActive(true);
    }
}
