using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance {  get; private set; }

    private Dictionary<string, Queue<GameObject>> poolDict = new();
    private Dictionary<string, GameObject> prefabDict = new();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void CreatePool(string key, GameObject prefab, int count)
    {
        if (poolDict.ContainsKey(key)) return;

        Queue<GameObject> poolQueue = new();
        for (int i = 0; i < count; i++) {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
        poolDict[key] = poolQueue;
        prefabDict[key] = prefab;
    }

    public GameObject Spawn(string key, Vector3 position, Quaternion rotation)
    {
        if (!poolDict.ContainsKey(key))
        {
            Debug.LogError($"[PoolManager] '{key}' 풀은 존재하지 않습니다.");
            return null;
        }

        GameObject obj = poolDict[key].Count > 0 ? poolDict[key].Dequeue() : Instantiate(prefabDict[key]);

        if (obj == null) return null;

        obj.transform.SetPositionAndRotation(position, rotation);

        obj.SetActive(true);
        return obj;
    }

    public void Despawn(string key, GameObject obj)
    {
        obj.SetActive(false);
        poolDict[key].Enqueue(obj);
    }
}
