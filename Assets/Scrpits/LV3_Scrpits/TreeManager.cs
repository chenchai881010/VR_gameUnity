using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeManager : MonoBehaviour
{
    public static TreeManager Insterance;

    public TreeData tree_setting;
    public int TreePoint;//種植點數
    public Image[] treebutton;
    public Color Selet;
    //樹木介紹
    public Image tree_img;
    public Text tree_name;
    public Text tree_introduction;

    public GameObject main_view;
    public GameObject view_1;
    public GameObject view_2;
    private bool menu_press;
    [Space]
    public Text text;
    // Start is called before the first frame update
    private void Awake()
    {
        Insterance = this;
        TreePoint = -20;
    }
    void Start()
    {
        menu_press = true;
        view_1.SetActive(menu_press);
        view_2.SetActive(!menu_press);
        treebutton[0].gameObject.GetComponent<Button>().onClick.Invoke();
        
    }

    public void setTree(TreeData tree)//樹種選擇
    {
        tree_setting = tree;
        tree_img.sprite = tree.treeimage;
        tree_name.text = tree.tree_name;
        tree_introduction.text = tree.treeIntroduction;

    }
    public void Isselet(Image color)//按鈕上色
    {
        for (int i = 0; i < treebutton.Length; i++)
        {
            treebutton[i].color = Color.white;
        }
        color.color = Selet;
    }
    public void tree_point(int point)//植樹計分
    {
        TreePoint += point;
        stone_water();
    }
    public void manu_change()
    {
        if (main_view.activeSelf)
        {
            menu_press = !menu_press;
            view_1.SetActive(menu_press);
            view_2.SetActive(!menu_press);
        }
    }
    public void stone_water()
    {
        if (TreePoint < 0)
        {
            text.text = "土石流發生率 : 極高";
            RainBreaker.Instrance.WaterPower = 7;
            RainBreaker.Instrance.ex_up = 3;
        } else if (TreePoint < 50)
        {
            text.text = "土石流發生率 : 高";
            RainBreaker.Instrance.WaterPower = 6;
            RainBreaker.Instrance.ex_up =2;
        }
        else if (TreePoint < 150)
        {
            text.text = "土石流發生率 : 中";
            RainBreaker.Instrance.WaterPower = 4;
            RainBreaker.Instrance.ex_up = 1;
        }
        else 
        {
            text.text = "土石流發生率 : 低";
            RainBreaker.Instrance.WaterPower = 3;
            RainBreaker.Instrance.ex_up = 0;
        }


    }
}
