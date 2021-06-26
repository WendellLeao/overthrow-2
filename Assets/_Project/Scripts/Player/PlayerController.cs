using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerDamageHandler _playerDamageHandler;
    [SerializeField] private WayPointSystem _wayPointSystem;
    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private PlayerInputListener _playerInput;

    [Header("Listening to events")]
    [SerializeField] private GameEvent _gameStateChangeEvent;

    [Header("Game State Scriptable Object")]
    [SerializeField] private GameStateScriptableOject _gameStateScriptableObject;

    public WayPointSystem GetWayPointSystem => _wayPointSystem;
    public PlayerInputListener GetPlayerInput => _playerInput;

    private void OnEnable()
    {
        _gameStateChangeEvent.OnEventRaised += OnGameStateChanged_HandlePlayerComponents;
    }

    private void OnDisable()
    {
        _gameStateChangeEvent.OnEventRaised -= OnGameStateChanged_HandlePlayerComponents;
    }

    private void OnGameStateChanged_HandlePlayerComponents()
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
        _playerDamageHandler.enabled = false;
        _wayPointSystem.enabled = false;
        _playerShooting.enabled = false;
        //_playerInput.enabled = false;
    }

    private void EnablePlayerComponents()
    {
        _playerDamageHandler.enabled = true;
        _wayPointSystem.enabled = true;
        _playerShooting.enabled = true;
        //_playerInput.enabled = true;
    }
}