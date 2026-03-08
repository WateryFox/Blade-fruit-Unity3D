using System.Collections;
using UnityEditor.Callbacks;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform[] spawnPoints;
    public float minDelay = 0.5f;
    public float maxDelay = 1.5f;
    public float launchForce = 10f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawn());
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * launchForce, ForceMode.Impulse);
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
            Instantiate(prefabToSpawn, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
        }
    }
}
