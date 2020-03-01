using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CarRecoScript : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // mover o carro e acender luzes
            CarScript.current.ShowLights();
            CarScript.current.start = true;
        }
        else
        {
            // nao mover carro e apagar luzes
            CarScript.current.HideLights();
            CarScript.current.start = false;
        }
    }
}
