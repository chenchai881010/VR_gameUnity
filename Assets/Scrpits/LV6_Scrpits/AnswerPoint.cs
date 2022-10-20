using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class AnswerPoint : MonoBehaviour
{
    public InputActionAsset inputActions;
    public GameObject[] Answers;
    public Questionpoint questionpoint;
    public UnityEvent confirm_pressed;
    public GameObject target;
    InputAction _confirm;
    // Start is called before the first frame update
    void Start()
    {
        _confirm = inputActions.FindActionMap("XRI RightHand").FindAction("confirm");
        _confirm.performed += confirm_setting;
        _confirm.Enable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questionpoint.openQuestion();
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            for (int i = 0; i < Answers.Length; i++)
            {
                Answers[i].GetComponent<ParticleSystem>().Play();
            }
            Destroy(target);
        }
    }
    private void confirm_setting(InputAction.CallbackContext context) => confirm_pressed.Invoke();
}
