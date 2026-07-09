using Unity.Mathematics;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    public float launchForce = 15f;
    public GameObject explosionEffect;
    private Rigidbody rb;
    private gameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * launchForce, ForceMode.Impulse);
        gm = GameObject.Find("gameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            gm.gameOver();
            Debug.Log("Potong bom");
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
