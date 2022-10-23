using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindMakeUI : MonoBehaviour
{
    //ui����
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
            confirm_text.text = " �������� : "+nowDesign.Wind_head+"\n �����j�p : "
                + nowDesign.Wind_size + "\n ���y : "+ nowDesign.Wind_base;
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
