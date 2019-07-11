using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int enemyNumbers = 5;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;

    //public GameObject getPathPrefab()
    //{
    //    return pathPrefab;
    //}
    public GameObject getEnemyPrefab()
    {
        return enemyPrefab;
    }
    public int getEnemyNumbers()
    {
        return enemyNumbers;
    }
    public float getMoveSpeed()
    {
        return moveSpeed;
    }
    public float getTimeBetweenSpawn()
    {
        return timeBetweenSpawn;
    }
    public float getSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public List<Transform> getWavePoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }
}
