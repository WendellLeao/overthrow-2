using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerInputListener : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvents;

    private PlayerInputSystem _playerInputSystem;
    private PlayerInputSystem.CharacterControlsActions _characterControls;
    
    private bool _isShooting, _gameIsPaused;
    private Vector2 _mouseLookAtPosition;

    private void OnEnable()
    {
        _playerInputSystem = new PlayerInputSystem();
        _characterControls = _playerInputSystem.CharacterControls;

        _characterControls.Shoot.performed += PerformShoot;
        _characterControls.PauseGame.performed += PauseGame;
        _characterControls.MouseLook.performed += MouseDelta;

        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    private void Update()
    {
        _localGameEvents.OnReadPlayerInputs?.Invoke(CreateInput());
    }

    private PlayerInputData CreateInput()
    {
        PlayerInputData playerInputData = new PlayerInputData();

        playerInputData.IsShooting = _isShooting;
        playerInputData.GameIsPaused = _gameIsPaused;
        playerInputData.MousePosition = _mouseLookAtPosition;

        return playerInputData;
    }

    private void PerformShoot(InputAction.CallbackContext action)
    {
        switch(action.phase)
        {
            case InputActionPhase.Performed:
            _isShooting = true;
            break;
            case InputActionPhase.Canceled:
            _isShooting = false;
            break;
        }
    }

    private void PauseGame(InputAction.CallbackContext action)
    {
        switch(action.phase)
        {
            case InputActionPhase.Performed:
            _gameIsPaused = true;
            break;
            case InputActionPhase.Canceled:
            _gameIsPaused = false;
            break;
        }
    }

    private void MouseDelta(InputAction.CallbackContext action)
    {
        _mouseLookAtPosition = action.ReadValue<Vector2>();
    } 
}