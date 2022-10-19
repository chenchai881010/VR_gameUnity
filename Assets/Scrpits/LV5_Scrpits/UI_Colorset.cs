using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Colorset : MonoBehaviour
{
    public Image[] change_image;

    public Color changeColor;

    public void ui_click(int num)
    {
        for (int i = 0; i < change_image.Length; i++)
        {
            if (i == num)
            {
                change_image[i].color = changeColor;
            }
            else
            {
                change_image[i].color = Color.white;
            }
        }
    }
}
