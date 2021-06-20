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

    public bool IsAtTheTargetPoint()
    {
        return _wayPointSystem.transform.position == _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position;
    }

    public bool IsAtTheLastPoint()
    {
        return _wayPointSystem.transform.position == _wayPoints[_wayPoints.Length - 1].position;
    }
}
