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
        WayPointChecker wayPointChecker = _playerController.GetWayPointSystem.GetWayPointChecker;
        
        if(wayPointChecker.GetNextTargetDistance() > 10f)
        {
            _laserContainer.SetActive(true);//Play Animation "HideLaserAnim"

            if(wayPointChecker.NextTargetIsFoward())
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                transform.localPosition = new Vector3(0f, 0f, startOffset);
            }
            else if(wayPointChecker.NextTargetIsLeft())
            {
                transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                transform.localPosition = new Vector3(-startOffset, 0f, 0f);
            }
            else if(wayPointChecker.NextTargetIsRight())
            {
                transform.localRotation = Quaternion.Euler(0f, -90f, 0f);
                transform.localPosition = new Vector3(startOffset, 0f, 0f);
            }
        }
        else
        {
            _laserContainer.SetActive(false);//Play Animation "HideLaserAnim"
        }
    }
}