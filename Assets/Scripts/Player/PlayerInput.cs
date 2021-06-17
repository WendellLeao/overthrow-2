using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
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
        return _playerInputSystem.CharacterControls.Look.ReadValue<Vector2>();
    }
}
