using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectAnswer : MonoBehaviour
{
    public GameObject correct;

    public GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (correct.name.Equals("co"))
        {
            text.SetActive(true);
        }
        else
        {
            
        }
    }

    void Correct()
    {
        
    }
}
