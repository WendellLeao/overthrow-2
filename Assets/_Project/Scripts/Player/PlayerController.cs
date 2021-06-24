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
}