using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    public static TitleScript current;
    public bool start;

    private void Awake()
    {
        current = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        start = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            transform.Rotate(new Vector3(0, 30f, 0) * Time.deltaTime);
        }
    }
}
