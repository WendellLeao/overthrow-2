using UnityEngine;

public sealed class WayPointChecker
{
    private WayPointSystem _wayPointSystem;
    private Transform[] _wayPoints;

    public WayPointChecker(WayPointSystem wayPointSystem, Transform[] wayPoints)
    {
        _wayPointSystem = wayPointSystem;
        _wayPoints = wayPoints;
    }

    public float GetNextTargetDistance()
    {
        return Vector3.Distance(_wayPointSystem.transform.position, _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position);
    }

    public bool IsAtTheNextTarget()
    {
        return _wayPointSystem.transform.position == _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position;
    }

    public bool IsAtTheLastTarget()
    {
        return _wayPointSystem.transform.position == _wayPoints[_wayPoints.Length - 1].position;
    }

    public bool NextTargetIsLeft()
    {
        return _wayPointSystem.transform.position.x > _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position.x;
    }

    public bool NextTargetIsRight()
    {
        return _wayPointSystem.transform.position.x < _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position.x;
    }

    public bool NextTargetIsFoward()
    {
        return _wayPointSystem.transform.position.z < _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position.z;
    }
}
