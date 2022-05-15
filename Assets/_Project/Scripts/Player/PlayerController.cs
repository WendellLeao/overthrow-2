using _Project.Scripts.Player.PlayerMovement;
using UnityEngine;

namespace _Project.Scripts.Player
{
    public sealed class PlayerController : MonoBehaviour
    {
        [Header("Player Components")]
        [SerializeField] private WayPointSystem _wayPointSystem;

        public WayPointSystem GetWayPointSystem()
        {
            return _wayPointSystem;
        }
    }
}
