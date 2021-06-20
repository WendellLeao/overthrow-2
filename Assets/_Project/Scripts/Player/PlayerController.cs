using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private WayPointSystem _wayPointSystem;

    public PlayerInput PlayerInput => _playerInput;
    public WayPointSystem WayPointSystem => _wayPointSystem;
}