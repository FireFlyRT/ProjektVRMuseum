using UnityEngine;

public class PlacableObject : MonoBehaviour
{
    SocketPlacer socket = null;
    private void OnCollision(Collision collision)
    {
        var controller = collision.gameObject.GetComponent<AttachSocketController>();
        if (controller != null & GameManager.Instance.IsTriggerActive & GameManager.Instance.SelectedObject == gameObject & socket == null)
        {
            socket = controller.InstatiateSocket(collision.gameObject, collision.contacts[0].point, transform.rotation);
            if (socket != null)
                socket.SocketDestroyEvent += OnSocketDestroy;
        }
    }

    private void OnSocketDestroy()
    {
        socket = null;
    }

    public void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }

    public void OnCollisionStay(Collision collision)
    {
        OnCollision(collision);
    }
}
