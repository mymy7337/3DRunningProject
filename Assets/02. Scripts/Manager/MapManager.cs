using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public GameObject mapPrefab;            // 반복할 맵 프리팹
    public int preSpawnCount;           // 시작 시 생성할 맵 수
    public float mapLength;           // 하나의 맵 길이
    public float moveSpeed;
    public float spawnTriggerOffset;  // 마지막 맵이 이 거리 이상 이동하면 다음 맵 생성
    public float despawnZ;           // 이 Z값보다 뒤에 있는 맵은 제거

    private Queue<GameObject> mapQueue = new Queue<GameObject>();
    private GameObject lastMap;

    protected override bool isDestroy => false;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        for (int i = 0; i < preSpawnCount; i++)
        {
            SpawnNextMap();
        }
    }

    void Update()
    {
        MoveMaps();
        TrySpawnNext();
        RemovePassedMaps();
    }

    void MoveMaps()
    {
        Debug.Log("moveSpeed: " + moveSpeed);

        foreach (GameObject map in mapQueue)
        {
            map.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    void TrySpawnNext()
    {
        if (lastMap == null) return;

        float lastMapZ = lastMap.transform.position.z;

        if (lastMapZ < spawnTriggerOffset)
        {
            SpawnNextMap();
        }
    }

    void SpawnNextMap()
    {
        Vector3 spawnPos = Vector3.zero;

        if (lastMap != null)
        {
            spawnPos = lastMap.transform.position + new Vector3(0, 0, mapLength);
        }

        GameObject newMap = Instantiate(mapPrefab, spawnPos, Quaternion.identity);
        mapQueue.Enqueue(newMap);
        lastMap = newMap;
    }

    void RemovePassedMaps()
    {
        if (mapQueue.Count == 0) return;

        GameObject firstMap = mapQueue.Peek();
        if (firstMap.transform.position.z < despawnZ)
        {
            Destroy(mapQueue.Dequeue());
        }
    }

}
