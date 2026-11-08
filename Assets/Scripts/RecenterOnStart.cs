using UnityEngine;
using UnityEngine.XR;

public class RecenterOnStart : MonoBehaviour
{
    void Start()
    {
        Recenter();
    }

    public void Recenter()
    {
        // Headset Rotation holen
        InputDevices.GetDeviceAtXRNode(XRNode.Head)
            .TryGetFeatureValue(CommonUsages.centerEyeRotation, out Quaternion headsetRot);

        // Nur Y-Achse (Yaw) extrahieren
        float yRotation = headsetRot.eulerAngles.y;

        // XR Origin gegenrotieren
        transform.rotation = Quaternion.Euler(0, -yRotation, 0);
    }
}
