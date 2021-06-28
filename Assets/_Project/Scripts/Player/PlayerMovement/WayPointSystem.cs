using UnityEngine;

public sealed class WayPointSystem : MonoBehaviour
{    
    [SerializeField] private Transform[] _wayPoints;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;

    [Header("Game Events")]
    [SerializeField] private GlobalGameEvents _globalGameEvent;
    
    private WayPointDirectionChecker _wayPointDirections;
    private WayPointChecker _wayPointChecker;

    private float startVerticalPosition;

    private Vector3 targetPos, newPos;
    
    private int _wayPointIndex;
    
    public WayPointDirectionChecker GetWayPointDirections => _wayPointDirections;
    public WayPointChecker GetWayPointChecker => _wayPointChecker;
    
    public int GetWayPointIndex => _wayPointIndex;

    private void Awake()
    {
        _wayPointChecker = new WayPointChecker(this, _wayPoints);
        _wayPointDirections = new WayPointDirectionChecker(this, _wayPoints);
    }

    private void Start()
    {
        startVerticalPosition = this.transform.position.y;

        _wayPointIndex = 0;
        
        targetPos = _wayPoints[_wayPointIndex].transform.position;
        newPos = new Vector3(targetPos.x, startVerticalPosition, targetPos.z);

        this.transform.position = newPos;
    }

    private void Update()
    {
        HandleMovement();
        HandlePlayerIsAtTarget();

        _wayPointDirections.UpdateDirections();
    }

    private void HandleMovement()
    {
        targetPos = _wayPoints[_wayPointIndex].transform.position;
        newPos = new Vector3(targetPos.x, startVerticalPosition, targetPos.z);
        
        transform.position = Vector3.MoveTowards(transform.position, newPos, _moveSpeed * Time.deltaTime);
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
}