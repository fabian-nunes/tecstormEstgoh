using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceShip : MonoBehaviour
{
    public static MoveSpaceShip current;
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
            transform.Translate(new Vector3(0, 0, 0.5f) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpaceShipWall")
        {
            transform.localPosition = initialPos;
        }
    }
}
