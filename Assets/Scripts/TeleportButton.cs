using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    [SerializeField]
    private Transform _teleportationPlace;

    [SerializeField]
    private float _triggerPoint;

    [SerializeField]
    private PlayerController _playerController;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void OnClick()
    {
        if (_teleportationPlace == null) 
            return;

        _playerController.TeleportTo(_teleportationPlace);
        transform.position = _startPosition;
    }
}
