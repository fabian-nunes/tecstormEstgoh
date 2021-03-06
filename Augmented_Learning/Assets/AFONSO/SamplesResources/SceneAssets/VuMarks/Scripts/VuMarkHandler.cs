/*===============================================================================
Copyright (c) 2016-2018 PTC Inc. All Rights Reserved.

Vuforia is a trademark of PTC Inc., registered in the United States and other
countries.
===============================================================================*/
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

/// <summary>
/// A custom handler which uses the VuMarkManager.
/// </summary>
public class VuMarkHandler : MonoBehaviour
{
    #region PRIVATE_MEMBER_VARIABLES
    // Define the number of persistent child objects of the VuMarkBehaviour. When
    // destroying the instance-specific augmentations, it will start after this value.
    // Persistent Children:
    // 1. Canvas -- displays info about the VuMark
    // 2. LineRenderer -- displays border outline around VuMark
    const int PersistentNumberOfChildren = 2;
    VuMarkManager vumarkManager;
    LineRenderer lineRenderer;
    Dictionary<string, Texture2D> vumarkInstanceTextures;
    Dictionary<string, GameObject> vumarkAugmentationObjects;

    PanelShowHide nearestVuMarkScreenPanel;
    VuMarkTarget closestVuMark;
    VuMarkTarget currentVuMark;
    Camera vuforiaCamera;

    private int img;
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region PUBLIC_MEMBERS
    [System.Serializable]
    public class AugmentationObject
    {
        public string vumarkID;
        public GameObject augmentation;
    }
    public AugmentationObject[] augmentationObjects;
    #endregion // PUBLIC_MEMBERS

    #region MONOBEHAVIOUR_METHODS
    void Awake()
    {
        VuforiaConfiguration.Instance.Vuforia.MaxSimultaneousImageTargets = 10; // Set to 10 for VuMarks
    }

    void Start()
    {
        LostVuMarkUI.SetActive(true);
        InteractVuMarkUI.SetActive(false);

        int l = 0;
        while(l < 2)
        {

            test1.SetActive(false);
            augmentationObjects[img].augmentation.SetActive(false);

            l++;
        }

        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);

        this.vumarkInstanceTextures = new Dictionary<string, Texture2D>();
        this.vumarkAugmentationObjects = new Dictionary<string, GameObject>();

        foreach (AugmentationObject obj in this.augmentationObjects)
        {
            this.vumarkAugmentationObjects.Add(obj.vumarkID, obj.augmentation);
        }

       

        this.nearestVuMarkScreenPanel = FindObjectOfType<PanelShowHide>();
    }

    void Update()
    {
        
    }

    void OnDestroy()
    {
        VuforiaConfiguration.Instance.Vuforia.MaxSimultaneousImageTargets = 4; // Reset back to 4 when exiting
        // Unregister callbacks from VuMark Manager
      
        this.vumarkManager.UnregisterVuMarkDetectedCallback(OnVuMarkDetected);
        this.vumarkManager.UnregisterVuMarkLostCallback(OnVuMarkLost);
    }

    #endregion // MONOBEHAVIOUR_METHODS

    void OnVuforiaStarted()
    {
        // register callbacks to VuMark Manager
        this.vumarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        this.vumarkManager.RegisterVuMarkDetectedCallback(OnVuMarkDetected);
        this.vumarkManager.RegisterVuMarkLostCallback(OnVuMarkLost);
        this.vuforiaCamera = VuforiaBehaviour.Instance.GetComponent<Camera>();
    }

    #region VUMARK_CALLBACK_METHODS


    public void ScreenShot()
    {
        var time = System.DateTime.Now;
        ScreenCapture.CaptureScreenshot("Screenshot"+time.ToString("yyyyMMdd_HHmmss")+".png");
    }

    ////////////////////////////////////////////
    //Só intressam estas duas funções por agora
    /// <summary>
    /// This method will be called whenever a new VuMark is detected
    /// </summary>
    public GameObject test1;
    public void OnVuMarkDetected(VuMarkTarget vumarkTarget)
    {
        LostVuMarkUI.SetActive(false);
        InteractVuMarkUI.SetActive(true);


        Debug.Log("<color=cyan>VuMarkHandler.OnVuMarkDetected(): </color>" + GetVuMarkId(vumarkTarget));
        Debug.Log("ads");
        for (int i = 0; i < augmentationObjects.Length; i++)
        {
            
            if (int.Parse(GetVuMarkId(vumarkTarget)) == int.Parse((augmentationObjects[i].vumarkID)))
            {
                Debug.Log("test" + (augmentationObjects[i].vumarkID));
                test1.SetActive(true);
                augmentationObjects[i].augmentation.SetActive(true);
                img = i;
            }
        }
       
    }
    public GameObject LostVuMarkUI;
    public GameObject InteractVuMarkUI;
    public GameObject Num1;
    public GameObject Num2;
    public Material y;
    public GameObject NumT;
    public GameObject setaL;
    public GameObject x;
    public GameObject seta;

    /// <summary>
    /// This method will be called whenever a tracked VuMark is lost
    /// </summary>
    public void OnVuMarkLost(VuMarkTarget vumarkTarget)
    {
        LostVuMarkUI.SetActive(true);
        InteractVuMarkUI.SetActive(false);

        Debug.Log("<color=cyan>VuMarkHandler.OnVuMarkLost(): </color>" + GetVuMarkId(vumarkTarget));

        test1.SetActive(false);
        augmentationObjects[img].augmentation.SetActive(false);

        if (augmentationObjects[img].augmentation.name.Equals("Math"))
        {
            Debug.Log("fj");

            Num1.transform.position = new Vector3(-0.001f, 1.363f, -1.606f);
            NumT.GetComponent<MeshRenderer>().material = y;
            
            Num2.GetComponent<MeshRenderer>().material = y;
            setaL.SetActive(true);
            x.SetActive(false);
            seta.SetActive(true);
            if (vumarkTarget == this.currentVuMark)
                this.nearestVuMarkScreenPanel.ResetShowTrigger();
        }
    }

    #endregion // VUMARK_CALLBACK_METHODS
    ////////////////////////////////////////////////////

    /// <summary>
    /// </summary>
    /// <param name="vumarkTarget"></param>
    /// <returns></returns>
    
    

    #region PRIVATE_METHODS

    string GetVuMarkDataType(VuMarkTarget vumarkTarget)
    {
        switch (vumarkTarget.InstanceId.DataType)
        {
            case InstanceIdType.BYTES:
                return "Bytes";
            case InstanceIdType.STRING:
                return "String";
            case InstanceIdType.NUMERIC:
                return "Numeric";
        }
        return string.Empty;
    }

    string GetVuMarkId(VuMarkTarget vumarkTarget)
    {
        switch (vumarkTarget.InstanceId.DataType)
        {
            case InstanceIdType.BYTES:
                return vumarkTarget.InstanceId.HexStringValue;
            case InstanceIdType.STRING:
                return vumarkTarget.InstanceId.StringValue;
            case InstanceIdType.NUMERIC:
                return vumarkTarget.InstanceId.NumericValue.ToString();
        }
        return string.Empty;
    }



    #endregion // PRIVATE_METHODS
}
