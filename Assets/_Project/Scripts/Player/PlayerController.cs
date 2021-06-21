using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private WayPointSystem _wayPointSystem;
    [SerializeField] private PlayerInputListener _playerInput;
    [SerializeField] private PlayerShooting _playerShooting;

    public WayPointSystem WayPointSystem => _wayPointSystem;
    public PlayerInputListener PlayerInput => _playerInput;
    public PlayerShooting PlayerShooting => _playerShooting;
}