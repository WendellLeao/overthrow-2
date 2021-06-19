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
    }

    private void Update()
    {
        _playerController.PlayerMouseLook.SetMouseInput(GetMouseDelta());
    }

    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    private Vector2 GetMouseDelta()
    {
        return _characterControls.MouseLook.ReadValue<Vector2>();
    }
}
