using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpaper : MonoBehaviour
{
    public Color[] testcolor;
    public Material material;
    public GameObject org_put;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        material.color = Color.white;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("poolwater"))
        {
            float ph = ClearManager.Intrestance.PH_point;
            if (ph < 4.1f)
            {
                material.color = testcolor[0];
            } else if (ph < 5.1f)
            {
                material.color = testcolor[1];
            }
            else if (ph < 6.1f)
            {
                material.color = testcolor[2];
            }
            else if (ph < 6.7f)
            {
                material.color = testcolor[3];
                //達標
                ClearManager.Intrestance.toNext();
            }
            else if (ph < 7.1f)
            {
                material.color = testcolor[4];
                //達標
                ClearManager.Intrestance.toNext();
            }
            else if (ph < 7.7f)
            {
                material.color = testcolor[5];
                //達標
                ClearManager.Intrestance.toNext();
            }
            else if (ph < 8.6f)
            {
                material.color = testcolor[6];
            }
            else if (ph < 9.1f)
            {
                material.color = testcolor[7];
            }
            else if (ph < 9.6f)
            {
                material.color = testcolor[8];
            }
            else 
            {
                material.color = testcolor[9];
            }
        }
    }
    public void reput_test()
    {
        Instantiate(body, org_put.transform.position, Quaternion.Euler(0,90,0));
        Destroy(body, 0.5f);
    }
}
