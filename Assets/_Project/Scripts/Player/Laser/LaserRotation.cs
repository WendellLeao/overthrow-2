using UnityEngine;

public sealed class LaserRotation : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;
    private int _wayPointIndex;

    private void OnEnable()
    {
        _playerController.GetWayPointSystem.OnPlayerIsAtTarget += OnPlayerIsAtTarget_UpdateWayPointIndex;
    }

    private void OnDisable()
    {
        _playerController.GetWayPointSystem.OnPlayerIsAtTarget -= OnPlayerIsAtTarget_UpdateWayPointIndex;
    }
    
    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        transform.LookAt(_playerController.GetWayPointSystem.GetWayPoints[_wayPointIndex].position);
    }
    
    private void OnPlayerIsAtTarget_UpdateWayPointIndex()
    {
        _wayPointIndex = _playerController.GetWayPointSystem.GetWayPointIndex;
    }
}