using UnityEngine;

public sealed class LaserRotation : MonoBehaviour
{
    [Header("Player Controller")]
    [SerializeField] private PlayerController _playerController;

    [Header("Laser Components")]
    [SerializeField] private GameObject _laserContainer;
    [SerializeField] private Transform _laserTransform;
    
    [Header("Rotation")]
    [SerializeField] private float _distanceToRotate;
    
    private float _startOffset;

    private void Start()
    {
        SetStartOffset(_laserTransform.localPosition.z);
    }
    
    private void Update()
    {
        HandleRotation();
    }
    
    private void HandleRotation()
    {
        WayPointChecker wayPointChecker = _playerController.GetWayPointSystem().GetWayPointChecker();
            
        if(wayPointChecker.GetNextTargetDistance() > _distanceToRotate)
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
        WayPointDirectionChecker wayPointDirectionsChecker = _playerController.GetWayPointSystem().GetWayPointDirections();

        switch (wayPointDirectionsChecker.GetCurrentDirection())
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
        _laserTransform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        _laserTransform.localPosition = new Vector3(0f, _laserTransform.localPosition.y, _startOffset);
    }
    
    private void RotateToBackward()
    {
        _laserTransform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        _laserTransform.localPosition = new Vector3(0f, _laserTransform.localPosition.y, -_startOffset);
    }

    private void RotateToLeft()
    {
        _laserTransform.localRotation = Quaternion.Euler(0f, -90f, 0f);
        _laserTransform.localPosition = new Vector3(-_startOffset, _laserTransform.localPosition.y, 0f);
    }

    private void RotateToRight()
    {
        _laserTransform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        _laserTransform.localPosition = new Vector3(_startOffset, _laserTransform.localPosition.y, 0f);
    }

    private void SetStartOffset(float offset)
    {
        _startOffset = offset;
    }
}
