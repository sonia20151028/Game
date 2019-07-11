using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    [SerializeField] bool isLoop = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            var currentWave = waveConfigs[startWave];
            yield return (SpawnAllWaves());
        }
        while (isLoop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEmeniesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEmeniesInWave(WaveConfig waveCon)
    {
        Debug.Log("waveCon.getTimeBetweenSpawn()" + waveCon.getTimeBetweenSpawn());
        for (int emenyCount =0; emenyCount < waveCon.getEnemyNumbers(); emenyCount++)
        {
            var newEnemy = Instantiate(waveCon.getEnemyPrefab(), waveCon.getWavePoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().SetWayPoints(waveCon);
            yield return new WaitForSeconds(waveCon.getTimeBetweenSpawn());
        } 
    }
}
