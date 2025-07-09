using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSocketInteractor))]
public class SocketPlacer : MonoBehaviour
{
    public UnityAction SocketDestroyEvent;
    public GameObject ObjectForSocket;
    private XRSocketInteractor _socketInteractor;

    public void Awake()
    {
        _socketInteractor = GetComponent<XRSocketInteractor>();
        _socketInteractor.enabled = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (ObjectForSocket == other.gameObject)
            if (_socketInteractor.interactionLayers == -1 || 
                other.gameObject.layer == _socketInteractor.interactionLayers)
            {
                _socketInteractor.enabled = true;
                _socketInteractor.hoverExited.AddListener(OnHoverExited);
            }
    }

    public void OnHoverExited(HoverExitEventArgs args) 
    {
        if (ObjectForSocket != null && ObjectForSocket == GameManager.Instance.SelectedObject)
            if ( _socketInteractor.interactionLayers == -1/* || gameObject.layer == _socketInteractor.interactionLayers*/)
                DestroyObject();
    }

    public void OnControllerTriggerExit()
    {
        _socketInteractor.GetComponent<XRSocketInteractor>().showInteractableHoverMeshes = false;
        DestroyObject();
    }

    private void DestroyObject()
    {
        _socketInteractor.enabled = false;
        SocketDestroyEvent?.Invoke();
        Destroy(gameObject);
    }
}
