using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;

    [SerializeField] private List<Pool> _pools = new List<Pool>();

    private Dictionary<ObjectType, Queue<GameObject>> _poolDictionary;
    
    public void ReturnObjectToPool(ObjectType objectType, GameObject objectToReturn)
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
        _poolDictionary = new Dictionary<ObjectType, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i < pool._startAmount; i++)
            {
                GameObject newGameObject = Instantiate(pool._objectToPool);
                
                newGameObject.SetActive(false);
                
                objectPool.Enqueue(newGameObject);
            }
        
            _poolDictionary.Add(pool._objectType, objectPool);
        }
    }

    public GameObject GetObjectFromPool(ObjectType objectType)
    {
        if(!_poolDictionary.ContainsKey(objectType))
        {
            Debug.LogWarning("Pool with tag '" + objectType + "' doesn't exist.");
            
            return null;
        }

        GameObject objectFromPool;

        objectFromPool = _poolDictionary[objectType].Dequeue();
            
        objectFromPool.SetActive(true);

        return objectFromPool;
    }
}

[System.Serializable]
public sealed class Pool
{
    public ObjectType _objectType;
    public GameObject _objectToPool;
    public int _startAmount;
}