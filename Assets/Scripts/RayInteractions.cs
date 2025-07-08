using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRRayInteractor))]
public class RayInteractions : MonoBehaviour
{
    public bool HasObjectInHand { get => _hasObjectInHand; private set => _hasObjectInHand = value; }
    private bool _hasObjectInHand;

    public void SetHasObjectInHand(bool hasObjectInHand)
    {
        _hasObjectInHand = hasObjectInHand;
    }
}
