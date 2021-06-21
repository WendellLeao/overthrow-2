using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private WayPointSystem _wayPointSystem;
    [SerializeField] private PlayerInputListener _playerInput;
    [SerializeField] private PlayerShooting _playerShooting;

    public WayPointSystem GetWayPointSystem => _wayPointSystem;
    public PlayerInputListener GetPlayerInput => _playerInput;
    public PlayerShooting GetPlayerShooting => _playerShooting;
}