using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //needed to use button functions

public class LumberjackScript : MonoBehaviour
{
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    Animator animator;
    Quaternion originalRot;

    // Use this for initialization
    void Start () {
        definedButton = this.gameObject;
        animator = GetComponent<Animator>();
        originalRot = transform.localRotation;

    }
     
     // Update is called once per frame
     void Update () {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
         {
             if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
             {
                animator.SetTrigger("Lumb");
                Invoke("ResetPosition", 5f);
            }
         }    
     }

    void ResetPosition()
    {
        transform.localRotation = originalRot;
    }
     
    
}

