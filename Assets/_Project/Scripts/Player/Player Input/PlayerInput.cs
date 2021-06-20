using UnityEngine;

public sealed class PlayerInput : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;

    private PlayerInputSystem.CharacterControlsActions _characterControls;
    public PlayerInputSystem.CharacterControlsActions CharacterControls => _characterControls;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterControls = _playerInputSystem.CharacterControls;

        //_characterControls.Shoot.performed += _ => OnPlayerShoot_PerformShoot();
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
