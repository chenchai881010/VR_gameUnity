using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_color_change : MonoBehaviour
{
    public Image Button_img;

    public Color cover_Color;
    // Start is called before the first frame update

    public void Button_Enter()
    {
        Button_img.color = cover_Color;
    }
    public void Button_Exit()
    {
        Button_img.color = Color.white;
    }
}
