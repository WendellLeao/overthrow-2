using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerInputListener", menuName = "Input/Player Input Listener")]
public sealed class PlayerInputListener : ScriptableObject
{
    [Header("Invoke events")]
    [SerializeField] private VoidEventChannel _pauseGameEvent;
    [SerializeField] private VoidEventChannel _playerShootEvent;

    private PlayerInputSystem _playerInputSystem;

    private PlayerInputSystem.CharacterControlsActions _characterControls;

    private void OnEnable()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterControls = _playerInputSystem.CharacterControls;

        _characterControls.PauseGame.performed += _ => _pauseGameEvent.RaiseEvent();
        _characterControls.Shoot.performed += _ => _playerShootEvent.RaiseEvent();
        
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