using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    [SerializeField]
    private Transform _teleportationPlace;

    [SerializeField]
    private float _triggerPoint;

    private PlayerController _playerController;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position.x - _startPosition.x >= _triggerPoint)
            if (_playerController != null)
                OnClick(_playerController);
    }

    private void OnClick(IInteractor sender)
    {
        if (_teleportationPlace == null) 
            return;

        sender.TeleportTo(_teleportationPlace);
        transform.position = _startPosition;
        _playerController = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _playerController = collision.transform.gameObject.GetComponentInParent<PlayerController>();
    }
}
