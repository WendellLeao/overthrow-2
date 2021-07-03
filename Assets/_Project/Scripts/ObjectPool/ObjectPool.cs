using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private List<Pool> _pools = new List<Pool>();

    private Dictionary<PoolType, Queue<GameObject>> _poolDictionary;

    public void ReturnObjectToPool(PoolType objectType, GameObject objectToReturn)
    {
        if (_poolDictionary.TryGetValue(objectType, out Queue<GameObject> objectList))
        {
            objectList.Enqueue(objectToReturn);
        }

        objectToReturn.SetActive(false);
    }

    private void Awake()
    {
        SetSingleton(this);
    }

    private void Start()
    {
        FillPool();
    }

    private void SetSingleton(ObjectPool objectPool)
    {
        instance = objectPool;
    }

    private void FillPool()
    {
        _poolDictionary = new Dictionary<PoolType, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool._startAmount; i++)
            {
                GameObject newGameObject = CreateNewObject(pool._objectToPool);

                objectPool.Enqueue(newGameObject);
            }

            _poolDictionary.Add(pool._poolType, objectPool);
        }
    }

    public GameObject GetObjectFromPool(PoolType poolType)
    {
        if (_poolDictionary.TryGetValue(poolType, out Queue<GameObject> objectList))
        {
            if (objectList.Count == 0)
            {
                return CreateBackupObject(poolType);
            }
            else
            {
                GameObject objectFromPool = objectList.Dequeue();

                objectFromPool.SetActive(true);

                return objectFromPool;
            }
        }
        else
        {
            Debug.LogWarning("Pool of type '" + poolType + "' doesn't exist!");

            return null;
        }
    }

    private GameObject CreateNewObject(GameObject gameObject)
    {
        GameObject newGameObject = Instantiate(gameObject);

        newGameObject.SetActive(false);

        return newGameObject;
    }

    private GameObject CreateBackupObject(PoolType poolType)
    {
        GameObject newBackupObject = null;

        foreach (Pool pool in _pools)
        {
            if (pool._poolType == poolType)
            {
                newBackupObject = Instantiate(pool._objectToPool);

                return newBackupObject;
            }
        }

        Debug.LogWarning("Pool of type '" + poolType + "' doesn't exist!");
        
        return null;
    }
}

[System.Serializable]
public sealed class Pool
{
    public PoolType _poolType;
    public GameObject _objectToPool;
    public int _startAmount;
}