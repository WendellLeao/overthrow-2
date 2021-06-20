using UnityEngine;

public sealed class LaserRotation : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    
    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        int wayPointIndex = _playerController.WayPointSystem.GetWayPointIndex;

        transform.LookAt(_playerController.WayPointSystem.GetWayPoints[wayPointIndex].position);
    }
}