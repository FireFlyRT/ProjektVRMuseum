using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRController : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.TriggerInputAction.action.performed += OnTriggerPerformed;
        GameManager.Instance.TriggerInputAction.action.canceled += OnTriggerCancled;
        GameManager.Instance.GrabInputAction.action.canceled += OnGrabCanceled;
        GameManager.Instance.GrabInputAction.action.started += OnGrabStarted;
    }


    private void OnGrabStarted(InputAction.CallbackContext context)
    {
        StartCoroutine(nameof(SetSelectedObject));
    }

    private void OnGrabCanceled(InputAction.CallbackContext context)
    {
        GameManager.Instance.IsTriggerActive = false;
        GameManager.Instance.SelectedObject = null;
    }

    private void OnTriggerPerformed(InputAction.CallbackContext context)
    {
        if (GetComponentInChildren<RayInteractions>().HasObjectInHand && GameManager.Instance.SelectedObject != null)
            GameManager.Instance.IsTriggerActive = !GameManager.Instance.IsTriggerActive;
        else
        {
            GameManager.Instance.IsTriggerActive = false;
        }

#if DEBUG
        Debug.Log($"{nameof(OnTriggerPerformed)}: Trigger is {GameManager.Instance.IsTriggerActive} \n and Has Object = {GetComponentInChildren<RayInteractions>().HasObjectInHand}");
#endif
    }
    private void OnTriggerCancled(InputAction.CallbackContext context)
    {
        SocketPlacer[] sockets = FindObjectsByType<SocketPlacer>(FindObjectsSortMode.None);
        foreach (SocketPlacer socket in sockets)
            socket.OnControllerTriggerExit();
    }

    private IEnumerator SetSelectedObject()
    {
        yield return new WaitForEndOfFrame();

        XRRayInteractor interactor = GetComponentInChildren<XRRayInteractor>();

        if (interactor != null)
            GameManager.Instance.SelectedObject = interactor.firstInteractableSelected.transform.gameObject;
    }
}
