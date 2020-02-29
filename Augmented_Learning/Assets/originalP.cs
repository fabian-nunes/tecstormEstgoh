using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class originalP : MonoBehaviour
{
    public GameObject inCorrect;
    public Vector3 originalPos;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPos = inCorrect.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
