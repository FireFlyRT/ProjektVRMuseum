using UnityEngine;
using Unity.XR.CoreUtils;
using System.Collections;

public class ResetOpenXRRotation : MonoBehaviour
{
    private XROrigin xrOrigin;
    private Vector3 newWorldPosition;
    private float yPos = 1.5f; 

    void Awake()
    {
        xrOrigin = GetComponent<XROrigin>();
    }

    void Start()
    {
        newWorldPosition = new Vector3(GetComponentInParent<Transform>().position.x, yPos, 
                                       GetComponentInParent<Transform>().position.z);  
        // Nach einem Frame warten, bis OpenXR Tracking aktiv ist
        // testen ob das Funzt ansonsten alternative benutzen
        StartCoroutine(ResetRotationNextFrame());

        //alternative: 
        //StartCoroutine(ResetYRotationNextFrame());
    }

    IEnumerator ResetRotationNextFrame()
    {
        yield return null; // 1 Frame warten

        // Rotation zurücksetzen
        transform.rotation = Quaternion.identity;

        // Optional: Kamera neu positionieren, falls der Raum nicht am Ursprung liegt
        xrOrigin.MoveCameraToWorldLocation(newWorldPosition);
    }

    IEnumerator ResetYRotationNextFrame()
    {
        yield return null;
        Vector3 euler = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}

