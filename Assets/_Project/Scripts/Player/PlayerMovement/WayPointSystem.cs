using UnityEngine;

public sealed class WayPointSystem : MonoBehaviour
{    
    [SerializeField] private Transform[] _wayPoints;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvent;
    
    private WayPointDirectionChecker _wayPointDirectionChecker;
    private WayPointChecker _wayPointChecker;

    private float startVerticalPosition;

    private Vector3 targetPos, newPos;
    
    private int _wayPointIndex = 0;
    
    private void Awake()
    {
        InstanceWaypointCheckers();
    }

    private void Start()
    {
        SetStartVerticalPosition(this.transform.position.y);

        SetPlayerPosition(GetNewPosition());
    }

    private void Update()
    {
        HandleMovement();

        HandlePlayerIsAtTarget();

        _wayPointDirectionChecker.UpdateDirections();
    }

    private void HandleMovement()
    {
        SetPlayerPosition(Vector3.MoveTowards(transform.position, GetNewPosition(), _moveSpeed * Time.deltaTime));
    }

    private void HandlePlayerIsAtTarget()
    {
        if (_wayPointChecker.IsAtTheNextTarget())
        {
            if (_wayPointChecker.IsAtTheLastTarget())
            {
                _globalGameEvent.OnLevelCompleted?.Invoke();
            }
            else
            {
                _wayPointIndex++;
            }
        }
    }

    private void InstanceWaypointCheckers()
    {
        _wayPointChecker = new WayPointChecker(this, _wayPoints);

        _wayPointDirectionChecker = new WayPointDirectionChecker(this, _wayPoints);
    }
    
    private Vector3 GetNewPosition()
    {
        targetPos = _wayPoints[_wayPointIndex].transform.position;
        newPos = new Vector3(targetPos.x, startVerticalPosition, targetPos.z);

        return newPos;
    }
    
    public WayPointDirectionChecker GetWayPointDirections()
    {
        return _wayPointDirectionChecker;
    }

    public WayPointChecker GetWayPointChecker()
    {
        return _wayPointChecker;
    }

    public int GetWayPointIndex()
    {
        return _wayPointIndex;
    }
    
    private void SetStartVerticalPosition(float verticalPosition)
    {
        startVerticalPosition = verticalPosition;
    }

    private void SetPlayerPosition(Vector3 position)
    {
        transform.position = position;
    }
}
