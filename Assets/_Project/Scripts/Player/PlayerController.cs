using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerDamageHandler _playerDamageHandler;
    [SerializeField] private PlayerInputListener _playerInput;
    [SerializeField] private WayPointSystem _wayPointSystem;
    [SerializeField] private PlayerShooting _playerShooting;

    public PlayerDamageHandler GetPlayerDamageHandler => _playerDamageHandler;
    public PlayerInputListener GetPlayerInput => _playerInput;
    public WayPointSystem GetWayPointSystem => _wayPointSystem;
    public PlayerShooting GetPlayerShooting => _playerShooting;

    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        _gameManager.OnGameStateChanged += OnGameStateChanged_HandlePlayerComponents;
    }

    private void OnDisable()
    {
        _gameManager.OnGameStateChanged -= OnGameStateChanged_HandlePlayerComponents;
    }

    private void OnGameStateChanged_HandlePlayerComponents()
    {
        if(_gameManager.GetCurrentGameState != GameState.PLAYING)
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