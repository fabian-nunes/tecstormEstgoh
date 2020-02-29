using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject correct;

    public GameObject text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (correct.gameObject.name == "co")
        {
            text.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
