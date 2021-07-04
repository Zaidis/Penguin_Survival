using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float spawnRate = 0.3f;
    [SerializeField] int startingEnemies = 0;
    [SerializeField] int enemyIncreaseRate = 2;
    [SerializeField] float timeToFirstWave = 20f;
    [SerializeField] int childModuloNumber = 10;
    [SerializeField] int rangerModuloNumber = 8;
    [SerializeField] int hulkModuloNumber = 16;
    [SerializeField] List<GameObject> aliveEnemies;
    float timer = 0;
    bool spawnedFirstWave = false;
    bool waveGoing = false;
    [SerializeField] GameObject zookeeper, child, ranger, hulk;
    int wave = 0;

    private void Start()
    {
        UIManager.instance.UpdateWaveText(wave);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(!spawnedFirstWave && timer >= timeToFirstWave)
        {
            //Start spawning Waves
            spawnedFirstWave = true;
        }else
        {
            //Do normal stuff
            if(!waveGoing && timer > timeBetweenWaves)
            {
                //Spawn wave
              StartCoroutine(SpawnWave());
            }
        }
    }

    IEnumerator SpawnWave()
    {
        wave++;
        UIManager.instance.UpdateWaveText(wave);
        waveGoing = true;
        int spawnedEnemies = startingEnemies + enemyIncreaseRate;
        startingEnemies += enemyIncreaseRate;
        int numberOfChilds = 0;
        int numberOfRangers = 0;
        int numberOfHulks = 0;
        if (spawnedEnemies % childModuloNumber == 0)
        {
            numberOfChilds = spawnedEnemies / childModuloNumber;
        }
        
        if(spawnedEnemies % rangerModuloNumber == 0)
        {
            numberOfRangers = spawnedEnemies / rangerModuloNumber;
        }
        if(spawnedEnemies % hulkModuloNumber == 0) {
            numberOfHulks = 1;
        }
        //Spawn Zookeepers
        int zookeepersToSpawn = spawnedEnemies - numberOfChilds - numberOfRangers - numberOfHulks;
        int count = 0;
        while (count < zookeepersToSpawn)
        {
            count++;
            int rand = Random.Range(0, spawnPoints.Count);
           
            GameObject enemy =  Instantiate(zookeeper, spawnPoints[rand].position, Quaternion.identity);
            aliveEnemies.Add(enemy);

            yield return new WaitForSeconds(spawnRate);
        }

        count = 0;
        //Spawn Children
        while(count < numberOfChilds)
        {
            count++;
            int rand = Random.Range(0, spawnPoints.Count);

            GameObject enemy = Instantiate(child, spawnPoints[rand].position, Quaternion.identity);
            aliveEnemies.Add(enemy);

            yield return new WaitForSeconds(spawnRate);
        }
        count = 0;
        //Spawn Rangers
        while (count < numberOfRangers)
        {
            count++;
            int rand = Random.Range(0, spawnPoints.Count);

            GameObject enemy = Instantiate(ranger, spawnPoints[rand].position, Quaternion.identity);
            aliveEnemies.Add(enemy);

            yield return new WaitForSeconds(spawnRate);
        }
        count = 0;
        //Spawn Hulks

        while (count < numberOfHulks) {
            count++;
            int rand = Random.Range(0, spawnPoints.Count);

            GameObject enemy = Instantiate(hulk, spawnPoints[rand].position, Quaternion.identity);
            aliveEnemies.Add(enemy);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    public void RemoveEnemyFromList(GameObject theEnemy)
    {
        if (aliveEnemies.Contains(theEnemy))
        {
            aliveEnemies.Remove(theEnemy);
        }
        if(aliveEnemies.Count == 0)
        {
            waveGoing = false;
            timer = 0;
        }
        
    }
}
