using UnityEngine;

public class blade : MonoBehaviour
{
    public float minCutSpeed = 10f;
    public bool isCutting = false;
    private Collider bcollider;
    private TrailRenderer trail;
    private Vector2 prevPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bcollider = GetComponent<Collider>();
        bcollider.enabled = false;
        trail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            stopCutting();
        }
        if (isCutting)
        {
            updatePos();
        }
    }

    void startCutting()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isCutting = true;
        prevPos = pos;
        trail.Clear();
    }
    void stopCutting()
    {
        isCutting = false;
        bcollider.enabled = false;
    }

    void updatePos()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        float velocity = (pos-prevPos).magnitude/Time.deltaTime;
        if (velocity > minCutSpeed)
        {
            bcollider.enabled = true;
        }
        else
        {
            bcollider.enabled = false;
            prevPos = pos;
        }
    }
}
