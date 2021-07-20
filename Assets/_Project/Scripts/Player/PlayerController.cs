using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] private WayPointSystem _wayPointSystem;

    public WayPointSystem GetWayPointSystem => _wayPointSystem;
}
