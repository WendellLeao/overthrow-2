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
        startOffset = transform.localPosition.z;
    }
    
    private void Update()
    {
        HandleRotation();
    }
    
    private void HandleRotation()
    {
        if(_playerController.GetWayPointSystem != null)
        {
            WayPointChecker wayPointChecker = _playerController.GetWayPointSystem.GetWayPointChecker;
            
            float distanceToRotate = 10f;

            if(wayPointChecker.GetNextTargetDistance() > distanceToRotate)
            {
                _laserContainer.SetActive(true);//Play Animation "HideLaserAnim"

                UpdateLaserRotation();
            }
            else
            {
                if(!wayPointChecker.NextTargetIsTheLast())
                {
                    _laserContainer.SetActive(false);//Play Animation "HideLaserAnim"
                }
            }
        }
    }

    private void UpdateLaserRotation()
    {
        if(_playerController.GetWayPointSystem != null)
        {
            WayPointDirectionChecker wayPointDirections = _playerController.GetWayPointSystem.GetWayPointDirections;

            switch(wayPointDirections.GetCurrentDirection)
            {
                case WayPointDirection.FOWARD:
                {
                    RotateToFoward();
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
    }

    private void RotateToFoward()
    {
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localPosition = new Vector3(0f, transform.localPosition.y, startOffset);
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
}