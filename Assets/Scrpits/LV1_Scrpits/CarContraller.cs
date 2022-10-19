using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContraller : MonoBehaviour
{
    public bool isVertical;
    public bool isReturn;
    public int CarID;

    public float speed = 1f;
    public Animator animator;
    public bool isStop;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!GameManager.Intrestance.isPlaying)
        {
            return;
        }

        if (!isStop)
        {
            moving();
        }
    }

    public void moving()
    {
        if (isVertical)
        {
            if (isReturn)
            {
                if (transform.rotation.y != 90)//¦V¥k
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), 1.5f);
                    movement = new Vector3(1, 0, 0);
                }
               
            }
            else
            {
                if (transform.rotation.y != -90)//¦V¥ª
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, -90, 0), 1.5f);
                    movement = new Vector3(-1, 0, 0);
                }

            }
            
            
        }
        else
        {
            if (isReturn)
            {
                if (transform.rotation.y != 180)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), 1.5f);
                    movement = new Vector3(0, 0, -1);
                }

            }
            else
            {
                if (transform.rotation.y != 0)
                {
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 1.5f);
                    movement = new Vector3(0, 0, 1);
                }

            }
            
            
        }
        gameObject.transform.position += movement * Time.deltaTime * speed;

    }
    public void Ani_rechange()
    {
        animator.SetFloat("Mod",0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("StopLine"))
        {
            isStop = true;
            if (animator.GetFloat("Mod")==0)
            {
                CarManager.Insterance.PullCount++;
            }
            CarManager.Insterance.carCount--;
            gameObject.transform.position = CarManager.Insterance.Park[CarID].position;
        }
    }

}
