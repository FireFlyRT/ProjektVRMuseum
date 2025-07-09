
using UnityEngine;

public class AttachSocketController : MonoBehaviour
{
    [SerializeField]
    private GameObject _placer;

    [SerializeField]
    private float _placerDistance = 0.5f;

    private Vector3 _lastPosition;

    public SocketPlacer InstatiateSocket(GameObject objectForSocket, Vector3 position, Quaternion rotation)
    {
        SocketPlacer socket = null;
        if (Vector3.Distance(_lastPosition, position) > _placerDistance)
        {
            socket = Instantiate(_placer, position, rotation, transform).GetComponent<SocketPlacer>();
            socket.ObjectForSocket = objectForSocket;
            _lastPosition = position;
        }
        return socket;
    }
}
