using UnityEngine;

public sealed class WayPointSystem : MonoBehaviour
{    
    [SerializeField] private Transform[] _wayPoints;
    public Transform[] WayPoints => _wayPoints;
    
    private int _wayPointIndex;
    public int WayPointIndex => _wayPointIndex;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    
    private WayPointChecker _wayPointChecker;

    private void Awake()
    {
        _wayPointChecker = new WayPointChecker(this, _wayPoints);
    }

    private void Start()
    {
        _wayPointIndex = 0;
        
        transform.position = _wayPoints[_wayPointIndex].transform.position;
    }

    private void Update()
    {
        HandleMovement();
        HandleWayPointIndex();
    }

    private void HandleMovement()
    {
        Vector3 targetPos = _wayPoints[_wayPointIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, _moveSpeed * Time.deltaTime);
    }

    private void HandleWayPointIndex()
    {
        if (_wayPointChecker.IsAtTheTargetPoint())
        {
            if (_wayPointChecker.IsAtTheLastPoint())
                _wayPointIndex = 0;
            else
                _wayPointIndex++;
        }
    }
}