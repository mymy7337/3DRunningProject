using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapReset : MonoBehaviour
{
    public GameObject mapPrefab;      // 긴 하나의 맵 프리팹
    public Transform player;          // 캐릭터
    public float mapLength = 100f;    // 맵 프리팹의 길이 (Z축)
    public int maxMaps = 2;           // 동시에 유지할 맵 개수

    private float nextSpawnZ = 0f;
    private Queue<GameObject> spawnedMaps = new Queue<GameObject>();

    void Start()
    {
        // 처음에 2개 정도 붙여줌
        for (int i = 0; i < maxMaps; i++)
            SpawnMap();
    }

    void Update()
    {
        if (player.position.z + mapLength > nextSpawnZ)
        {
            SpawnMap();
            RemoveOldMap();
        }
    }

    void SpawnMap()
    {
        Vector3 spawnPos = new Vector3(0, 0, nextSpawnZ);
        GameObject newMap = Instantiate(mapPrefab, spawnPos, Quaternion.identity);
        spawnedMaps.Enqueue(newMap);
        nextSpawnZ += mapLength;
    }

    void RemoveOldMap()
    {
        if (spawnedMaps.Count > maxMaps)
        {
            GameObject oldMap = spawnedMaps.Dequeue();
            Destroy(oldMap); // 또는 재사용(풀링)도 가능
        }
    }
}