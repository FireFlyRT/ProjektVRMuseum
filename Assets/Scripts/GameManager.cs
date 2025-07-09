using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public InputActionReference TriggerInputAction { get => _triggerInputAction; set => _triggerInputAction = value; }
    [SerializeField]
    private InputActionReference _triggerInputAction;
    public InputActionReference GrabInputAction { get => _grabInputAction; set => _grabInputAction = value; }
    [SerializeField]
    private InputActionReference _grabInputAction;

    public InteractionLayerMask SocketActiveLayer;

    public RenderTexture TextureToExport { get => _textureToExport; }
    [SerializeField]
    private RenderTexture _textureToExport;

    public bool IsTriggerActive { get => _isTriggerActive; set => _isTriggerActive = value; }
    private bool _isTriggerActive;

    public static GameManager Instance { get; private set; }
    public GameObject SelectedObject { get; internal set; }

    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // TEST:
        //ExportTexture.ExportRenderTexture(_textureToExport);
    }
}
