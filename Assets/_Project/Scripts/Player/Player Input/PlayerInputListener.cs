using System;
using UnityEngine;

public sealed class PlayerInputListener : MonoBehaviour
{
    public event Action OnPlayerShot, OnGamePaused;
    
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    private PlayerInputSystem _playerInputSystem;

    private PlayerInputSystem.CharacterControlsActions _characterControls;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterControls = _playerInputSystem.CharacterControls;

        _characterControls.PauseGame.performed += _ => OnGamePaused?.Invoke();
        _characterControls.Shoot.performed += _ => OnPlayerShot?.Invoke();
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
