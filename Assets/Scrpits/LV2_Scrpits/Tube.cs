using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    public bool mainWater;//�Ƥ���
    public Material main_color;
    public float IsClear=0;//�O�_�����b����
    public bool Water_in;//�O�_����
    public Animator Water_ani;
    public bool water_run;//���y�J�`�I
    public MeshRenderer water_mesh;
    // Start is called before the first frame update
    void Start()
    {
        if (mainWater)
        {
            Water_ani.SetBool("Water", mainWater);
            water_mesh.material = main_color;
            Water_in = true;
            IsClear = 0;
        }
    }
    public void water_inout_tude()
    {
        Water_ani.SetBool("Water", Water_in);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water_out"))
        {
            Water_in = true;
            water_inout_tude();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water_out"))
        {
            Water_in = false;
            water_inout_tude();
        }
    }
    public void Water_mod(float change)
    {
        IsClear = change;
        Water_ani.SetFloat("Clear", change);
    }
    public void water_end(bool water)
    {
        water_run = water;
        //Debug.Log(water_run);
    }
    public void water_color(Material water)
    {
        water_mesh.material = water;
    }
}
