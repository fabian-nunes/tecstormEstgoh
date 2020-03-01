using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    public static MoveSphere current;
    Vector3 initialPos;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        initialPos = transform.localPosition;
    }

    public void StartSpehere()
    {
        transform.localPosition = initialPos;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void StopSpehere()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        initialPos = transform.localPosition;
    }

}
