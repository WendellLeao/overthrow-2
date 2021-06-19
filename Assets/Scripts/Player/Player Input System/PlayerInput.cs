using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;
    private PlayerInputSystem.CharacterControlsActions _characterControls;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterControls = _playerInputSystem.CharacterControls;
    }

    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    public Vector2 GetMouseDelta()
    {
        return _characterControls.MouseLook.ReadValue<Vector2>();
    }
}
