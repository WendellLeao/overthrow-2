using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerInputListener : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private LocalGameEvents _localGameEvents;

    private InputActionsSystem _inputActionsSystem;
    private InputActionsSystem.CharacterControlsActions _characterControls;
    
    private bool _isShooting = false, _gameIsPaused = false;
    private Vector2 _mousePosition;

    private void OnEnable()
    {
        EnableInputSystem();

        SubscribeEvents();
    }

    private void OnDisable()
    {      
        DisableInputSystem();
        
        UnsubscribeEvents();
    }

    private void Update()
    {
        UpdateInputs();
    }

    private void EnableInputSystem()
    {
        _inputActionsSystem = new InputActionsSystem();
        _characterControls = _inputActionsSystem.CharacterControls;

        _inputActionsSystem.Enable();
    }

    private void DisableInputSystem()
    {
        _inputActionsSystem.Disable();
    }

    private void SubscribeEvents()
    {
        _characterControls.Shoot.performed += PerformShoot;
        _characterControls.PauseGame.performed += PauseGame;
        
        _characterControls.MouseLook.performed += MouseDelta;

        _characterControls.Shoot.canceled += PerformShoot;
        _characterControls.PauseGame.canceled += PauseGame;
    }

    private void UnsubscribeEvents()
    {
        _characterControls.Shoot.performed -= PerformShoot;
        _characterControls.PauseGame.performed -= PauseGame;
        
        _characterControls.MouseLook.performed -= MouseDelta;

        _characterControls.Shoot.canceled -= PerformShoot;
        _characterControls.PauseGame.canceled -= PauseGame;
    }

    private void UpdateInputs()
    {
        _localGameEvents.OnReadPlayerInputs?.Invoke(CreateInput());
    }

    private PlayerInputData CreateInput()
    {
        PlayerInputData playerInputData = new PlayerInputData();

        playerInputData.IsShooting = _isShooting;
        playerInputData.GameIsPaused = _gameIsPaused;
        playerInputData.MousePosition = _mousePosition;

        return playerInputData;
    }

    private void PerformShoot(InputAction.CallbackContext context)
    {
        switch(context.phase)
        {
            case InputActionPhase.Performed:
            {
                _isShooting = true;
                break;
            }
            case InputActionPhase.Canceled:
            {
                _isShooting = false;
                break;
            }
        }
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        switch(context.phase)
        {
            case InputActionPhase.Performed:
            {
                _gameIsPaused = true;
                break;
            }
            case InputActionPhase.Canceled:
            {
                _gameIsPaused = false;
                break;
            }
        }
    }

    private void MouseDelta(InputAction.CallbackContext action)
    {
        _mousePosition = action.ReadValue<Vector2>();
    } 
}