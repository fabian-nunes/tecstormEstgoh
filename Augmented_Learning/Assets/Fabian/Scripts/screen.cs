﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screen : MonoBehaviour
{
    IEnumerator CRSaveScreenshot()
    {
        Debug.Log("dsa");
        yield return new WaitForEndOfFrame();
        // string TwoStepScreenshotPath = MobileNativeShare.SaveScreenshot("Screenshot" + System.DateTime.Now.Hour + System.DateTime.Now.Minute + System.DateTime.Now.Second);
        // Debug.Log("A new screenshot was saved at " + TwoStepScreenshotPath);

        string myFileName = "Screenshot" + System.DateTime.Now.Hour + System.DateTime.Now.Minute +
                            System.DateTime.Now.Second + ".png";
        string myDefaultLocation = Application.persistentDataPath + "/" + myFileName;
        string myFolderLocation =
            "/storage/emulated/0/DCIM/Camera/Camera/"; //EXAMPLE OF DIRECTLY ACCESSING A CUSTOM FOLDER OF THE GALLERY
        string myScreenshotLocation = myFolderLocation + myFileName;

        //ENSURE THAT FOLDER LOCATION EXISTS
        if (!System.IO.Directory.Exists(myFolderLocation))
        {
            System.IO.Directory.CreateDirectory(myFolderLocation);
        }

        ScreenCapture.CaptureScreenshot(myFileName);
        //MOVE THE SCREENSHOT WHERE WE WANT IT TO BE STORED

        yield return new WaitForSeconds(1);

        System.IO.File.Move(myDefaultLocation, myScreenshotLocation);

        //REFRESHING THE ANDROID PHONE PHOTO GALLERY IS BEGUN
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent",
            new object[2]
            {
                "android.intent.action.MEDIA_MOUNTED",
                classUri.CallStatic<AndroidJavaObject>("parse", "file://" + myScreenshotLocation)
            });
        objActivity.Call("sendBroadcast", objIntent);
        //REFRESHING THE ANDROID PHONE PHOTO GALLERY IS COMPLETE
    }
}
