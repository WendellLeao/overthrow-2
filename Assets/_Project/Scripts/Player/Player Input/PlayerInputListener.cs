using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerInputListener", menuName = "Player/Player Input Listener")]
public sealed class PlayerInputListener : ScriptableObject
{
    private PlayerInputSystem _playerInputSystem;

    private PlayerInputSystem.CharacterControlsActions _characterControls;

    [Header("Invoke channels")]
    [SerializeField] private GameEvent _pauseGameEvent;
    [SerializeField] private GameEvent _playerShootEvent;

    private void OnEnable()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterControls = _playerInputSystem.CharacterControls;

        _characterControls.PauseGame.performed += _ => _pauseGameEvent.OnEventRaised?.Invoke();
        _characterControls.Shoot.performed += _ => _playerShootEvent.OnEventRaised?.Invoke();
        
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