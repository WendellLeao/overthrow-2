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

    public bool IsAtTheNextTarget()
    {
        return _wayPointSystem.transform.position.x == _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position.x 
        && _wayPointSystem.transform.position.z == _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position.z;
    }

    public bool IsAtTheLastTarget()
    {
        return _wayPointSystem.transform.position.x == _wayPoints[_wayPoints.Length - 1].transform.position.x 
        && _wayPointSystem.transform.position.z == _wayPoints[_wayPoints.Length - 1].transform.position.z;
    }

    public bool NextTargetIsTheLast()
    {
        return _wayPointSystem.GetWayPointIndex == _wayPoints.Length - 1;
    }

    public float GetNextTargetDistance()
    {
        return Vector3.Distance(_wayPointSystem.transform.position, _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position);
    }
}