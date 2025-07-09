using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class XRController : MonoBehaviour
{
    public void Start()
    {
        GameManager.Instance.TriggerInputAction.action.performed += OnTriggerPerformed;
        GameManager.Instance.GrabInputAction.action.canceled += OnGrabCanceled;
    }

    private void OnGrabCanceled(InputAction.CallbackContext context)
    {
        GameManager.Instance.IsTriggerActive = false;
        GameManager.Instance.SelectedObject = null;
    }

    private void OnTriggerPerformed(InputAction.CallbackContext context)
    {
        GameManager.Instance.SelectedObject = GetComponentInChildren<XRRayInteractor>().firstInteractableSelected.transform.gameObject;

        if (GetComponentInChildren<RayInteractions>().HasObjectInHand && GameManager.Instance.SelectedObject != null)
            GameManager.Instance.IsTriggerActive = !GameManager.Instance.IsTriggerActive;
        else
        {
            GameManager.Instance.IsTriggerActive = false;
            SocketPlacer[] sockets = FindObjectsByType<SocketPlacer>(FindObjectsSortMode.None);
            foreach (SocketPlacer socket in sockets)
                socket?.OnControllerTriggerExit();
        }

#if DEBUG
        Debug.Log($"{nameof(OnTriggerPerformed)}: Trigger is {GameManager.Instance.IsTriggerActive} \n and Has Object = {GetComponentInChildren<RayInteractions>().HasObjectInHand}");
#endif
    }
}
