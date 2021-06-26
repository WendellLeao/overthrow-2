using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerDamageHandler _playerDamageHandler;
    [SerializeField] private WayPointSystem _wayPointSystem;
    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private PlayerInputListener _playerInput;

    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    public WayPointSystem GetWayPointSystem => _wayPointSystem;
    public PlayerInputListener GetPlayerInput => _playerInput;

    public void OnGameStateChanged_HandlePlayerComponents()
    {
        if(_gameStateScriptableObject.CurrentGameState != GameState.PLAYING)
        {
            DisablePlayerComponents();
        }
        else
        {
            EnablePlayerComponents();
        }
    }

    private void DisablePlayerComponents()
    {
        if(_playerDamageHandler != null)
        {
            _playerDamageHandler.enabled = false;
        }

        if(_wayPointSystem != null)
        {
            _wayPointSystem.enabled = false;
        }

        if(_playerShooting != null)
        {
            _playerShooting.enabled = false;
        }
        
        //_playerInput.enabled = false;
    }

    private void EnablePlayerComponents()
    {
       if(_playerDamageHandler != null)
        {
            _playerDamageHandler.enabled = true;
        }

        if(_wayPointSystem != null)
        {
            _wayPointSystem.enabled = true;
        }

        if(_playerShooting != null)
        {
            _playerShooting.enabled = true;
        }

        //_playerInput.enabled = true;
    }
}