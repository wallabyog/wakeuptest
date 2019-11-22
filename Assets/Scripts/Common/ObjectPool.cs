using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : SingletonComponent<ObjectPool>
{
    [SerializeField] private StartupPoolObject[] _startupObjects;
    
    private Dictionary<GameObject, Queue<GameObject>> _pooledObject = new Dictionary<GameObject, Queue<GameObject>>();
    private Dictionary<GameObject, GameObject> _spawnedObject = new Dictionary<GameObject, GameObject>();
    private ObjectPool _instance1;

    private void Start()
    {
        foreach (var obj in _startupObjects)
            CreatePool(obj.Prefab, obj.Count);
    }
    
    void CreatePool(GameObject prefab, int count)
    {
        if (!_pooledObject.ContainsKey(prefab))
            _pooledObject.Add(prefab, new Queue<GameObject>());

        for (var i = 0; i < count; i++)
        {
            var go = Instantiate(prefab, ThisTransform);
            go.SetActive(false);
            _pooledObject[prefab].Enqueue(go);
        }

    }

    public GameObject Spawn(GameObject prefab, Transform parent, Vector3 position, Quaternion rotation)
    {
        if (!_pooledObject.ContainsKey(prefab))
        {
            _pooledObject.Add(prefab, new Queue<GameObject>());
        }

        if (_pooledObject[prefab].Count == 0)
            _pooledObject[prefab].Enqueue(Instantiate(prefab, ThisTransform));

        var go = _pooledObject[prefab].Dequeue();
        go.SetActive(true);
        _spawnedObject.Add(go, prefab);
        
        var t = go.transform;
        
        t.SetParent(parent);
        t.position = position;
        t.rotation = rotation;

        return go;
    }
    
    public T Spawn<T>(T prefab, Transform parent, Vector3 position, Quaternion rotation) where T : Component
    {
        return Spawn(prefab.gameObject, parent, position, rotation).GetComponent<T>();
    }

    public void Recycle(GameObject obj)
    {
        GameObject prefab;
        if (_spawnedObject.TryGetValue(obj, out prefab))
        {
            obj.SetActive(false);
            var t = obj.transform;
            
            t.SetParent(ThisTransform);
            t.position = Vector3.zero;
            t.rotation = Quaternion.identity;
            
            _spawnedObject.Remove(obj);
            _pooledObject[prefab].Enqueue(obj);
        }
    }

    protected override ObjectPool _instance => this;
}

[System.Serializable]
public class StartupPoolObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _count;

    public GameObject Prefab => _prefab;

    public int Count => _count;
}
