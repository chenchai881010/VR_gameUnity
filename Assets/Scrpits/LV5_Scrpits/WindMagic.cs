using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMagic : MonoBehaviour
{
    public GameObject shootPoint;
    public bool openshoot;
    public Color un_selet;
    public Color is_selet;
    public ParticleSystem particle;
    public LineRenderer line;

    GameObject be_game_obj;
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
                if (game_obj == null)//設置選擇物件
                {
                    game_obj = hit.collider.gameObject;
                    be_game_obj = game_obj;
                }
                else
                {
                    game_obj = hit.collider.gameObject;
                }
                line.SetPosition(1, hit.point);
                //選擇變化設置
                if (game_obj == be_game_obj)
                {
                    game_obj.GetComponent<Windseting>().isSeleting = true;
                }
                else
                {
                    be_game_obj.GetComponent<Windseting>().isSeleting = false;
                    be_game_obj = game_obj;
                }
                line.startColor = is_selet;
                line.endColor = is_selet;
                seleting = true;
            }
            else
            {
                if (be_game_obj != null)
                {
                    be_game_obj.GetComponent<Windseting>().isSeleting = false;
                }
                line.SetPosition(1, ray.origin + ray.direction * 1000);
                line.startColor = un_selet;
                line.endColor = un_selet;
                seleting = false;

            }
        }
    }
    //魔法啟用
    public void magic_set()
    {
        line.enabled = true;
        openshoot = true;
        particle.Play();
    }
    public void magic_unset()
    {
        if (be_game_obj != null)
        {
            be_game_obj.GetComponent<Windseting>().isSeleting = false;
        }
        line.enabled = false;
        openshoot = false;
        gameObject.SetActive(false);
        particle.Stop();
    }
    public void magic_shooting()
    {
        if (seleting)
        {
            if (game_obj != null) //設置選擇
            {
                    game_obj.GetComponent<Windseting>().setwind_elect();//
            }
            seleting = false;
        }
        line.enabled = false;
        if (be_game_obj != null)
        {
            be_game_obj.GetComponent<Windseting>().isSeleting = false;
        }
    }
}
