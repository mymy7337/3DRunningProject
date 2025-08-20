using System.Collections.Generic;
using UnityEngine;
public class MapManager : Singleton<MapManager>
{
    [Header("맵 프리팹")]
    public GameObject[] mapPrefabs;   // 랜덤으로 나올 맵

    [Header("맵 설정")]
    public int poolSize;          // 미리 생성할 맵 수
    public int startSpawnCount;      // 시작 시 화면에 배치할 맵 수
    public float mapLength;      // 맵 하나의 길이
    public float scrollSpeed;    // 맵 이동 속도
    public float spawnTriggerOffset; // 마지막 맵이 이 거리보다 앞으로 가면 새 맵 스폰
    public float despawnZ;      // 이 Z보다 뒤로 가면 재활용

    private Queue<GameObject> activeMaps = new Queue<GameObject>();
    private List<GameObject> waitingMaps = new List<GameObject>();
    private GameObject lastMap;

    protected override bool isDestroy => true;

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        // 1. 풀 생성
        for (int i = 0; i < poolSize; i++)
        {
            GameObject map = Instantiate(mapPrefabs[i], Vector3.zero, Quaternion.identity);
            map.SetActive(false);
            waitingMaps.Add(map);
        }

        // 2. 시작 화면 채우기
        for (int i = 0; i < startSpawnCount; i++)
        {
            SpawnNextMap();
        }
    }

    void Update()
    {
        MoveMaps();
        TrySpawnNext();
        RecyclePassedMaps();
    }

    void MoveMaps()
    {
        foreach (GameObject map in activeMaps)
        {
            map.transform.Translate(Vector3.back * scrollSpeed * Time.deltaTime);
        }
    }

    void TrySpawnNext()
    {
        if (lastMap == null) return;

        if (lastMap.transform.position.z < spawnTriggerOffset)
        {
            SpawnNextMap();
        }
    }

    void SpawnNextMap()
    {
        if (waitingMaps.Count == 0) return;

        int randIndex = Random.Range(0, waitingMaps.Count);
        GameObject map = waitingMaps[randIndex];
        waitingMaps.RemoveAt(randIndex);

        // 마지막 맵 기준으로 Spawn
        Vector3 spawnPos = Vector3.zero;
        if (lastMap != null)
            spawnPos = lastMap.transform.position + new Vector3(0, 0, mapLength);

        map.transform.position = spawnPos;
        map.SetActive(true);

        activeMaps.Enqueue(map);
        lastMap = map;
    }

    void RecyclePassedMaps()
    {
        if (activeMaps.Count == 0) return;

        GameObject firstMap = activeMaps.Peek();
        if (firstMap.transform.position.z < despawnZ)
        {
            activeMaps.Dequeue();
            firstMap.SetActive(false);
            waitingMaps.Add(firstMap);
        }
    }
}