using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{

    public float scale;
    
    public void changeScale(float newScale)
    {
        scale = newScale;
    }
    
    void Update()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
