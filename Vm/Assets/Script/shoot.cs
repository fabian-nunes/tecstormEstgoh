using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private Animator myAnimatorC;

    private bool test = true;
    
    // Start is called before the first frame update
    GameObject particle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray))
                {
                    if (test == false)
                    {
                         myAnimatorC.SetBool("Shoot", true);
                         test = true;
                    }
                    else
                    {
                        myAnimatorC.SetBool("Shoot", false);
                        test = false;
                    }
                   
                }
            }
        }
    }
}
