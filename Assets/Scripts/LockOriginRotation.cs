using UnityEngine;
using UnityEngine.XR;

public class LockOriginRotation : MonoBehaviour
{
    void OnEnable()
    {
        InputTracking.trackingAcquired += OnTrackingAcquired;
    }

    void OnDisable()
    {
        InputTracking.trackingAcquired -= OnTrackingAcquired;
    }

    private void OnTrackingAcquired(XRNodeState node)
    {
        // XR Origin Rotation neutral halten
        transform.rotation = Quaternion.identity;
    }
}

