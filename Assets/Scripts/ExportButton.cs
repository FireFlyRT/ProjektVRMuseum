using UnityEngine;

public class ExportButton : MonoBehaviour
{
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
        if (transform.position.y - _startPosition.y <= _triggerPoint)
            if (_playerController != null)
            {
                ExportTexture.ExportRenderTexture(GameManager.Instance.TextureToExport);
                transform.position = _startPosition;
                _playerController = null;
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        _playerController = collision.transform.gameObject.GetComponentInParent<PlayerController>();
    }
}
