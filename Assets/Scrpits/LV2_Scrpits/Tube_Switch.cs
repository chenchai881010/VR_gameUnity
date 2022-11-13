using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube_Switch : MonoBehaviour
{
    public Tube main_tude;//主水管
    public Tube[] child_tude;//副水管
    public Material water_color;

    public GameObject waterout;//

    public bool st_turn;
    float rotateSpeed = 2f;
    public Quaternion targetAngels;
    // Start is called before the first frame update
    private void Awake()
    {
        water_color = main_tude.water_mesh.material;
    }
    void Start()
    {
        //watermod = 0;
        waterout.transform.localPosition = new Vector3(0, -10f, 0.25f);
        targetAngels =  gameObject.transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        //水的汙染狀態
        if (water_color != main_tude.water_mesh.material)
        {
            water_color = main_tude.water_mesh.material;
            for (int i = 0; i < child_tude.Length; i++)
            {

                child_tude[i].water_color(water_color);
            }
        }
        //是否有水流進開關
        if (main_tude.Water_in && main_tude.water_run)
        {
            waterout.transform.localPosition= new Vector3(0,-0.2f,0.25f);
        }
        else
        {
            waterout.transform.localPosition = new Vector3(0, -10f, 0.25f);
        }
        if (st_turn)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngels, rotateSpeed * Time.deltaTime);
            if (targetAngels == gameObject.transform.rotation)
            {
                st_turn = false;
            }
        }
    }
    public void Turn_corn()
    {
        st_turn = true;
        targetAngels.eulerAngles += new Vector3(0, 90, 0);
        if (targetAngels.eulerAngles.y >=360)
        {
            targetAngels.eulerAngles += new Vector3(0,0, 0);
        }
    }
}
