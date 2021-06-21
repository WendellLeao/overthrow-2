using System;
using UnityEngine;

public sealed class WayPointSystem : MonoBehaviour
{    
    public event Action OnPlayerIsAtTarget;
    
    [SerializeField] private Transform[] _wayPoints;
    private int _wayPointIndex;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    
    private WayPointChecker _wayPointChecker;
    
    public WayPointChecker GetWayPointChecker => _wayPointChecker;
    public int GetWayPointIndex => _wayPointIndex;

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
        if (_wayPointChecker.IsAtTheNextTarget())
        {
            OnPlayerIsAtTarget?.Invoke();
            
            if (_wayPointChecker.IsAtTheLastTarget())
            {
                //_wayPointIndex = 0;
                Debug.Log("You Won!");
            }
            else
            {
                _wayPointIndex++;
            }
        }
    }
}