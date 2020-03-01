using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpaceShipRecoScript : MonoBehaviour, ITrackableEventHandler
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
            MoveSpaceShip.current.start = true;
            MoveAsteroid.current.start = true;
            MoveAsteroid2.current.start = true;
        }
        else
        {
            MoveSpaceShip.current.start = false;
            MoveAsteroid.current.start = false;
            MoveAsteroid2.current.start = true;
        }
    }
}
