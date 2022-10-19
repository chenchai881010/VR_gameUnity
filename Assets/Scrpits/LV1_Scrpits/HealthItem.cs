using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int m_point;//恢復量/防護量

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        //位置影藏
        GameContraller_LV1.Instrance.PlayerTimeChange(m_point);

        gameObject.transform.position += new Vector3(0, -10, 0);
       
    }

   
}
