using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerDamageHandler _playerDamageHandler;
    [SerializeField] private WayPointSystem _wayPointSystem;
    [SerializeField] private PlayerShooting _playerShooting;
    [SerializeField] private PlayerInputListener _playerInput;

    public WayPointSystem GetWayPointSystem => _wayPointSystem;
    public PlayerInputListener GetPlayerInput => _playerInput;
}