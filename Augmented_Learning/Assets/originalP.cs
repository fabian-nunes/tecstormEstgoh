using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class originalP : MonoBehaviour
{
    public Vector3 originalPos;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPos = this.transform.position;
    }

    public void Done()
    {
        GameObject.Find("CubeM").gameObject.transform.position = originalPos;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
