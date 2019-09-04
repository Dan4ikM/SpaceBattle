using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstaclePrefabs;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private Transform obstacleParent;

    [SerializeField]
    private float SpawnRate = 1f;

    private bool IsSpawning;

    public void StartSpawn()
    {
        Instantiate(playerPrefab, obstacleParent);
        IsSpawning = true;
        StartCoroutine(Spawning());
    }

    public void StopSpawn()
    {
        IsSpawning = false;
        StopAllCoroutines();

        foreach (Transform obstacle in obstacleParent)
            Destroy(obstacle.gameObject);
    }

    private IEnumerator Spawning()
    {
        while(IsSpawning)
        {
            yield return new WaitForSeconds(SpawnRate);
            foreach (GameObject point in spawnPoints)
                SpawnObstacle(point);
        }
    }

    private void SpawnObstacle(GameObject point)
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)], point.transform);
        obstacle.transform.parent = obstacleParent;
    }

}
