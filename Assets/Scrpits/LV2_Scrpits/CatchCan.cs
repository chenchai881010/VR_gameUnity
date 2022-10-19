using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchCan : MonoBehaviour
{
    public int getpoint;
    public GameObject hand;
    public GameObject hand_ray;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obj_catch"))
        {
            Destroy(other.gameObject);
            getpoint++;

            //滿分時結束
            if (getpoint>=5)
            {
                GardageManager.Intrestance.hideing();
                GameManager.Intrestance.playAudio();
                GameManager.Intrestance.m_WinGame("恭喜你成功解決河川的汙染源!");
                hand_ray.SetActive(true);
                hand.SetActive(false);
            }
        }
    }
}
