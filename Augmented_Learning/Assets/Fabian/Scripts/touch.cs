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
        nice = true;
        this.GetComponent<AudioSource>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void Music()
    {
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
