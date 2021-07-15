using UnityEngine;

public sealed class LaserRotation : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Laser Components")]
    [SerializeField] private GameObject _laserContainer;

    private float startOffset;

    private void Start()
    {
        SetStartDepthOffset(transform.localPosition.z);
    }
    
    private void Update()
    {
        HandleRotation();
    }
    
    private void HandleRotation()
    {
        WayPointChecker wayPointChecker = _playerController.GetWayPointSystem.GetWayPointChecker;
            
        float distanceToRotate = 10f;

        if(wayPointChecker.GetNextTargetDistance() > distanceToRotate)
        {
            _laserContainer.SetActive(true);

            UpdateLaserDirection();
        }
        else
        {
            if(!wayPointChecker.NextTargetIsTheLast())
            {
                _laserContainer.SetActive(false);
            }
        }
    }

    private void UpdateLaserDirection()
    {
        WayPointDirectionChecker wayPointDirectionsChecker = _playerController.GetWayPointSystem.GetWayPointDirections;

        switch (wayPointDirectionsChecker.GetCurrentDirection)
        {
            case WayPointDirection.FOWARD:
            {
                RotateToFoward();
                break;
            }
            case WayPointDirection.BACKWARD:
            {
                RotateToBackward();
                break;
            }
            case WayPointDirection.LEFT:
            {
                RotateToLeft();
                break;
            }
            case WayPointDirection.RIGHT:
            {
                RotateToRight();
                break;
            }
        }
    }

    private void RotateToFoward()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localPosition = new Vector3(0f, transform.localPosition.y, startOffset);
    }
    private void RotateToBackward()
    {
        transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        transform.localPosition = new Vector3(0f, transform.localPosition.y, -startOffset);
    }

    private void RotateToLeft()
    {
        transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        transform.localPosition = new Vector3(-startOffset, transform.localPosition.y, 0f);
    }

    private void RotateToRight()
    {
        transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        transform.localPosition = new Vector3(startOffset, transform.localPosition.y, 0f);
    }

    private void SetStartDepthOffset(float offset)
    {
        startOffset = offset;
    }
}