using UnityEngine;

[System.Serializable]
public sealed class Pool
{
    public PoolType _poolType;
    public GameObject _objectToPool;
    public int _startAmount;
}