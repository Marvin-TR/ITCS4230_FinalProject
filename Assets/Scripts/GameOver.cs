using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour

{

    public TextMeshProUGUI hits;
    public TextMeshProUGUI time;

    public GameObject gameOverScreen;


    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
    }
    public void callGameOver(int hitCount, float elapsedTime) 
    {
        gameOverScreen.SetActive(true);
        hits.text = $"Hits: {hitCount}";
        time.text = $"Time: {elapsedTime}";
        
    }

    public void restart() 
    {
        gameObject.SetActive(false);
    }
}
