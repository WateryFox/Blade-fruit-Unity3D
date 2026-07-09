using Unity.Mathematics;
using UnityEditor.Build.Content;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public float launchForce = 10f;
    private Rigidbody rb;

    private gameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * launchForce, ForceMode.Impulse);
        gameManager = FindFirstObjectByType<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            Debug.Log("Chop");
            Vector3 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(slicedFruitPrefab, transform.position, quaternion.identity);
            gameManager.addScore();
            Destroy(gameObject);
        } 
    }
}
