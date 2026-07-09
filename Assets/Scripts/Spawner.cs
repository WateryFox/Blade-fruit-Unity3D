using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject prefabtoSpawn;
    public Transform[] spawnPoints;
    public float minDelay = 0.5f;
    public float maxDelay = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator Spawn()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(prefabtoSpawn, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }

    public void stopSpawning()
    {
        // StopCoroutine(Spawn());
        Time.timeScale = 0f;
    }
}
