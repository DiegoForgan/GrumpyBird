using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipesSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int amountToStore = 5;
    [SerializeField] private float timeBeetweenSpawns = 2.5f;
    private float minY = -2.3f;
    private float maxY = 2.3f;
    private float spawnX = 11.5f;
    private float timeElapsed = 0f;
    private int currentSpawn = 0;
    private GameObject[] spawnablesPool;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawnablesPool = new GameObject[amountToStore];
        for (int i = 0; i < amountToStore; i++){
            spawnablesPool[i] = Instantiate(objectToSpawn);
            spawnablesPool[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed < timeBeetweenSpawns) return;
        SpawnObject();
        timeElapsed = 0f;
    }

    private void SpawnObject()
    {
        float randomYposition = Random.Range(minY,maxY);
        Vector2 randomSpawnPosition = new Vector2(spawnX,randomYposition);
        spawnablesPool[currentSpawn].transform.position = randomSpawnPosition;
        spawnablesPool[currentSpawn].SetActive(true);
        currentSpawn++;
        if(currentSpawn == amountToStore){
            currentSpawn = 0;
        } 
    }
}
