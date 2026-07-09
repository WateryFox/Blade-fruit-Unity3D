using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    private Spawner[] spawners;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = "Score " + score;
        spawners = Object.FindObjectsByType<Spawner>(FindObjectsSortMode.None);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore()
    {
        score += 100;
        scoreText.text = score + " ";
    }

    public void gameOver()
    {
        Debug.Log("Foreach?");
        foreach (Spawner spawner in spawners)
        {
            spawner.stopSpawning();
        }
    }
}
