using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject correct;
    public GameObject inCorrect;
    
    public GameObject text;
    public GameObject text1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "co")
        {
            text.SetActive(true);
            correct.tag = "Untagged";
        }
        
        else
        {
            text1.SetActive(true);
            yield return new WaitForSeconds(2);
            Debug.Log(this.GetComponent<originalP>().originalPos);
            inCorrect.transform.position = this.GetComponent<originalP>().originalPos;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.SetActive(false);
        text1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
