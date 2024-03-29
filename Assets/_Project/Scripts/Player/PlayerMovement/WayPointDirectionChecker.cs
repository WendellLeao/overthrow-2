using _Project.Scripts.Enums.Player.PlayerMovement;
using UnityEngine;

namespace _Project.Scripts.Player.PlayerMovement
{
    public sealed class WayPointDirectionChecker
    {
        private WayPointSystem _wayPointSystem;
    
        private Transform[] _wayPoints;

        private WayPointDirection _currentDirection;
    
        public WayPointDirectionChecker(WayPointSystem wayPointSystem, Transform[] wayPoints)
        {
            _wayPointSystem = wayPointSystem;
            _wayPoints = wayPoints;
        }

        public void UpdateDirections()
        {
            if(NextTargetIsLeft())
            {
                _currentDirection = WayPointDirection.LEFT;
            }
            else if(NextTargetIsRight())
            {
                _currentDirection = WayPointDirection.RIGHT;
            }
            else if(NextTargetIsFoward())
            {
                _currentDirection = WayPointDirection.FOWARD;
            }
            else if(NextTargetIsBackward())
            {
                _currentDirection = WayPointDirection.BACKWARD;
            }
        }

        private bool NextTargetIsLeft()
        {
            return _wayPointSystem.transform.position.x > _wayPoints[_wayPointSystem.GetWayPointIndex()].transform.position.x;
        }

        private bool NextTargetIsRight()
        {
            return _wayPointSystem.transform.position.x < _wayPoints[_wayPointSystem.GetWayPointIndex()].transform.position.x 
                   && !NextTargetIsFoward();
        }

        private bool NextTargetIsFoward()
        {
            return _wayPointSystem.transform.position.z < _wayPoints[_wayPointSystem.GetWayPointIndex()].transform.position.z;
        }

        private bool NextTargetIsBackward()
        {
            return _wayPointSystem.transform.position.z > _wayPoints[_wayPointSystem.GetWayPointIndex()].transform.position.z;
        }
    
        public WayPointDirection GetCurrentDirection()
        {
            return _currentDirection;
        }
    }
}
