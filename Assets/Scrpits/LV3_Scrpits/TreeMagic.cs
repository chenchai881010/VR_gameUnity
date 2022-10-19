using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMagic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shootPoint;
    public bool openshoot;
    public Color un_selet;
    public Color is_selet;
    public ParticleSystem particle;
    public LineRenderer line;

    GameObject game_obj;
    Ray ray;
    RaycastHit hit;
    int shootLayar;
    bool seleting;
    // Start is called before the first frame update
    void Start()
    {
        shootLayar = LayerMask.GetMask("Shootable");
    }

    // Update is called once per frame
    void Update()
    {
        if (openshoot)
        {
            ray.origin = shootPoint.transform.position;
            ray.direction = shootPoint.transform.forward;
            line.SetPosition(0, shootPoint.transform.position);
            if (Physics.Raycast(ray, out hit, 1000, shootLayar))
            {
                line.SetPosition(1, hit.point);
                game_obj = hit.collider.gameObject;
                line.startColor = is_selet;
                line.endColor = is_selet;
                seleting = true;
            }
            else
            {
                line.SetPosition(1, ray.origin + ray.direction * 1000);
                line.startColor = un_selet;
                line.endColor = un_selet;
                seleting = false;
                
            }
        }
    }
    //Å]ªk±Ò¥Î
    public void magic_set()
    {
        line.enabled = true;
        openshoot = true;
    }
    public void magic_unset()
    {
        line.enabled = false;
        openshoot = false;
        gameObject.SetActive(false);
    }
    public void magic_shooting()
    {
        if (seleting)
        {
            if (game_obj != null)
            {
                if (game_obj.GetComponent<TreePlen_ground>().IsPlant)
                {
                    game_obj.GetComponent<TreePlen_ground>().cut_plant(game_obj);//¬å¾ð
                }
                else
                {
                    game_obj.GetComponent<TreePlen_ground>().seed_plant(TreeManager.Insterance.tree_setting,hit.point);//´Ó¾ð
                }
            }
            seleting = false;
        }
        line.enabled = false;
        
    }
}
