using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private PlayerInput _playerInput;
    public PlayerInput PlayerInput => _playerInput;
}