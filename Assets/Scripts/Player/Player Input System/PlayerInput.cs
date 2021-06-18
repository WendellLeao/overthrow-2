using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    
    private PlayerInputSystem _playerInputSystem;
    private PlayerInputSystem.CharacterControlsActions _characterControls;

    private Vector2 _mouseInput;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterControls = _playerInputSystem.CharacterControls;

        _characterControls.HorizontalMouse.performed += ctx => _mouseInput.x = ctx.ReadValue<float>();
        _characterControls.HorizontalMouse.performed += ctx => _mouseInput.y = ctx.ReadValue<float>();
    }

    private void Update()
    {
        _playerController.PlayerMouseLook.SetMouseInput(_mouseInput);
    }

    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }
}
