using _Project.Scripts.Enums.ObjectPool;
using UnityEngine;

namespace _Project.Scripts.ObjectPool
{
    [System.Serializable]
    public sealed class Pool
    {
        public PoolType _poolType;
        public GameObject _objectToPool;
        public int _startAmount;
    }
}
