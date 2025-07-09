using System.Collections;
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
            if (ObjectForSocket.GetComponent<XRGrabInteractable>().interactionLayers.value == _socketInteractor.interactionLayers.value)
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
        StartCoroutine(nameof(ResetObject));
    }

    private IEnumerator ResetObject()
    {
        yield return new WaitForSeconds(0.5f);

        ObjectForSocket.GetComponent<XRGrabInteractable>().interactionLayers = 1;
        DestroyObject();
    }

    private void DestroyObject()
    {
        _socketInteractor.enabled = false;
        SocketDestroyEvent?.Invoke();
        Destroy(gameObject);
    }
}
