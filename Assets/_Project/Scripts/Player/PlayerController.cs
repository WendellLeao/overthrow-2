using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private WayPointSystem _wayPointSystem;

    [SerializeField] private PlayerDamageHandler _playerDamageHandler;

    public WayPointSystem GetWayPointSystem()
    {
        return _wayPointSystem;
    }

    public PlayerDamageHandler GetPlayerDamageHandler()
    {
        return _playerDamageHandler;
    }
}
