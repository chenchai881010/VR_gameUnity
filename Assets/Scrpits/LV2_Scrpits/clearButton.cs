using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearButton : MonoBehaviour
{
    public Animator animator;
    Animator m_ani;
    public bool open;
 
    private void Start()
    {
        
        m_ani = gameObject.GetComponent<Animator>();
    }
   
    public void pullbutton()
    {
        m_ani.SetBool("open", true);
        animator.SetBool("play", true);
    }
    public void UNpullbutton()
    {
        m_ani.SetBool("open", false);
    }
}
