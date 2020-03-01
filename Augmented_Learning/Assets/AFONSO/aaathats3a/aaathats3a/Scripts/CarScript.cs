using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    public static CarScript current;
    public bool start;

    public GameObject frontLightRT, frontLightLT, rearLightRT, rearLightLT, headLightRT, headLightLT;

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

    public void ShowLights()
    {
        frontLightRT.SetActive(true);
        frontLightLT.SetActive(true);
        rearLightRT.SetActive(true);
        rearLightLT.SetActive(true);
        headLightRT.SetActive(true);
        headLightLT.SetActive(true);

        Invoke("NoLights", 0.5f);
    }

    public void HideLights()
    {
        frontLightRT.SetActive(false);
        frontLightLT.SetActive(false);
        rearLightRT.SetActive(false);
        rearLightLT.SetActive(false);
        headLightRT.SetActive(false);
        headLightLT.SetActive(false);

        CancelInvoke("NoLights");
        CancelInvoke("ShowLights");
    }

    void NoLights()
    {
        rearLightRT.SetActive(false);
        rearLightLT.SetActive(false);

        Invoke("ShowLights", 0.5f);
    }

}
