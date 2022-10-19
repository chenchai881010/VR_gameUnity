using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube_Switch : MonoBehaviour
{
    public Tube main_tude;//�D����
    public Tube[] child_tude;//�Ƥ���
    public Material water_color;

    public GameObject waterout;//
    private float watermod;//�����V���A(��)
    // Start is called before the first frame update
    private void Awake()
    {
        water_color = main_tude.water_mesh.material;
    }
    void Start()
    {
        //watermod = 0;
        waterout.transform.localPosition = new Vector3(0, -10f, 0.25f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //�������V���A
        if (water_color != main_tude.water_mesh.material)
        {
            water_color = main_tude.water_mesh.material;
            for (int i = 0; i < child_tude.Length; i++)
            {

                child_tude[i].water_color(water_color);
            }
        }
        /*if (watermod != main_tude.IsClear)
        {
            watermod = main_tude.IsClear;
            main_tude.Water_mod(watermod);
            for (int i = 0; i < child_tude.Length; i++)
            {
                
                //child_tude[i].Water_mod(watermod);
            }
        }*/
        //�O�_�����y�i�}��
        if (main_tude.Water_in && main_tude.water_run)
        {
            waterout.transform.localPosition= new Vector3(0,-0.2f,0.25f);
        }
        else
        {
            waterout.transform.localPosition = new Vector3(0, -10f, 0.25f);
        }

    }
    
}
