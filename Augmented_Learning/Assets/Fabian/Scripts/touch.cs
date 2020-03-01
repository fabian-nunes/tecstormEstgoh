using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{
    private bool nice;
    // Start is called before the first frame update
    void Start()
    {
        nice = false;
        this.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseDown()
    {
        Debug.Log("nice");
        if (nice == false)
        {
            this.GetComponent<AudioSource>().Play();
            nice = true;
        }
        else
        {
            this.GetComponent<AudioSource>().Stop();
            nice = false;
        }
    }
}
