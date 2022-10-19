using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePlen_ground : MonoBehaviour
{
    public bool IsPlant;
    public TreeData treeData;
    public string treeType;
    public int point;
    public int strong_point;
    public void seed_plant(TreeData plant,Vector3 seedpoint)//�ش�
    {
        GameObject plant_obj = Instantiate(plant.treeModle, seedpoint, Quaternion.identity);
        plant_obj.GetComponent<TreePlen_ground>().treeData = TreeManager.Insterance.tree_setting;//�]�m���شӦ�m
        plant_obj.GetComponent<TreePlen_ground>().treeType = treeType;//�]�m���شӦ�m
        plant_obj.GetComponent<TreePlen_ground>().count_point(false);//�]�m���شӦ�m
    }
    public void cut_plant(GameObject plant)//�ް�
    {
        count_point(true);
        Destroy(plant);
    }

    public void count_point(bool iscut)//�p��
    {
        if (iscut)//���p��
        {
            TreeManager.Insterance.tree_point(-point);
        }
        else//�ؾ�p��
        {
            if (treeData.tree_type == treeType)
            {
                 point = treeData.point + 5;
                strong_point = 7;
            }
            else
            {
                point = treeData.point - 3;
                strong_point = 6;
                if (treeData.tree_type =="�L��")
                {
                    strong_point = 4;
                }
            }
            TreeManager.Insterance.tree_point(point);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (IsPlant)
        {
            if (other.CompareTag("Rain_hit"))
            {
                if (RainBreaker.Instrance.WaterPower > strong_point)
                {
                    //���˶�
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //�R��O�ܱj
                    RainBreaker.Instrance.water_Power_up(strong_point);
                }
                else
                {
                    //�R��O��z
                    RainBreaker.Instrance.water_Power_down(strong_point);
                }
            }
        }
    }
}
