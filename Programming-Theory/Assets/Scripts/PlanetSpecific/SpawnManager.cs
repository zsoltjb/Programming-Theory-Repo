using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> enemyPrefab;
    public int numOfEnemiesInAWave;
    public int numOfWaves;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 3)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int i = Random.Range(0, enemyPrefab.Count);
        Instantiate(enemyPrefab[i]);
    }

}
