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

            //�����ɵ���
            if (getpoint>=5)
            {
                GardageManager.Intrestance.hideing();
                GameManager.Intrestance.playAudio();
                GameManager.Intrestance.m_WinGame("���ߧA���\�ѨM�e�t�����V��!");
                hand_ray.SetActive(true);
                hand.SetActive(false);
            }
        }
    }
}
