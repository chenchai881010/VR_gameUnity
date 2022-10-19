using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanShootDataContraller : MonoBehaviour
{
    public Animator animator;
    public int ClearPoint;
    public bool mainClear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BEclear()//®g½u¸I¼²
    {
        
        if (mainClear)
        {
            GameContraller_LV1.Instrance.PollutionChange(ClearPoint);
            GameContraller_LV1.Instrance.PlayerTimeChange(5);
        }
        else
        {
            animator.SetFloat("Mod", 1);
            GameContraller_LV1.Instrance.ClearWorld(ClearPoint);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            BEclear();
            Destroy(other.gameObject);
        }
    }
}
