using Unity.Mathematics;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void 
    // {
    //     if (other.tag == "Blade")
    //     {
    //         Vector3 direction = (other.transform.position = transform.position).normalized;
    //         Quaternion rotation = Quaternion.LookRotation(direction);
    //         Instantiate(slicedFruitPrefab, transform.position, quaternion.identity);
    //         Destroy(gameObject);
    //     }      prolo
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            Debug.Log("Chop");
            Vector3 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(slicedFruitPrefab, transform.position, quaternion.identity);
            Destroy(gameObject);
        } 
    }
}
