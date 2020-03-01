using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    public static MoveAsteroid current;
    public bool start;
    Vector3 initialPos;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            transform.Translate(Vector3.right * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.forward, 200f * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AsteroidWall")
        {
            transform.localPosition = initialPos;
        }
    }
}
