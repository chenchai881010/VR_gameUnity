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
    public void seed_plant(TreeData plant,Vector3 seedpoint)//種植
    {
        GameObject plant_obj = Instantiate(plant.treeModle, seedpoint, Quaternion.identity);
        plant_obj.GetComponent<TreePlen_ground>().treeData = TreeManager.Insterance.tree_setting;//設置樹木種植位置
        plant_obj.GetComponent<TreePlen_ground>().treeType = treeType;//設置樹木種植位置
        plant_obj.GetComponent<TreePlen_ground>().count_point(false);//設置樹木種植位置
    }
    public void cut_plant(GameObject plant)//拔除
    {
        count_point(true);
        Destroy(plant);
    }

    public void count_point(bool iscut)//計分
    {
        if (iscut)//砍樹計分
        {
            TreeManager.Insterance.tree_point(-point);
        }
        else//種樹計分
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
                if (treeData.tree_type =="淺根")
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
                    //樹木倒塌
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    //沖刷力變強
                    RainBreaker.Instrance.water_Power_up(strong_point);
                }
                else
                {
                    //沖刷力減弱
                    RainBreaker.Instrance.water_Power_down(strong_point);
                }
            }
        }
    }
}
