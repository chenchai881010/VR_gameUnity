using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SeletChange : MonoBehaviour
{
    public Image[] images;
    public Color color_selet;
    public Color color_nomal;
    // Start is called before the first frame update
    public void selet_Button(int num)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i == num)
            {
                images[i].color = color_selet;
            }
            else
            {
                images[i].color = color_nomal;
            }
        }
    }
}
