using UnityEngine;

public sealed class WayPointDirections
{
    private WayPointSystem _wayPointSystem;
    private Transform[] _wayPoints;

    public WayPointDirections(WayPointSystem wayPointSystem, Transform[] wayPoints)
    {
        _wayPointSystem = wayPointSystem;
        _wayPoints = wayPoints;
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

    public bool NextTargetIsBackwards()
    {
        return _wayPointSystem.transform.position.z > _wayPoints[_wayPointSystem.GetWayPointIndex].transform.position.z;
    }
}
